using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Astronaut.GameUI
{
    [CustomEditor(typeof(HealthUI))]
    public class HealthUIEditor : BarUIEditor
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            maxIndex = 10;
        }

        public override void OnInspectorGUI()
        {
            DrawInspector();
        }

        // 생성버튼 클릭
        protected override void CreateButton(byte value)
        {

            Target.isCreated = true;

            // Prefab 생성
            for (byte i = 0; i < value; i++)
            {
                // Right Prefab
                GameObject go = Instantiate(Target.RightPrefab);
                go.name = "Health_Right_Bar_"+i;
                go.transform.SetParent(Target.transform);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = new Vector3(84.0f + i * 26, -42, 0);

                Target.RightBars.Add(go.AddComponent<Bar>());

                // Left Prefab
                go = Instantiate(Target.LeftPrefab);
                go.name = "Health_Left_Bar_" + i;
                go.transform.SetParent(Target.transform);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = new Vector3(-84.0f - i * 26, -42, 0);

                Target.LeftBars.Add(go.AddComponent<Bar>());
            }
        }

        // 리셋버튼 클릭
        protected override void ResetButton()
        {
            Target.isCreated = false;

            for (byte i = 0; i < Target.Index; i++)
            {
                var bar = Target.RightBars[0];
                Target.RightBars.RemoveAt(0);
                DestroyImmediate(bar.gameObject);

                bar = Target.LeftBars[0];
                Target.LeftBars.RemoveAt(0);
                DestroyImmediate(bar.gameObject);
            }
        }
    }
}