using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Astronaut.ResultUI
{
    [DisallowMultipleComponent]
    public class TextUI : MonoBehaviour
    {
        private Text m_Text;

        public void WriteText(string str)
        {
            m_Text.text = str;
        }

        private void Awake()
        {
            m_Text = GetComponentInChildren<Text>();
        }
    }
}