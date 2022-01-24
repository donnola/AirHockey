using UnityEngine.UI;
using Main;
using UnityEngine;

namespace UI
{
    public class Point: MonoBehaviour
    {
        [SerializeField] 
        private Text m_FirstPlayerScore;
        [SerializeField] 
        private Text m_SecondPlayerScore;

        private void Awake()
        {
            m_FirstPlayerScore.text = "0";
            m_SecondPlayerScore.text = "0";
        }

        private void OnEnable()
        {
            Game.GetPoint += ChangeMark;
        }

        private void OnDisable()
        {
            Game.GetPoint -= ChangeMark;
        }

        void ChangeMark(int player)
        {
            if (player == 1)
            {
                m_FirstPlayerScore.text = $"{Game.Score1}";
            }
            else
            {
                m_SecondPlayerScore.text = $"{Game.Score2}";
            }
        }
    }
}