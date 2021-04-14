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

    AudioSource m_as;

    void Start()
    {
        m_as = GetComponent<AudioSource>();
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
            //m_as
        }
    }

    void Move(Vector2 dir)
    {
        Debug.Log(dir);
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
            //m_as
            hitBlock.collider.gameObject.GetComponent<Block>().Hit();
        }
    }

    public void Stop()
    {
        m_moveing = false;
    }

    //public void Bounce()
    //{
    //    if (m_dir.x > 0)
    //    {
    //        m_dir.x = -1;
    //    }
    //    else
    //    {
    //        m_dir.x = 1;
    //    }

    //    if (m_dir.y > 0)
    //    {
    //        m_dir.y = -1;
    //    }
    //    else
    //    {
    //        m_dir.y = 1;
    //    }

    //    Move(m_dir);
    //}
}

