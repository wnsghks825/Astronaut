using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astronaut {

    [DisallowMultipleComponent]
    public class ObtainNote : MonoBehaviour
    {
        [SerializeField] GameObject NoteExplosion = null;
        [SerializeField] GameObject MiniExplosion = null;
        [SerializeField] GameObject EffectExplosion = null;
        [SerializeField] GameObject ObstacleExplosion = null;

        [SerializeField] float HealthRecovery = 0.0f;
        [SerializeField] float SkillGaugeRise = 0.0f;
        [SerializeField] float ObstacleDamage = 0.0f;

        Background background;
        [SerializeField] BackGround test; //테스트용

        /// <summary>
        /// MonoBehaviour 이벤트함수
        /// </summary>
        private void Reset()
        {
            gameObject.layer = LayerMask.NameToLayer("NodeAcquirement");
        }

        /// Physics에서 Layer에서 Node, NodeAcquirement를 추가한 후에 둘끼리만 충돌 상호작용을 체크해준다.
        private void OnTriggerEnter(Collider other)
        {
            // Node들만 충돌을 하므로 Tag만 비교해서 파티클오브젝트를 다르게 생성해준다.

            var refGameMgr = GameManager.s_Instance;

            GameObject obj = null;

            if (other.gameObject.CompareTag("NodeType1"))
            {
                obj = Instantiate(NoteExplosion, new Vector3(other.transform.position.x, -3.7f, -1.5f), Quaternion.identity);
                refGameMgr.player.ChangeHealth(EVariation.Increase, 2);
                refGameMgr.player.ChangeGauge(EVariation.Increase, 3);
                refGameMgr.score++;
                refGameMgr.normalScore++;
            }
            else if (other.gameObject.CompareTag("NodeType2"))
            {
                obj = Instantiate(MiniExplosion, new Vector3(other.transform.position.x, -3.7f, -1.5f), Quaternion.identity);
                refGameMgr.player.ChangeHealth(EVariation.Increase, 1);
                refGameMgr.player.ChangeGauge(EVariation.Increase, 1);
                refGameMgr.score++;
                refGameMgr.miniScore++;
            }

            else if (other.gameObject.CompareTag("NodeType3"))
            {
                obj = Instantiate(EffectExplosion, new Vector3(other.transform.position.x, -3.7f, -1.5f), Quaternion.identity);
                refGameMgr.player.ChangeHealth(EVariation.Increase, 10);
                refGameMgr.player.ChangeGauge(EVariation.Increase, 10);
                refGameMgr.score++;
                refGameMgr.effectScore++;
            }

            else if (other.gameObject.CompareTag("NodeType4"))
            {
                refGameMgr.player.ChangeHealth(EVariation.Decrease, 10);
                obj = Instantiate(ObstacleExplosion, new Vector3(other.transform.position.x, -3.7f, -1.5f), Quaternion.identity);
            }

            else if (other.gameObject.CompareTag("BackgroundA"))
            {
                test.ChangeBackGround(1);
            }
            else if (other.gameObject.CompareTag("BackgroundB"))
            {
                test.ChangeBackGround(2);
            }
            else if (other.gameObject.CompareTag("BackgroundC"))
            {
                test.ChangeBackGround(0);
            }
            else if (other.gameObject.CompareTag("CameraD"))
            {
                Camera.main.GetComponent<CameraShake>().ShakeCamera();
            }
            else if (other.gameObject.CompareTag("CameraE"))
            {
                Camera.main.GetComponent<CameraShake>().StopCamera();
            }
            other.gameObject.SetActive(false);

            if (obj != null)
                Destroy(obj, 1.0f);

            DontDestroyOnLoad(gameObject);
        }
    }
}
