using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Astronaut.GameUI
{
    public class FadeInOut : MonoBehaviour
    {
        Image m_image;

        public bool isFadeActived { get; private set; }

        private void Awake()
        {
            m_image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            ImageReset();
        }

        // 이미지의 알파값을 1로 변경시켜주기 위한 함수
        public void ImageReset()
        {
            m_image.color = new Color(m_image.color.r, m_image.color.g, m_image.color.b, 1.0f);
        }

        public IEnumerator Coroutine(float fadeSpeed)
        {
            // Fade In --  나타나는 것
            // Fade Out -- 사라지는 것
            bool isFadeOut = true;

            Color clr = new Color(m_image.color.r, 
                                  m_image.color.g, 
                                  m_image.color.b,
                                  1);

            m_image.color = clr;

            while(true)
            {
                if(isFadeOut)
                {
                    clr.a -= Time.deltaTime * fadeSpeed;
                    m_image.color = clr;
                    if(clr.a < 0.3f)
                    {
                        isFadeOut = false;
                    }
                }
                else
                {
                    clr.a += Time.deltaTime * fadeSpeed;
                    m_image.color = clr;
                    if(clr.a > 1.0f)
                    {
                        isFadeOut = true;
                    }
                }
                
                yield return null;
            }
        }
    }
}