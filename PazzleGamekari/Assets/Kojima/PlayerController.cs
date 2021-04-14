using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    [SerializeField] float m_squareSize = 50f;
    [SerializeField] float m_oneSquareSecond = 1f;
    [SerializeField] LayerMask m_blockLayer;

    Vector2 m_dir = Vector2.zero;
    
    bool m_moveing = false;

    void Start()
    {
    }

    void Update()
    {
        if (!m_moveing)
        {
            if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal"))
            {
                float v = Input.GetAxisRaw("Vertical");
                float h = Input.GetAxisRaw("Horizontal");

                if (v != 0)
                {
                    m_moveing = true;
                    m_dir = new Vector2(0, v);
                    StartCoroutine(Move());
                }
                else if (h != 0)
                {
                    m_moveing = true;
                    m_dir = new Vector2(h, 0);
                    StartCoroutine(Move());
                }
            }
        }
    }

    public void Stop()
    {
        m_moveing = false;
    }

    IEnumerator Move()
    {
        //bool m = false;
        while (m_moveing)
        {
            Vector2 movePos = (Vector2)this.transform.position + m_dir * m_squareSize;
            Debug.Log(m_dir);

            RaycastHit2D hitBlock = Physics2D.Raycast(this.transform.position, m_dir, m_squareSize, m_blockLayer);
            Debug.DrawLine(this.transform.position, (Vector2)this.transform.position + m_dir * m_squareSize);

            if (hitBlock.collider)
            {
                hitBlock.collider.gameObject.GetComponent<Block>().Hit();
                m_moveing = false;
            }
            else
            {
                Debug.Log(0);
                yield return StartCoroutine(DM(movePos));//transform.DOMove(movePos, m_oneSquareSecond).SetEase(Ease.Linear);
            }

            //m_moveing = false;

        }

        IEnumerator DM(Vector2 movePos)
        {
            transform.DOMove(movePos, m_oneSquareSecond);//.SetEase(Ease.Linear);
            yield return null;
        }
    } 
}

