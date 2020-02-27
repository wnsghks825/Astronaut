using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astronaut.GameUI
{
    public class HealthUI : BarUI
    {
        protected override IEnumerator ActiveCoroutine()
        {
            while (!GameManager.s_Instance.isFinished)
            {
                var cntPercent = GameManager.s_Instance.player.healthPercent;

                CheckPercent(cntPercent);

                if(cntPercent <= cnt_Index * percentPerUnit)
                {
                    Debug.Log("게임종료");
                    break;
                }
                //Debug.Log("게임종료");
                yield return null;
            }
        }

        protected override void Initialize()
        {
            int healthPerUnit = (int)(GameManager.s_Instance.player.maxHealth / Index);
            percentPerUnit = healthPerUnit / GameManager.s_Instance.player.maxHealth; // 0.1f

            float temp = GameManager.s_Instance.player.healthPercent / percentPerUnit;
            cnt_Index = (int)temp;

            for(int i = 0; i < cnt_Index; i++)
            {
                RightBars[i].Active(EActiveType.On);
                LeftBars[i].Active(EActiveType.On);
            }
        }

    }
}