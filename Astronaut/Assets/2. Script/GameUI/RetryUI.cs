using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Astronaut.GameUI
{
    [RequireComponent(typeof(Button))]
    public class RetryUI : SystemUI
    {
        protected override IEnumerator ActiveCoroutine()
        {
            yield return null;
        }

        public void RetryHardButton()
        {
            SceneManager.LoadScene("Astronaut_Hard");
            Destroy(GameManager.s_Instance.gameObject);
            Time.timeScale = 1f;
        }

        public void RetryEasyButton()
        {
            SceneManager.LoadScene("Astronaut_Normal");
            Destroy(GameManager.s_Instance.gameObject);
            Time.timeScale = 1f;
        }
    }
}
