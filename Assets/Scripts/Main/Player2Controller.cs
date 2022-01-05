using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class Player2Controller : MonoBehaviour
    {
        private Rigidbody2D m_PlayerRigidBody;
        private Vector2 m_MousePos;
        void Start()
        {
            m_PlayerRigidBody = GetComponent<Rigidbody2D>();
        }
        
        void Update()
        {
            m_PlayerRigidBody.velocity = Vector3.zero;
            if (Input.GetMouseButton(0))
            {
                m_MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (m_MousePos.y >= 0.3f && m_MousePos.y <= 4 && m_MousePos.x <= 2.5f && m_MousePos.x >= -2.5f)
                {
                    m_PlayerRigidBody.MovePosition(new Vector3(m_MousePos.x, m_MousePos.y, -1));
                }
            }

            if (gameObject.transform.position.y > 4)
            {
                m_PlayerRigidBody.MovePosition(new Vector3(gameObject.transform.position.x, 4, -1));
            }
            if (gameObject.transform.position.y < 0.3f)
            {
                m_PlayerRigidBody.MovePosition(new Vector3(gameObject.transform.position.x, 0.3f, -1));
            }
        }
    }
}

