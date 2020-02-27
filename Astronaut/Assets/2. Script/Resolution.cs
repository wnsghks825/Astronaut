using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true); // 16:9 로 개발시
        Screen.SetResolution(1080,1920,true);
    }
}
