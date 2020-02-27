using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Astronaut.GameUI
{
    public class SkillGaugeUI : BarUI
    {
        [SerializeField] Button m_SkillTouchButton = null;
        
        /// 스킬버튼 클릭시 발생하는 함수
        /// m_SkillTouchButton Button컴포넌트 OnClick을 연결
        /// 클릭했을때 발생할 이벤트 로직은 여기다가 구현해준다.
        public void ClickSkillButton()
        {
            // 테스트용
            Debug.Log("스킬버튼클릭");


            if (Time.timeScale == 0)
            {

            }
            else
            {
                SkillButtonSetActive(EActiveType.Off);
                GameManager.s_Instance.player.ChangeGauge(EVariation.Decrease, 100);
                Skill skill = GameObject.Find("Player").GetComponent<Skill>();
                skill.SkillFire();
            }

        }

        // SystemUI 추상메서드 구현부
        protected override IEnumerator ActiveCoroutine()
        {
            while (!GameManager.s_Instance.isFinished)
            {
                var cntPercent = GameManager.s_Instance.player.gaugePercent;

                CheckPercent(cntPercent);

                if( !m_SkillTouchButton.gameObject.activeSelf && cntPercent == 1.0f)
                {
                    SkillButtonSetActive(EActiveType.On);
                }

                yield return null;
            }
        }

        // BarUI 추상메서드 구현부
        protected override void Initialize()
        {
            int skillPerUnit = (int)(GameManager.s_Instance.player.maxSkillGauge / Index);
            percentPerUnit = skillPerUnit / GameManager.s_Instance.player.maxSkillGauge; // 0.2f
            
            float temp = GameManager.s_Instance.player.gaugePercent / percentPerUnit;
            cnt_Index = (int)temp;

            for (int i = 0; i < cnt_Index; i++)
            {
                RightBars[i].Active(EActiveType.On);
                LeftBars[i].Active(EActiveType.On);
            }
        }

        /// 스킬버튼 활성화 담당
        private void SkillButtonSetActive(EActiveType type)
        {
            m_SkillTouchButton.gameObject.SetActive(
                (type == EActiveType.On) ? true : false );
        }

        protected override void Awake()
        {
            base.Awake();
            SkillButtonSetActive(EActiveType.Off);
        }
        protected override void Start()
        {
            base.Start();

            StartCoroutine("ActiveCoroutine");
        }
    }
}
