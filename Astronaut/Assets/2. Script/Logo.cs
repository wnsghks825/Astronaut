using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    Text text;
    public IEnumerator Coroutine(float fadeSpeed)
    {
        // Fade In --  나타나는 것
        // Fade Out -- 사라지는 것
        bool isFadeOut = true;

        Color clr = new Color(text.color.r,
                              text.color.g,
                              text.color.b,
                              1);

        text.color = clr;

        while (true)
        {
            if (isFadeOut)
            {
                clr.a -= Time.deltaTime * fadeSpeed;
                text.color = clr;
                if (clr.a < 0.3f)
                {
                    isFadeOut = false;
                }
            }
            else
            {
                clr.a += Time.deltaTime * fadeSpeed;
                text.color = clr;
                if (clr.a > 1.0f)
                {
                    isFadeOut = true;
                }
            }

            yield return null;
        }
    }
    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Coroutine(2.0f));
    }
}
