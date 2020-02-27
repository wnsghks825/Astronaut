using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace Astronaut.GameUI
{
    [RequireComponent(typeof(Button))]
    public class ResumeUI : SystemUI
    {
        public Image image;
        public Image m_image;
        SystemUI[] GameUIs;
        [SerializeField] Color pauseColor = Color.white;
        [SerializeField] Color resumeColor = Color.white;
        private bool isActived;

        // Start is called before the first frame update
        void Start()
        {

        }
        public void ClickResumeButton()
        {
            m_gameUI.PausedButtonSetActive(EActiveType.On);
            image.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }

        private void Test()
        {
            Time.timeScale = 1.0f;
            m_image.color = Color.white;
        }

        protected override void Awake()
        {
            base.Awake();
            GameUIs = GetComponentsInParent<SystemUI>();
        }


        protected override IEnumerator ActiveCoroutine()
        {
            yield return 0;
        }
    }
}
