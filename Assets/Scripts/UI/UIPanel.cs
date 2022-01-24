using UnityEngine;
using UnityEngine.UI;
using Main;

namespace UI
{
    public class UIPanel: MonoBehaviour
    {
        [SerializeField] private GameObject m_Bottoms;
        [SerializeField] private Text m_Countdown;

        private float m_timer;
        private int m_nextcount;
        private void Start()
        {
            m_Bottoms.SetActive(false);
        }

        private void Update()
        {
            if (!Game.Playing && !Game.GameOver)
            {
                if (m_timer >= -1)
                {
                    m_timer -= Time.deltaTime;
                    if (m_timer <= m_nextcount)
                    {
                        m_Countdown.text = $"{m_nextcount}";
                        m_nextcount -= 1;
                    }
                }
                if (m_timer < -1)
                {
                    m_Countdown.gameObject.SetActive(false);
                    Game.Resume();
                }
            }
        }

        private void OnEnable()
        {
            Game.EndGame += ActiveBottoms;
            Game.ChangeCount += ChangeCountdown;
        }

        private void OnDisable()
        {
            Game.EndGame -= ActiveBottoms;
            Game.ChangeCount -= ChangeCountdown;
        }

        private void ActiveBottoms(bool active)
        {
            m_Bottoms.SetActive(true);
        }

        private void ChangeCountdown(float count)
        {
            m_Countdown.gameObject.SetActive(true);
            m_timer = count;
            m_Countdown.text = $"{(int) count}";
            m_nextcount = (int) (m_timer - 1);
        }
    }
}