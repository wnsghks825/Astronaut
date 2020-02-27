using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Astronaut.ResultUI
{
    [DisallowMultipleComponent]
    public class GradeUI : MonoBehaviour
    {
        private Image m_Image;

        public void SetSprite(Sprite sprite)
        {
            m_Image.sprite = sprite;
        }

        private void Awake()
        {
            m_Image = GetComponent<Image>();
        }
    }
}