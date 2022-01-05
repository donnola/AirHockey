using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets instance;

        [SerializeField] private GameObject m_Player1;
        [SerializeField] private GameObject m_Player2;
        [SerializeField] private GameObject m_Washer;

        public GameObject Player1 => m_Player1;
        public GameObject Player2 => m_Player2;
        public GameObject Washer => m_Washer;

        public static GameAssets GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }
    }
}
