using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGauge : MonoBehaviour
{

    Image[] childList;
    public Image SkillEvent;
    private float timeSpeed = 5f;
    private IEnumerator coroutine;

    public void Start()
    {
        childList = GetComponentsInChildren<Image>(true);
        Debug.Log(SkillEvent);
        SkillEvent.gameObject.SetActive(false);
        for (int i = 0; i < childList.Length; i++)
        {
            coroutine = FadeOutText(timeSpeed, childList[i]);
            childList[i].gameObject.SetActive(false);
        }
    }

    public void PlayerHPbar()
    {
        //gauge += 0.001f;

        if(Player.Instance.gauge > 1f)
        {
            SkillEvent.gameObject.SetActive(true);
            Player.Instance.gauge = 0;
        }

        if (childList != null)
        {
 
            for (int i = 0; i < childList.Length; i++)
            {
                /*
                //인덱스 혹은 스크립트에 아예 다 넣는다?
                if (gauge <= 1f && gauge >= 0.9f && childList[i].tag.Contains("100"))
                {
                    StopAllCoroutines();
                    childList[i].color = new Color(1, 1, 1, 1);
                    childList[i].gameObject.SetActive(true);
                }
                */
                //체력이 90~80
                if (Player.Instance.gauge == 1.0f)
                {

                }
                if (Player.Instance.gauge >= 0.9f && Player.Instance.gauge < 0.91f && childList[i].tag.Contains("60"))
                {
                    //StopAllCoroutines();
                    childList[i].color = new Color(1, 1, 1, 1);
                    childList[i].gameObject.SetActive(true);
                }
                if (Player.Instance.gauge < .9f && Player.Instance.gauge >= 0.8f && childList[i].tag.Contains("60"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                    childList[i].gameObject.SetActive(true);
                }


                //체력이 80~70
                if (Player.Instance.gauge >= 0.8f && Player.Instance.gauge < 0.81f && childList[i].tag.Contains("50"))
                {
                    StopAllCoroutines();
                    childList[i].color = new Color(1, 1, 1, 1);
                    childList[i].gameObject.SetActive(true);
                }
                if (Player.Instance.gauge < .8f && Player.Instance.gauge >= 0.6f && childList[i].tag.Contains("50"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                    childList[i].gameObject.SetActive(true);
                }

                //
                if (Player.Instance.gauge >= 0.6f && Player.Instance.gauge < 0.61f && childList[i].tag.Contains("40"))
                {
                    StopAllCoroutines();
                    childList[i].color = new Color(1, 1, 1, 1);
                    childList[i].gameObject.SetActive(true);
                }
                if (Player.Instance.gauge < .6f && Player.Instance.gauge >= 0.4f && childList[i].tag.Contains("40"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                    childList[i].gameObject.SetActive(true);
                }


                //
                if (Player.Instance.gauge >= 0.4f && Player.Instance.gauge < 0.41f && childList[i].tag.Contains("30"))
                {
                    StopAllCoroutines();
                    childList[i].color = new Color(1, 1, 1, 1);
                    childList[i].gameObject.SetActive(true);
                }
                if (Player.Instance.gauge < .4f && Player.Instance.gauge >= 0.2f && childList[i].tag.Contains("30"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                    childList[i].gameObject.SetActive(true);
                }


                //
                if (Player.Instance.gauge >= 0.2f && Player.Instance.gauge < 0.21f && childList[i].tag.Contains("20"))
                {
                    StopAllCoroutines();
                    childList[i].color = new Color(1, 1, 1, 1);
                    childList[i].gameObject.SetActive(true);
                }
                if (Player.Instance.gauge < .2f && Player.Instance.gauge > 0.0f && childList[i].tag.Contains("20"))
                {
                    //SkillEvent.gameObject.SetActive(false);
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                    childList[i].gameObject.SetActive(true);
                }

            }

        }
    }
    private void Update()
    {
        PlayerHPbar();
    }

    private IEnumerator FadeOutText(float timeSpeed, Image text)
    {
        while (true)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            while (text.color.a > 0.3f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
                yield return null;
            }

            //text.color = new Color(text.color.r, text.color.g, text.color.b, 0.3f);
            while (text.color.a < 1.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
                yield return null;
            }

            //yield return new WaitForSeconds(0.1f);
        }

    }

}
