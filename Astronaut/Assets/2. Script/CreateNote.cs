using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SongInfo
{
    public string[] Type;
}

public class CreateNote : MonoBehaviour
{
    public List<string> notePosition;
    public List<string> time;
    public List<string> type;
    public List<string> CanObtain;
    public List<string> Normal;
    public List<string> Mini;
    public List<string> Effect;
    public List<bool> noteCreate;
    public float noteTime;
}
