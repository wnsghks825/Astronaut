using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Astronaut
{
    [DisallowMultipleComponent]
    public class BackGround : MonoBehaviour
    {
        private List<Material> Mats = new List<Material>();

        [SerializeField] MeshRenderer Front;    // 현재 보여주고 있는 이미지, 페이드아웃만 한다.
        [SerializeField] MeshRenderer Back;     // 뒤에 있는 이미지, 페이드인만 한다.

        [Header("시작 인덱스")] [SerializeField] private int m_startidx;
        [Header("페이드 속도")] [SerializeField] float m_fadeSpeed;

        private int cntIdx;                     // 현재보여지고 있는 Mat인덱스 
        private bool isChanging;

        public void ChangeBackGround(int dstIdx)
        {
            if (cntIdx == dstIdx)
                return;

            if (!isChanging)
            {
                isChanging = true;
                StartCoroutine(SwapBufferCoroutine(dstIdx));
            }
        }

        private void Initialize()
        {
            cntIdx = m_startidx;

            if (Front == null || Back == null)
                Debug.Log("BackGround MeshRenderer 할당 문제 발생");

            // 머터리얼을 런타임에서 변경하려면 Resources..이용해야한다?
            Material[] mats = Resources.LoadAll<Material>("Materials");

            for (int i = 0; i < mats.Length; i++)
            {
                Mats.Add(new Material(mats[i]));
            }

            if (Mats.Count <= m_startidx)
                Debug.Log("BackGround StartIdx 문제 발생 Resources/Materials를 확인");

            Front.material = Mats[m_startidx];

            for (int i = 0; i < Mats.Count; i++)
            {
                if (m_startidx != i)
                    Mats[i].color = new Color(Mats[i].color.r, Mats[i].color.g, Mats[i].color.b, 0);
                else
                    Mats[i].color = new Color(Mats[i].color.r, Mats[i].color.g, Mats[i].color.b, 1);
            }
        }

        /// <summary>
        /// 참조하고 있던 Material의 Color의 알파값을 1로 되돌린다.
        /// OnDestroy 이벤트함수에서 호출
        /// </summary>
        private void SetBackMatColor()
        {
            for (int i = 0; i < Mats.Count; i++)
            {
                Mats[i].color = new Color(1, 1, 1, 1);
            }
        }


        IEnumerator SwapBufferCoroutine(int dstIdx)
        {
            var FrontMat = Front.material;
            Color fadeOut = FrontMat.color;

            Back.material = Mats[dstIdx];   // dstIdx를 이용해 Back Renderer에 대입
            var BackMat = Back.material;
            Color fadeIn = BackMat.color;

            while (true)
            {
                fadeOut.a -= Time.deltaTime * m_fadeSpeed;
                FrontMat.color = fadeOut;
                if (fadeOut.a < 0.0f)
                    fadeOut.a = 0.0f;

                fadeIn.a += Time.deltaTime * m_fadeSpeed;
                BackMat.color = fadeIn;
                if (fadeIn.a > 1.0f)
                    fadeIn.a = 1.0f;

                if (fadeOut.a == 0.0f && fadeIn.a == 1.0f)
                {
                    // Front, Back  Swap
                    var temp = Front;
                    Front = Back;
                    Back = temp;

                    isChanging = false;
                    cntIdx = dstIdx;

                    yield break;
                }
                yield return null;
            }
        }

        private void Awake()
        {
            Initialize();
        }

        // 머터리얼의 TextureOffset을 변화를 줌으로써 배경이 움직이는 효과를 나타낸다.
        private void Update()
        {
            var mat = Front.material;
            if (mat.color.a > 0)
                mat.mainTextureOffset = new Vector2(0, Time.time);

            mat = Back.material;
            if (mat.color.a > 0)
                mat.mainTextureOffset = new Vector2(0, Time.time);
        }

        private void OnDestroy()
        {
            SetBackMatColor();
        }
    }
}