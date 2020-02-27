using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astronaut
{
    // 증감형식 열거자
    public enum EVariation { Increase, Decrease }

    public class Player : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private float _maxSkillGauge = 100;
        
        #region Properties
        public float health { get; private set; }
        public float skillGauge { get; private set; }

        public float maxHealth { get => _maxHealth; }
        public float maxSkillGauge { get => _maxSkillGauge; }

        // 0 ~ 1의 값을 갖는다. 0 → 0%, 1 → 100% 
        public float healthPercent { get; private set; }

        public float gaugePercent { get; private set; }
        #endregion


        #region Functions

        // 체력 및 스킬게이지 초기화
        private void Initialize(float health, float skillGauge)
        {
            this.health = health;
            healthPercent = health / maxHealth;

            this.skillGauge = skillGauge;
            gaugePercent = skillGauge / maxSkillGauge;
        }
        
        // 외부에서 체력을 변경 가능하게 하는 함수
        public void ChangeHealth(EVariation variation, float value)
        {
            if(variation == EVariation.Increase)
            {
                health += value;

                // 최대체력을 넘지 않게 한다.
                if (health > maxHealth) health = maxHealth;
            }
            else
            {
                health -= value;

                if (health < 0)
                {
                    health = 0.0f;
                    GameManager.ChangeSceneToResult();
                }

            }

            healthPercent = health / maxHealth;
        }

        // 외부에서 게이지를 변경 가능하게 하는 함수
        public void ChangeGauge(EVariation variation, float value)
        {
            if (variation == EVariation.Increase)
            {
                skillGauge += value;

                if (skillGauge > maxSkillGauge) skillGauge = maxSkillGauge;
            }
            else
            {
                skillGauge -= value;

                if (skillGauge < 0) skillGauge = 0.0f;
            }

            gaugePercent = skillGauge / maxSkillGauge;
        }

        #endregion

        private int read;

        private void Awake()
        {
            // 게임시작시 체력 및 스킬게이지 초기화
            Initialize(100, 0.0f);
        }

        // 테스트용
        private void Update()
        {


            if (Time.timeScale == 1.0f)
            {
                if (GameManager.s_Instance.isMusicFinished == true)
                    ChangeHealth(EVariation.Decrease, 0.00f);
                else
                    ChangeHealth(EVariation.Decrease, 0.05f);
                //ChangeGauge(EVariation.Increase, 0.5f);
            }
        }
    }
}