using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

// 꺼져
public class ResultManager :Singleton<ResultManager>
{

    public float NormalObtain { get; set; }
    public float MiniObtain { get; set; }
    public float EffectObtain { get; set; }
    public bool isFinished { get; private set; }

}
