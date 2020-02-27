using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeResult : MonoBehaviour
{
    [SerializeField] float m_delayTime = 4.0f;

    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay());
    }

    IEnumerator LoadLevelAfterDelay(float delay = 0.0f)
    {
        var refGameMgr = GameManager.s_Instance;
        float flowTime = 0.0f;

        while (true)
        {
            if (refGameMgr.isMusicFinished)
            {
                flowTime += Time.deltaTime;

                if (flowTime > m_delayTime)
                {
                    break;
                }
            }
            yield return null;

        }

        GameManager.ChangeSceneToResult();
    }
}
