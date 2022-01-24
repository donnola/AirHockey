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
            if (Game.Playing && Input.GetMouseButton(0))
            {
                m_MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (m_MousePos.y >= 0.25f && m_MousePos.y <= 4.79f && m_MousePos.x <= 3.0f && m_MousePos.x >= -3.0f)
                {
                    m_PlayerRigidBody.MovePosition(new Vector3(m_MousePos.x, m_MousePos.y, -1));
                }
            }
            m_PlayerRigidBody.velocity = Vector3.zero;
        }
    }
}

