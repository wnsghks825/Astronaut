using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Progressbar : MonoBehaviour
{
    AudioSource audioclip;
    public Slider progressbar;

    // Start is called before the first frame update
    void Start()
    {
        audioclip = GameObject.Find("Savage").GetComponent<AudioSource>();
        Debug.Log(audioclip.clip.length);
        //        content = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            audioclip.Pause();
        }
        if (Time.timeScale == 1)
        {
            audioclip.UnPause();
        }
        if (GameObject.Find("Savage").GetComponent<AudioSource>().isPlaying)
        {
            progressbar.maxValue = audioclip.clip.length;
            progressbar.value += (Time.deltaTime * Time.timeScale);
        }
    }
    
}
