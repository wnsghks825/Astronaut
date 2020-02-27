using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(Player)) as Player;
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "MyClassContainer";
                    _instance = container.AddComponent(typeof(Player)) as Player;
                }
            }

            return _instance;
        }
    }

    [SerializeField]
    public float initHealth = 100;
    public float result = 0;
    public float gauge = 0;
    public static float score=0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Initialize(initHealth, initHealth);
        StartCoroutine(Hpbar());
    }

    IEnumerator Hpbar()
    {
        while (initHealth >= 0)
        {
            initHealth -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        result = initHealth / 100f;

    }
    private float currentFill;
    public float MyMaxValue { get; set; }


    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue) currentValue = MyMaxValue;
            else if (value < 0) currentValue = 0;
            else currentValue = value;

        }
    }

    private float currentValue;

    public void Initialize(float currentValue,float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
    public void IncreaseHP(float value)
    {
        initHealth += value;
    }
    public void IncreaseGauge(float value)
    {
        gauge+=value;
    }
}
