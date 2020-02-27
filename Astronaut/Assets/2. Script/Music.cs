using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
[DisallowMultipleComponent]
public class Music : Singleton<Music>
{
    // 음악클립
    public AudioClip musicClip;

    private AudioSource m_AudioSource;

    // CreateNode 변경시켜야하는가? --> (필요하지만 패스)

    /// <summary>
    /// MonoBehaviour 이벤트함수
    /// </summary>
    private void Reset()
    {
        // Physics에서 MusicStartLine, MusicStartNode의 충돌을 체크해주어야 한다
        gameObject.layer = LayerMask.NameToLayer("MusicStartLine");

        GetComponent<AudioSource>().playOnAwake = false;
    }

    protected override void Awake()
    {
        base.Awake();

        m_AudioSource = GetComponent<AudioSource>();

        // 음악이 여러개가 된다면? 로비에서 부터 존재하는 Persistant Singleton을 이용
        m_AudioSource.clip = musicClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Physics에서 MusicStartLine, MusicStartNode의 충돌을 체크해주어야 한다.
        if(!m_AudioSource.isPlaying)
        {
            m_AudioSource.Play();
        }
    }
}
