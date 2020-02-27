using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class CreateNoteHARD : CreateNote
{
    GameObject obj1;
    private GameObject obj2;
    private GameObject obj3;
    private GameObject obj4;
    private GameObject objA;
    private GameObject objB;
    private GameObject objC;
    private GameObject objD;
    private GameObject objE;
    public GameObject notePrefab;
    public GameObject musicNote;
    public Transform[] points;
    private List<GameObject> notePool1;
    private List<GameObject> notePool2;
    private List<GameObject> notePool3;
    private List<GameObject> notePool4;
    private List<GameObject> notePoolA;
    private List<GameObject> notePoolB;
    private List<GameObject> notePoolC;
    private List<GameObject> notePoolD;
    private List<GameObject> notePoolE;
    public TextAsset textAsset;

    [SerializeField] SongInfo noteType = new SongInfo();
    Vector3 position;
    public int read;
    private int pooledAmount = 20;


    // Use this for initialization
    void Awake()
    {

        notePool1 = new List<GameObject>();
        notePool2 = new List<GameObject>();
        notePool3 = new List<GameObject>();
        notePool4 = new List<GameObject>();
        notePoolA = new List<GameObject>();
        notePoolB = new List<GameObject>();
        notePoolC = new List<GameObject>();
        notePoolD = new List<GameObject>();
        notePoolE = new List<GameObject>();

        CanObtain = new List<string>();

        for (int i = 1; i <= 16; i++)
        {
            points[i].transform.position = new Vector3(-3.5f + 0.208f * i, 9.0f, -0.4f);
        }

        for (int i = 17; i <= 32; i++)
        {
            points[i].transform.position = new Vector3(-3.5f + 0.208f * (i + 1), 9.0f, -0.4f);
        }

        points[33].transform.position = new Vector3(0.036f, 9.0f, -0.4f);
        noteCreate = new List<bool>();

        TextAsset textAsset = (TextAsset)Resources.Load("savage_full_hard (2)");

        StringReader sr = new StringReader(textAsset.text);

        // 먼저 한줄을 읽는다. 

        string source = sr.ReadLine();

        noteType.Type = source.Split(' ');                // 쉼표로 구분된 데이터들을 저장할 배열


        while (source != null)
        {
            noteType.Type = source.Split(' ');
            //note[type.Position.Length] = type.Position[0];
            notePosition.Add(noteType.Type[1]);
            time.Add(noteType.Type[0]);
            type.Add(noteType.Type[2]);

            noteType.Type = source.Split(' ');  // ' '로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.
            source = sr.ReadLine();    // 한줄 읽는다.

            if (noteType.Type.Length == 0)
            {

                sr.Close();
                return;

            }
            noteCreate.Add(true);
            if (noteType.Type[2] == "1" || noteType.Type[2] == "2" || noteType.Type[2] == "3")
            {
                CanObtain.Add(noteType.Type[2]);
            }

            if (noteType.Type[2] == "1")
            {
                Normal.Add(noteType.Type[2]);
            }
            if (noteType.Type[2] == "2")
            {
                Mini.Add(noteType.Type[2]);
            }
            if (noteType.Type[2] == "3")
            {
                Effect.Add(noteType.Type[2]);
            }
        }

        for (int iw = 0; iw < 35; iw++)
        {
            obj1 = Instantiate(Resources.Load("Note1")) as GameObject;
            obj1.SetActive(false);
            notePool1.Add(obj1);
        }
        for (int ix = 0; ix < 35; ix++)
        {
            obj2 = Instantiate(Resources.Load("Note2")) as GameObject;
            obj2.SetActive(false);
            notePool2.Add(obj2);
        }
        for (int iy = 0; iy < 5; iy++)
        {
            obj3 = Instantiate(Resources.Load("Note3")) as GameObject;
            obj3.SetActive(false);
            notePool3.Add(obj3);
        }
        for (int iz = 0; iz < 40; iz++)
        {
            obj4 = Instantiate(Resources.Load("Note4")) as GameObject;
            obj4.SetActive(false);
            notePool4.Add(obj4);
        }
        for (int i = 0; i < 2; i++)
        {
            objA = Instantiate(Resources.Load("BackgroundA")) as GameObject;
            objA.SetActive(false);
            notePoolA.Add(objA);
        }
        for (int i = 0; i < 2; i++)
        {
            objB = Instantiate(Resources.Load("BackgroundB")) as GameObject;
            objB.SetActive(false);
            notePoolB.Add(objB);
        }
        for (int i = 0; i < 2; i++)
        {
            objC = Instantiate(Resources.Load("BackgroundC")) as GameObject;
            objC.SetActive(false);
            notePoolC.Add(objC);
        }
        for (int i = 0; i < 2; i++)
        {
            objD = Instantiate(Resources.Load("CameraD")) as GameObject;
            objD.SetActive(false);
            notePoolD.Add(objD);
        }
        for (int i = 0; i < 2; i++)
        {
            objE = Instantiate(Resources.Load("CameraE")) as GameObject;
            objE.SetActive(false);
            notePoolE.Add(objE);
        }
        //StartCoroutine(LoadNote());
    }

    public void PooledObjectA()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePoolA.Count; i++)
        {
            if (!notePoolA[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 90 && int.Parse(notePosition[read]) <= 95)
                {
                    notePoolA[i].transform.position = points[33].transform.position;
                }

                notePoolA[i].SetActive(true);
                break;
            }

        }

    }

    public void PooledObjectB()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePoolB.Count; i++)
        {
            if (!notePoolB[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 90 && int.Parse(notePosition[read]) <= 95)
                {
                    notePoolB[i].transform.position = points[33].transform.position;
                }

                notePoolB[i].SetActive(true);
                break;
            }

        }

    }

    public void PooledObjectC()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePoolC.Count; i++)
        {
            if (!notePoolC[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 90 && int.Parse(notePosition[read]) <= 95)
                {
                    notePoolC[i].transform.position = points[33].transform.position;
                }

                notePoolC[i].SetActive(true);
                break;
            }

        }

    }
    public void PooledObjectD()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePoolD.Count; i++)
        {
            if (!notePoolD[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 90 && int.Parse(notePosition[read]) <= 95)
                {
                    notePoolD[i].transform.position = points[33].transform.position;
                }

                notePoolD[i].SetActive(true);
                break;
            }

        }

    }
    public void PooledObjectE()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePoolE.Count; i++)
        {
            if (!notePoolE[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 90 && int.Parse(notePosition[read]) <= 95)
                {
                    notePoolE[i].transform.position = points[33].transform.position;
                }

                notePoolE[i].SetActive(true);
                break;
            }

        }

    }
    public void PooledObject1()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePool1.Count; i++)
        {
            if (!notePool1[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 1 && int.Parse(notePosition[read]) <= 16)
                {
                    notePool1[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) == 33)
                {
                    notePool1[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) >= 17 && int.Parse(notePosition[read]) <= 32)
                {
                    notePool1[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                notePool1[i].SetActive(true);
                break;
            }

        }

    }

    public void PooledObject2()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePool2.Count; i++)
        {
            if (!notePool2[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 1 && int.Parse(notePosition[read]) <= 16)
                {
                    notePool2[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) == 33)
                {
                    notePool2[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) >= 17 && int.Parse(notePosition[read]) <= 32)
                {
                    notePool2[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                notePool2[i].SetActive(true);
                break;
            }

        }
    }

    public void PooledObject3()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePool3.Count; i++)
        {
            if (!notePool3[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 1 && int.Parse(notePosition[read]) <= 16)
                {
                    notePool3[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) == 33)
                {
                    notePool3[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) >= 17 && int.Parse(notePosition[read]) <= 32)
                {
                    notePool3[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                notePool3[i].SetActive(true);
                break;
            }

        }
    }
    public void PooledObject4()  // 오브젝트 풀링
    {

        for (int i = 0; i < notePool4.Count; i++)
        {
            if (!notePool4[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 1 && int.Parse(notePosition[read]) <= 16)
                {
                    notePool4[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) == 33)
                {
                    notePool4[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) >= 17 && int.Parse(notePosition[read]) <= 32)
                {
                    notePool4[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                notePool4[i].SetActive(true);
                break;
            }

        }
    }
    public void Update()
    {

        read = 0;
        noteCreate[read] = false;
        while (read <= type.Count)
        {

            if (type.Count <= read)
            {
                break;
            }

            if (noteTime >= float.Parse(time[read]) * 0.001f && noteTime <= float.Parse(time[257]) && noteCreate[read] == true)
            {

                //Debug.Log(noteTime + "," + time[read]);
                if (type[read] == "1")
                {
                    PooledObject1();
                }
                if (type[read] == "2")
                {
                    PooledObject2();
                }
                if (type[read] == "3")
                {
                    PooledObject3();
                }
                if (type[read] == "4")
                {
                    PooledObject4();
                }
                if (type[read] == "A")
                {
                    PooledObjectA();
                }
                if (type[read] == "B")
                {
                    PooledObjectB();
                }
                if (type[read] == "C")
                {
                    PooledObjectC();
                }
                if (type[read] == "D")
                {
                    PooledObjectD();
                }
                if (type[read] == "E")
                {
                    PooledObjectE();
                }
                if (int.Parse(notePosition[read]) == 0)
                {
                    musicNote = Instantiate(Resources.Load("musicNote")) as GameObject;
                    musicNote.transform.position = points[int.Parse(notePosition[read])].transform.position;

                    //노트가 판정 범위 도달 시 노래 재생하게 하도록(재생 노트 사라짐)
                }
                noteCreate[read] = false;

            }
            read++;

        }

        noteTime += Time.deltaTime;

    }
}
