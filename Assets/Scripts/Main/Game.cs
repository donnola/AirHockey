using UnityEngine.SceneManagement;
using UnityEngine;
using System;


namespace Main
{
    public class Game : MonoBehaviour
    {
        public static event Action<bool> EndGame; 
        public static event Action<int> EndRound; 
        public static event Action<float> ChangeCount; 
        public static event Action<int> GetPoint;

        private static int m_Score1;
        public static int Score1 => m_Score1;
        
        private static int m_Score2;
        public static int Score2 => m_Score2;

        private static bool m_Playing;
        public static bool Playing => m_Playing;

        private static bool m_GameOver;
        public static bool GameOver => m_GameOver;


        private GameObject m_Washer;
        private Vector3 m_WasherPos = new Vector3(0, 0, -1);
        private Rigidbody2D m_WasherRigidBody;
        
        private GameObject m_Player1;
        private Vector3 m_Player1Pos = new Vector3(0, -4, -1);

        private GameObject m_Player2;
        private Vector3 m_Player2Pos = new Vector3(0, 4, -1);



        private void Awake()
        {
            m_Score1 = 0;
            m_Score2 = 0;
            m_GameOver = false;
            m_Washer = Instantiate(GameAssets.GetInstance().Washer, m_WasherPos, Quaternion.identity);
            m_Player1 = Instantiate(GameAssets.GetInstance().Player1, m_Player1Pos, Quaternion.identity);
            m_Player2 = Instantiate(GameAssets.GetInstance().Player2, m_Player2Pos, Quaternion.identity);
            SceneManager.LoadScene("Scenes/UI", LoadSceneMode.Additive);
            Pause();
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
            m_WasherRigidBody = m_Washer.GetComponent<Rigidbody2D>();
            ChangeCount?.Invoke(3.0f);
        }

        public static void Resume()
        {
            m_Playing = true;
        }

        public static void Pause()
        {
            m_Playing = false;
        }

        private void NextRound(int player_win)
        {
            Pause();
            m_WasherRigidBody.velocity = Vector3.zero;
            if (player_win == 1)
            {
                m_Washer.transform.position = m_WasherPos + Vector3.up;
            }
            else
            {
                m_Washer.transform.position = m_WasherPos + Vector3.down;
            }
            m_Player1.transform.position = m_Player1Pos;
            m_Player2.transform.position = m_Player2Pos;
            if (m_Score1 == 7 || m_Score2 == 7)
            {
                End();
            }
            else
            {
                ChangeCount?.Invoke(3.0f);
            }
        }

        private static void End()
        {
            m_GameOver = true;
            Pause();
            EndGame?.Invoke(true);
        }

        public static void AddPoint(int player)
        {
            if (player == 1)
            {
                m_Score1 += 1;
                GetPoint?.Invoke(1);
                EndRound?.Invoke(1);
            }
            else
            {
                m_Score2 += 1;
                GetPoint?.Invoke(2);
                EndRound?.Invoke(2);
            }
        }
    }
}

