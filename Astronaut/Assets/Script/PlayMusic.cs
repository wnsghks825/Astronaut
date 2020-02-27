using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioClip audioclip;
    AudioSource audiosource;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Music")
        {
            GameObject.Find("Savage").GetComponent<AudioSource>().Play();
            audioclip = GameObject.Find("Savage").GetComponent<AudioSource>().clip;
            //Debug.Log(audioclip.length);
        }
    }

    void PlaySound(string snd)
    {
        GameObject.Find(snd).GetComponent<AudioSource>().Play();
    }


}
