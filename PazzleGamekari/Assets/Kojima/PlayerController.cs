using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    Vector2 m_dir = Vector2.zero;
    bool m_moveing = false;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!m_moveing)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            if (v != 0)
            {
                m_moveing = true;
                m_dir = new Vector2(0, v);
            }
            else if (h != 0)
            {
                m_moveing = true;
                m_dir = new Vector2(h, 0);
            }
        }

        if (m_moveing)
        {
            m_rb.velocity = m_dir * m_speed;
        }
    }

    public void Stop()
    {
        m_moveing = false;
        m_rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Stop();
    }
}

