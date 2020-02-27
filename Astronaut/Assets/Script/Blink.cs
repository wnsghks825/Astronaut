using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blink : MonoBehaviour
{
    [SerializeField] private Image imageToUse;
    [SerializeField] public bool useThisImage = false;
    [Tooltip("false - Fades Out, true = Fades In")]
    [SerializeField] public bool fadeIn = false;
    [SerializeField] public bool fadeOnStart = false;
    [SerializeField] private float timeMultiplier;

    private IEnumerator coroutine;

    private void Start()
    {
        if (useThisImage)
        {
            imageToUse = GetComponent<Image>();
        }
        coroutine = FadeOutText(timeMultiplier, imageToUse);
        if (fadeOnStart)
        {

            if (fadeIn)
            {
                StartCoroutine(FadeInText(timeMultiplier, imageToUse));

            }
            else
            {
                StartCoroutine(FadeOutText(timeMultiplier, imageToUse));
            }

        }

    }

    private void Update()
    {
        if (imageToUse==null)
        {
            //StopCoroutine(coroutine);
        }
    }

    private IEnumerator FadeInText(float timeSpeed, Image text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.3f);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.3f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
    private IEnumerator FadeOutText(float timeSpeed, Image text)
    {
        if (text == null)
        {
            StopCoroutine(coroutine);
        }
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

            //yield return new WaitForSeconds(0.01f);

        }

    }
    public void FadeInText(float timeSpeed = -1.0f)
    {
        if (timeSpeed <= 0.0f)
        {
            timeSpeed = timeMultiplier;
        }
        StartCoroutine(FadeInText(timeSpeed, imageToUse));
    }
    public void FadeOutText(float timeSpeed = -1.0f)
    {
        if (timeSpeed <= 0.0f)
        {
            timeSpeed = timeMultiplier;
        }

        StartCoroutine(FadeOutText(timeSpeed, imageToUse));

    }
}
