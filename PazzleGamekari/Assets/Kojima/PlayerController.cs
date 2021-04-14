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
                    m_dir = new Vector2(0, v);
                    Move(m_dir);
                }
                else if (h != 0)
                {
                    transform.localScale = h > 0 ? new Vector3(-1, 1, 1) : Vector3.one;
                    m_dir = new Vector2(h, 0);
                    Move(m_dir);
                }
            }
        }
        else
        {
            AudioManager.Instance.SubeSE();
        }
    }

    void Move(Vector2 dir)
    {
        m_moveing = true;

        Vector2 movePos = (Vector2)this.transform.position + dir * m_squareSize;
        RaycastHit2D hitBlock = Physics2D.Raycast(this.transform.position, dir, m_squareSize, m_blockLayer);
        Debug.DrawLine(this.transform.position, (Vector2)this.transform.position + dir * m_squareSize);

        if (!hitBlock.collider)
        {
            transform.DOMove(movePos, m_oneSquareSecond).OnComplete(() => Move(dir)).SetEase(Ease.Linear);
        }
        else
        {
            Stop();
            AudioManager.Instance.StopSE();
            hitBlock.collider.gameObject.GetComponent<Block>().Hit();
        }
    }

    public void Stop()
    {
        m_moveing = false;
    }

}

