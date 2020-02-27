using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Astronaut.GameUI
{
    [RequireComponent(typeof(Slider))]
    public class ProgressUI : SystemUI
    {
        [SerializeField] AudioSource musicClip = null;

        private Slider m_Slider;

        protected override IEnumerator ActiveCoroutine()
        {
            while (!GameManager.s_Instance.isFinished)
            {
                if(musicClip.isPlaying)
                {
                    m_Slider.value += (Time.deltaTime * Time.timeScale);

                    if (!GameManager.s_Instance.isMusicFinished
                        && (int)m_Slider.value == (int)m_Slider.maxValue)
                    {
                        GameManager.s_Instance.isMusicFinished = true;
                    }
                    if (Time.timeScale == 0.0f)
                    {
                        musicClip.Pause();
                    }
                }
                else
                {
                    if(Time.timeScale == 1.0f)
                    {
                        musicClip.UnPause();
                    }
                }
                yield return null;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            if(musicClip == null)
            {
                Debug.LogError("ProgressBar : AudioSource가 할당되지 않음");
            }
            m_Slider = GetComponent<Slider>(); m_Slider.maxValue = musicClip.clip.length;
        }

        private void Start()
        {
            m_Slider.maxValue = musicClip.clip.length;
            StartCoroutine(ActiveCoroutine());
        }
    }
}
