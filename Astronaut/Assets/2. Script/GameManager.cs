using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using Astronaut;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player m_Player = null;

    [SerializeField] private Music m_Music = null;

    [SerializeField] private CreateNote m_NoteMgr = null;

    public static bool IsFailed { get; private set; }

    #region Properties 

    // 플레이어 프로퍼티
    public Player player { get { return m_Player; } }

    public Music music { get { return m_Music; } }

    public CreateNote noteMgr { get => m_NoteMgr; }

    public int EffectCount { get; private set; }
    public int NormalCount { get; private set; }
    public int MiniCount { get; private set; }
    public int TotalNote { get; private set; }

    // 게임 스코어
    public float score { get; set; }

    // 노트먹은갯수들
    public int effectScore { get; set; }
    public int miniScore { get; set; }
    public int normalScore { get; set; }

    

    public bool isFinished { get; private set; }
    public bool isMusicFinished { get; set; }


    #endregion

    // GameScene --> ResultScene으로 될때 사용한다.
    // 매개변수 --> true이면 실패했다는 의미이다
    public static void ChangeSceneToResult(bool isFailed = false) 
    {
        IsFailed = isFailed;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
    }

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (noteMgr)
        {
            EffectCount = m_NoteMgr.Effect.Count;     // 그거 총 갯수
            MiniCount = m_NoteMgr.Mini.Count;         // 그친구 총 갯수
            NormalCount = m_NoteMgr.Normal.Count;     // 그녀석 갯수
            TotalNote = EffectCount + MiniCount + NormalCount;
        }
    }
}
