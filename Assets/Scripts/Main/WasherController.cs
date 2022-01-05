using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class WasherController : MonoBehaviour
    {
        private Rigidbody2D m_WasherRigidBody;
        void Start()
        {
            m_WasherRigidBody = GetComponent<Rigidbody2D>();
        }
        void OnTriggerEnter2D (Collider2D other)
        {
            if (other.transform.CompareTag("FieldOut1"))
            {
                Debug.Log("goool");
                Game.AddPoint(1);
            }
            else if (other.transform.CompareTag("FieldOut2"))
            {
                Debug.Log("goool");
                Game.AddPoint(2);
            }
        }
    }
}

