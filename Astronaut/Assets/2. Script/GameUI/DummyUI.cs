using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astronaut.GameUI
{
    public class DummyUI :SystemUI
    {
        protected override IEnumerator ActiveCoroutine()
        {
            yield return null;
        }
    }
}
