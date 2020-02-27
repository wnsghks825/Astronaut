using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bar : MonoBehaviour
{

    public float result;
    Image[] childList;
    Blink[] blink;

    private float timeSpeed = 5f;

    public void Start()
    {
        blink = FindObjectsOfType<Blink>();

    }


    public void PlayerHPbar()
    {
        //float resultPercent;
        childList = GetComponentsInChildren<Image>(true);
        result = Player.Instance.result;
        //Debug.Log(result);
        if (childList != null)
        {

            for (int i = 0; i < childList.Length; i++)
            {

                //인덱스 혹은 스크립트에 아예 다 넣는다?
                if (result <= 1f && result >= 0.9f && childList[i].tag.Contains("100"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.9f && result < 0.91f && childList[i].tag.Contains("100"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                //체력이 90~80
                if (result < .9f && result >= 0.8f && childList[i].tag.Contains("90"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.8f && result < 0.81f && childList[i].tag.Contains("90"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                //체력이 80~70
                if (result < .8f && result >= 0.7f && childList[i].tag.Contains("80"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.7f && result < 0.71f && childList[i].tag.Contains("80"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                //
                if (result < .7f && result >= 0.6f && childList[i].tag.Contains("70"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.6f && result < 0.61f && childList[i].tag.Contains("70"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                //
                if (result < .6f && result >= 0.5f && childList[i].tag.Contains("60"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.5f && result < 0.51f && childList[i].tag.Contains("60"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                if (result < .5f && result >= 0.4f && childList[i].tag.Contains("50"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.4f && result < 0.41f && childList[i].tag.Contains("50"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                if (result < .4f && result >= 0.3f && childList[i].tag.Contains("40"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.3f && result < 0.31f && childList[i].tag.Contains("40"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                if (result < .3f && result >= 0.2f && childList[i].tag.Contains("30"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.2f && result < 0.21f && childList[i].tag.Contains("30"))
                {
                    childList[i].gameObject.SetActive(false);
                }

                if (result < .2f && result >= 0.1 && childList[i].tag.Contains("20"))
                {
                    StartCoroutine(FadeOutText(timeSpeed, childList[i]));
                }
                if (result >= 0.1f && result < 0.11f && childList[i].tag.Contains("20"))
                {
                    childList[i].gameObject.SetActive(false);
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
