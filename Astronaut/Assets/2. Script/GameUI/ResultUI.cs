using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Astronaut.ResultUI
{
    [DisallowMultipleComponent]
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] Sprite[] m_Sprites;

        TextUI[] m_Texts;
        GradeUI m_Grade;

        // Back 버튼 이벤트
        public void BackButton()
        {
            Destroy(GameManager.s_Instance.gameObject);
            SceneManager.LoadScene("Select");
        }

        private void Awake()
        {
            m_Texts = GetComponentsInChildren<TextUI>();
            m_Grade = GetComponentInChildren<GradeUI>();
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            var refGameMgr = GameManager.s_Instance;
            m_Texts[0].WriteText(string.Format("{0}/{1}", refGameMgr.effectScore, refGameMgr.EffectCount));
            m_Texts[1].WriteText(string.Format("{0}/{1}", refGameMgr.normalScore, refGameMgr.NormalCount));
            m_Texts[2].WriteText(string.Format("{0}/{1}", refGameMgr.miniScore, refGameMgr.MiniCount));

            float percent = (refGameMgr.score / refGameMgr.TotalNote) * 100;
            m_Texts[3].WriteText(string.Format("{0:f}%", percent));

            if(GameManager.IsFailed)
            {
                m_Grade.SetSprite(m_Sprites[5]);
            }
            else
            {
                if (percent > 95.0f)
                    m_Grade.SetSprite(m_Sprites[0]);
                else if (percent > 90.0f)
                    m_Grade.SetSprite(m_Sprites[1]);
                else if (percent > 80.0f)
                    m_Grade.SetSprite(m_Sprites[2]);
                else if (percent > 70.0f)
                    m_Grade.SetSprite(m_Sprites[3]);
                else
                    m_Grade.SetSprite(m_Sprites[4]);
            }
        }
    }
}