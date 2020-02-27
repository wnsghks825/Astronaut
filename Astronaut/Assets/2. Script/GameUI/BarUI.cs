using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astronaut.GameUI
{
    public abstract class BarUI : SystemUI
    {
        #region Editor
        public byte Index;
        
        public bool isCreated = false;

        public GameObject RightPrefab;
        public GameObject LeftPrefab;
        #endregion

        // [SerializeField]를 포함하지 않으면 시작시 초기화된다.
        [SerializeField] private List<Bar> m_RightBars = new List<Bar>();
        [SerializeField] private List<Bar> m_LeftBars = new List<Bar>();
        
        // 배열을 가리키는 현재 인덱스
        protected int cnt_Index = -1;

        protected float percentPerUnit;

        public List<Bar> RightBars { get { return m_RightBars; } }
        public List<Bar> LeftBars { get { return m_LeftBars; } }

        /// <summary>
        /// 초기화 
        /// </summary>
        protected abstract void Initialize();
        
        // 퍼센트에 따라 체력 혹은 스킬 게이지 관련 메서드
        protected virtual void CheckPercent(float cntPercent)
        {
            // 증가했는지 판별,
            if (cnt_Index < Index - 1)
            {
                if (cnt_Index == 0)
                {
                    if (cntPercent > (cnt_Index) * percentPerUnit)
                    {
                        RightBars[cnt_Index].Active(EActiveType.On);
                        LeftBars[cnt_Index].Active(EActiveType.On);

                        RightBars[cnt_Index].FadeActive(EActiveType.On);
                        LeftBars[cnt_Index].FadeActive(EActiveType.On);
                    }
                }

                /// 현재% 가 (cnt_index + 1) * % 가 높아지면
                /// cnt_Index의 배열 페이드작동을 Off
                /// cnt_Index+1의 배열 SetActive(true);
                if (cntPercent > (cnt_Index + 1) * percentPerUnit)
                {
                    RightBars[cnt_Index].FadeActive(EActiveType.Off);
                    LeftBars[cnt_Index].FadeActive(EActiveType.Off);

                    RightBars[++cnt_Index].Active(EActiveType.On);
                    LeftBars[cnt_Index].Active(EActiveType.On);

                    RightBars[cnt_Index].FadeActive(EActiveType.On);
                    LeftBars[cnt_Index].FadeActive(EActiveType.On);
                }
            }
            // 최대 인덱스가 됐을 때,
            else if (cnt_Index == Index - 1)
            {
                if (cntPercent >= (int)((cnt_Index + 1) * percentPerUnit))
                {
                    RightBars[cnt_Index].FadeActive(EActiveType.Off);
                    LeftBars[cnt_Index].FadeActive(EActiveType.Off);
                }
            }

            // 감소됐는지 판별
            if (cnt_Index > 0)
            {
                /// 현재% 가 cnt_index * %보다 낮아지면
                /// cnt_Index의 배열 SetActive(false)
                /// cnt_Index-1의 배열 페이드작동을 ON
                if (cntPercent < cnt_Index * percentPerUnit)
                {
                    if (cnt_Index != Index)
                    {
                        RightBars[cnt_Index].Active(EActiveType.Off);
                        LeftBars[cnt_Index].Active(EActiveType.Off);
                    }

                    RightBars[--cnt_Index].FadeActive(EActiveType.On);
                    LeftBars[cnt_Index].FadeActive(EActiveType.On);
                }
            }
            else
            {
                if (cntPercent <= cnt_Index * percentPerUnit)
                {
                    RightBars[cnt_Index].Active(EActiveType.Off);
                    LeftBars[cnt_Index].Active(EActiveType.Off);
                }
            }
        }

        // 유연성을 주기 위해 템플릿 메서드 패턴 방식 이용
        protected virtual void Start()
        {
            Initialize();
            
            StartCoroutine(ActiveCoroutine());
        }

    }
}
