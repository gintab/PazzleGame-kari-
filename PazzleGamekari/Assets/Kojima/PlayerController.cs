using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    bool m_moveing = false;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 dir = Vector2.zero;

        if (dir != Vector2.zero)
        {
            m_rb.velocity = dir * m_speed;
        }

        if (!m_moveing)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            if (v != 0)
            {
                dir.y = v;
            }
            else if (h != 0)
            {
                dir.x = h;
            }
            Debug.Log(dir);
        }
    }
}
