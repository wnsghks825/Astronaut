using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Astronaut.GameUI
{
    [CustomEditor(typeof(BarUI))]
    public abstract class BarUIEditor : Editor
    {
        protected BarUI Target;
        protected int maxIndex;
        
        protected virtual void OnEnable()
        {
            Target = (BarUI)target;
        }

        protected virtual void DrawInspector()
        {
            if (!Target.isCreated)
            {
                GUI.enabled = false;
                Target.Index = (byte)EditorGUILayout.IntField("Index", maxIndex);
                GUI.enabled = true;

                if (GUILayout.Button("생성"))
                {
                    CreateButton(Target.Index);
                }
            }
            else
            {
                if (GUILayout.Button("리셋"))
                {
                    ResetButton();
                }
            }
        }

        protected abstract void CreateButton(byte value);

        protected abstract void ResetButton();
    }
}