using System.Collections;
using System.Collections.Generic;
using Utilities;
using UnityEngine;
using UnityEngine.UI;
// 결과창 관리해주기 위해 냅둠. 지금은 필요없
namespace Astronaut.GameUI
{
    /// <summary>
    /// SystemUI를 상속받아서 구현된 개체들은 GameUI를 참조하고 있음.
    /// Font Sprite정보를 여기에 접근해서 이용
    /// </summary>
    public class GameUI : Singleton<GameUI>
    {
        // 숫자 Font 정보를 캐싱해두기 위한 리스트
        [SerializeField] List<Sprite> m_NumberSpriteList;

        // 캐싱한 정보를 접근할 수 있는 getter
        public List<Sprite> Number { get => m_NumberSpriteList; }
        public SystemUI[] GameUIs;
        protected override void Awake()
        {
            base.Awake();
            
            if (Number.Count < 10)
                Debug.LogError("GameUI 숫자리스트를 확인해주세요");

            GameUIs = GetComponentsInChildren<SystemUI>();

        }
        public void PausedButtonSetActive(EActiveType type)
        {
            for(int i = 0; i < GameUIs.Length; i++)
            {
                GameUIs[i].gameObject.SetActive(
                    (type == EActiveType.On) ? true : false);
                
            }

        }
    }
}