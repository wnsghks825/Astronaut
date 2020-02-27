using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject quadGameObject;
    MeshRenderer[] quad;
    MeshRenderer quadRenderer;
    MeshRenderer quadRenderer1;
    MeshRenderer quadRenderer2;
    float scrollSpeed = 2.5f;
    private float noteTime;


    // Start is called before the first frame update
    void Start()
    {
        quadRenderer = GameObject.Find("Quad").GetComponent<MeshRenderer>();
        quadRenderer1 = GameObject.Find("Quad (1)").GetComponent<MeshRenderer>();
        quadRenderer2 = GameObject.Find("Quad (2)").GetComponent<MeshRenderer>();
        quad = GetComponentsInChildren<MeshRenderer>(true);
    }

    // Update is called once per frame
    void Update()
    {
        noteTime += Time.deltaTime;
        Vector2 textureOffset = new Vector2(0, Time.time);
        quadRenderer.material.mainTextureOffset = textureOffset;
        quadRenderer1.material.mainTextureOffset = textureOffset;
        quadRenderer2.material.mainTextureOffset = textureOffset;

    }
    public void FadeOutBackground1()
    {
        StopCoroutine("FadeOut1");
        StartCoroutine("FadeOut");
    }
    public void FadeOutBackground2()
    {
        StopCoroutine("FadeOut");
        StartCoroutine("FadeOut1");
    }
    public IEnumerator FadeOut()
    {

        // Fade In --  나타나는 것
        // Fade Out -- 사라지는 것

        Color clr = new Color(1,1,1,1);
        Color col = new Color(1, 1, 1, 0);

        while (true)
        {

            clr.a -= Time.deltaTime * scrollSpeed;
            quadRenderer.material.color = clr;
            //Debug.Log("mouse Down");
            quadRenderer1.material.color = col;
            col.a += Time.deltaTime * scrollSpeed;
            if (clr.a < 0.0f)
            {
                clr.a = 0f;
            }
            if (col.a > 1.0f)
            {
                col.a = 1f;
            }
            yield return null;
        }

    }
    public IEnumerator FadeOut1()
    {

        // Fade In --  나타나는 것
        // Fade Out -- 사라지는 것
        
            Color clr = new Color(1, 1, 1, 0);
            Color col = new Color(1, 1, 1, 1);

        while (true)
        {

            if (quadRenderer.material.color.a == 1f)
            {
                Debug.Log("mouse Down");
                quadRenderer2.material.color = clr;
                quadRenderer2.material.color = clr;
                quadRenderer.material.color = col;
            clr.a += Time.deltaTime * scrollSpeed;
            col.a -= Time.deltaTime * scrollSpeed;
                if (col.a < 0.0f)
                {
                    col.a = 0f;
                }
                if (clr.a > 1.0f)
                {
                    clr.a = 1f;
                }
                Debug.Log(clr);
            }

                clr.a += Time.deltaTime * scrollSpeed;
                quadRenderer2.material.color = clr;
                //quadRenderer.material.color = col;
                quadRenderer1.material.color = col;
                col.a -= Time.deltaTime * scrollSpeed;
                if (col.a < 0.0f)
                {
                    col.a = 0f;
                }
                if (clr.a > 1.0f)
                {
                    clr.a = 1f;
                }
            yield return null;
        }

    }

    IEnumerator FadeInF()
    {
        for (float i = 1f; i >= 0f; i -= 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            quadRenderer1.material.color = color;
            yield return 0;
        }
    }

    IEnumerator FadeOutF()
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            quadRenderer.material.color = color;
            yield return 0;
        }
    }
}
