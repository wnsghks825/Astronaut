using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(Screen.width, (Screen.width / 9) *16, true); // 2:3 비율로 개발시
        Camera camera = GetComponentInChildren<Camera>();
        camera.orthographicSize = (Screen.height / (Screen.width / 9.0f)) / 16.0f;

    }
}
