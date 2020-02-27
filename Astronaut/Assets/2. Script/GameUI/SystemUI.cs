using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astronaut.GameUI
{
    [DisallowMultipleComponent]
    public abstract class SystemUI : MonoBehaviour
    {
        protected GameUI m_gameUI;

        // while문으로 되어있는 코루틴은 시작시 실행시켜준다. Update를 이용하지 않아도 된다.
        // while문이 아닌 경우에는 별도의 상황에서 호출
        protected abstract IEnumerator ActiveCoroutine();

        protected virtual void Awake()
        {
            m_gameUI = GetComponentInParent<GameUI>();

            if (m_gameUI == null)
                Debug.LogError("GameUI를 확인해주세요");
        }
    }
}