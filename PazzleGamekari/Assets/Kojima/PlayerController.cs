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

        if (m_dir != Vector2.zero)
        {
            m_moveing = true;
            m_rb.velocity = m_dir * m_speed;
            Debug.Log(m_dir);

        }

        if (!m_moveing)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            if (v != 0)
            {
                m_dir.y = v;
            }
            else if (h != 0)
            {
                m_dir.x = h;
            }
        }
    }
}
