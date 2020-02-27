using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Astronaut.GameUI
{
    public class PercentUI : SystemUI
    {
        // [0]백의자리 [1]십의자리 [2]일의자리 [3]십분의일의자리 [4]백분의일의자리
        List<Image> PercentNumber = new List<Image>();

        // while문을 이용하는 코루틴
        protected override IEnumerator ActiveCoroutine()
        {
            var refGameMgr = GameManager.s_Instance;

            while (!GameManager.s_Instance.isFinished)
            {
                ShowPercent(refGameMgr.score / refGameMgr.noteMgr.CanObtain.Count);
                
                yield return null;
            }
        }

        private void ShowPercent(float scoreRatio)
        {
            float tempPercent = scoreRatio * 100;
            
            //    0.1   0.01  0.001   0.0001
            int tens, unit, tenths, hundredths;

            if(tempPercent == 100)
            {
                if (!PercentNumber[0].enabled)
                    PercentNumber[0].enabled = true;

                ChangePercentImage(0, (int)scoreRatio);

                tens = unit = tenths = hundredths = 0;
            }
            else
            {
                tens = (int)(tempPercent / 10);
                tempPercent -= tens * 10;

                unit = (int)(tempPercent / 1);
                tempPercent -= unit * 1;

                tenths = (int)(tempPercent / 0.1f);
                tempPercent -= tenths * 0.1f;

                hundredths = (int)(tempPercent / 0.01f);
            }

            ChangePercentImage(1, tens);
            ChangePercentImage(2, unit);
            ChangePercentImage(3, tenths);
            ChangePercentImage(4, hundredths);
        }

        /// <summary>
        /// 노드획득 퍼센트 스프라이트 변경
        /// </summary>
        /// <param name="percentIdx"> 변경할 인덱스 </param>
        /// <param name="srcIdx"> 원본 스프라이트 인덱스</param>
        private void ChangePercentImage(int percentIdx, int srcIdx)
        {
            var refSprite = m_gameUI.Number[srcIdx];

            if (PercentNumber[percentIdx].sprite != refSprite)
                PercentNumber[percentIdx].sprite = refSprite;
        }

        private void Initialize()
        {
            for (int i = 0; i < PercentNumber.Count; i++)
            {
                ChangePercentImage(i, 0);

                if ( i != 0 )
                {
                    if (!PercentNumber[i].enabled)
                        PercentNumber[i].enabled = true;
                }
                else
                {
                    // 백의자리는 비활성화
                    if (PercentNumber[i].enabled)
                        PercentNumber[i].enabled = false;
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();

            Image[] images = GetComponentsInChildren<Image>();

            foreach (var image in images)
            {
                if(image.gameObject.CompareTag("Percent"))
                    PercentNumber.Add(image);
            }

            if (PercentNumber.Count != 5)
                Debug.LogError("PercentUI를 확인해주세요");
            else
            {
                Initialize();
            }
        }

        private void Start()
        {
            StartCoroutine(ActiveCoroutine());
        }

    }
}