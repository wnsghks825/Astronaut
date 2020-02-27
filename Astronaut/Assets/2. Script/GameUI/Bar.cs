using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astronaut.GameUI
{
    public enum EActiveType { On, Off }

    [RequireComponent(typeof(FadeInOut))]
    public class Bar : MonoBehaviour
    {
        static float fadeSpeed = 2.0f;

        public bool isActived { get; private set; } //현재 사용x

        public FadeInOut fadeInOut { get; private set; }

        // 페이드코루틴
        Coroutine m_FadeCoroutine = null;
        
        private void Awake()
        {
            fadeInOut = GetComponent<FadeInOut>();
            // 시작시 Active Off
            Active(EActiveType.Off);
        }


        public void Active(EActiveType type)
        {
            if (type == EActiveType.Off)
            {
                // 현재 돌아가고 있는 코루틴이있다면 작동을 멈춰준다.
                if (m_FadeCoroutine != null)
                    StopCoroutine(m_FadeCoroutine);
            }

            isActived = (type == EActiveType.On) ? true : false ;
            gameObject.SetActive((type == EActiveType.On) ? true : false);
        }

        public void FadeActive(EActiveType type)
        {
            if (type == EActiveType.On)
            {
                if (m_FadeCoroutine == null)
                    m_FadeCoroutine = StartCoroutine(fadeInOut.Coroutine(fadeSpeed));
            }
            else
            {
                fadeInOut.ImageReset();

                if(m_FadeCoroutine != null)
                {
                    StopCoroutine(m_FadeCoroutine);
                    m_FadeCoroutine = null;
                }
            }
        }
    }
}