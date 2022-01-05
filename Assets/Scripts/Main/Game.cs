using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Main
{
    public class Game : MonoBehaviour
    {
        public static event Action<bool> EndGame; 
        public static event Action<bool> EndRound; 
        public static event Action<bool> StartGame;
        public static event Action<int> GetPoint1;
        public static event Action<int> GetPoint2;

        private static int m_Score1;
        public static int Score1 => m_Score1;
        
        private static int m_Score2;
        public static int Score2 => m_Score2;

        private static bool m_IsEnd;
        public static bool IsEnd => m_IsEnd;

        private GameObject m_Washer;
        private Vector3 m_WasherPos = new Vector3(0, 0, -1);
        
        private GameObject m_Player1;
        private Vector3 m_Player1Pos = new Vector3(0, -4, -1);
        
        private GameObject m_Player2;
        private Vector3 m_Player2Pos = new Vector3(0, 4, -1);
        

        private void Awake()
        {
            m_IsEnd = false;
            m_Washer = Instantiate(GameAssets.GetInstance().Washer, m_WasherPos, Quaternion.identity);
            m_Player1 = Instantiate(GameAssets.GetInstance().Player1, m_Player1Pos, Quaternion.identity);
            m_Player2 = Instantiate(GameAssets.GetInstance().Player2, m_Player2Pos, Quaternion.identity);

            SceneManager.LoadScene("Scenes/UI", LoadSceneMode.Additive);
        }

        private void OnEnable()
        {
            EndRound += NextRound;
        }

        private void OnDisable()
        {
            EndRound -= NextRound;
        }

        private void Start()
        {
            GetPoint1?.Invoke(m_Score1);
            GetPoint2?.Invoke(m_Score2);
        }

        private void NextRound(bool endRound)
        {
            if (endRound)
            {
                m_Washer.transform.position = m_WasherPos;
                m_Player1.transform.position = m_Player1Pos;
                m_Player2.transform.position = m_Player2Pos;
            }
        }

        private static void End()
        {
            m_IsEnd = true;
            Time.timeScale = 0f;
            EndGame?.Invoke(true);
        }

        public static void AddPoint(int player)
        {
            if (player == 1)
            {
                m_Score1 += 1;
                GetPoint1?.Invoke(m_Score1);
            }
            else
            {
                m_Score2 += 1;
                GetPoint2?.Invoke(m_Score2);
            }
            EndRound?.Invoke(true);
            if (m_Score1 == 7 || m_Score2 == 7)
            {
                End();
            }
            else
            {
                EndRound?.Invoke(true);
            }
        }
    }
}

