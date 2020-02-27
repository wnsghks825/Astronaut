using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Astronaut.GameUI
{
    [RequireComponent(typeof(Button))]
    public class PauseUI : SystemUI
    {
        [SerializeField] Color pauseColor = Color.black;      // 일시정지 일 때, 나타나는 컬러
        [SerializeField] Color resumeColor = Color.white;     // 재개하고 있을 때, 나타나는 컬러

        private Image m_image;
        public Image image;
        private bool isActived;
        
        /// 버튼을 클릭헀을 시 발생하는 함수
        public void ClickPauseButton()
        {
            //m_gameUI.PausedButtonSetActive(EActiveType.Off);
            Time.timeScale = 0.0f;
            image.gameObject.SetActive(true);
            //this.gameObject.SetActive(false);
        }

        // SystemUI 추상메서드 구현부
        protected override IEnumerator ActiveCoroutine()
        {
            Test();

            yield return null;
        }

        private void Test()
        {
            if (!isActived)
            {
                Time.timeScale = 0.0f;
                m_image.color = pauseColor;
            }
            else
            {
                Time.timeScale = 1.0f;
                m_image.color = resumeColor;
            }

            isActived = !isActived;
        }

        protected override void Awake()
        {
            base.Awake();
            image.gameObject.SetActive(false);
            m_image = GetComponent<Image>();
            m_image.color = resumeColor;

        }
    }
}