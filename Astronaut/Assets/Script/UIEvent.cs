using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UIEvent : MonoBehaviour
{
    private bool pauseOn = false;

    public void ActivePauseBt()
    {
        if (!pauseOn)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        pauseOn = !pauseOn;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
