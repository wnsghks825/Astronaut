using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectUI : MonoBehaviour
{

    public void HardButton()
    {
        SceneManager.LoadScene("Astronaut_Hard");
        Time.timeScale = 1f;
    }

    public void EasyButton()
    {
        SceneManager.LoadScene("Astronaut_Normal");
        Time.timeScale = 1f;
    }
}
