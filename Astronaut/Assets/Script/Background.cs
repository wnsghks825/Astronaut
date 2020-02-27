using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
/*

    public GameObject quadGameObject;
    public MeshRenderer quadRenderer;
    public MeshRenderer quadRenderer1;

    float scrollSpeed = 0.5f;
    private float noteTime;

    public Material[] materials;
    public float changeInterval = 0.33F;
    public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        quadRenderer = GameObject.Find("Quad").GetComponent<MeshRenderer>();
        quadRenderer1 = GameObject.Find("Quad (1)").GetComponent<MeshRenderer>();
        //StartCoroutine("FadeIn");
        rend = GetComponent<Renderer>();
        rend.enabled = true;


    }
    
    // Update is called once per frame
    void Update()
    {
        //ChangeMaterial();
        noteTime += Time.deltaTime;
        Vector2 textureOffset = new Vector2(0, Time.time);
        quadRenderer.material.mainTextureOffset = textureOffset;
        Vector2 textureOffset1 = new Vector2(0, Time.time);
        quadRenderer1.material.mainTextureOffset = textureOffset1;
        FadeOutFunction();
        if (quadRenderer1.material.color.a == 0)
        {
            Debug.Log("Debug");
        }
        //FadeInFunction();
    }

    public void ChangeMaterial()
    {
        if (materials.Length == 0)
            return;

        // we want this material index now
        int index = Mathf.FloorToInt(Time.time / changeInterval);
        Debug.Log(index);
        // take a modulo with materials count so that animation repeats
        index = index % materials.Length;

        // assign it to the renderer
        rend.sharedMaterial = materials[index];
    }
    IEnumerator FadeIn()
    {
        for (float i = 1f; i >= 0f; i -= 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            quadRenderer1.material.color = color;
            yield return 0;
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            quadRenderer.material.color = color;
            yield return 0;
        }
    }
    public void FadeOutFunction()
    {
         
        if (quadRenderer.material.name == "Background1 (Instance)")
        {
  
            StartCoroutine("FadeOut");
            StartCoroutine("FadeIn");

            if (quadRenderer1.material.color.a == 0.0f)
            {
                
                StopCoroutine("FadeIn");
                Destroy(quadRenderer1);
            }

        }
    }
    */


}
