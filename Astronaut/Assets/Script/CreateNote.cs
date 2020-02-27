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
    GameObject obj;
    private GameObject obj1;
    private GameObject obj2;
    public GameObject notePrefab;
    public GameObject musicNote;
    public Transform[] points;
    private List<GameObject> notePool;
    private List<GameObject> notePool1;
    public List<GameObject> notePool2;
    public TextAsset textAsset;

    public List<string> noteData;
    public List<string> notePosition;
    public List<string> time;
    public List<string> type;
    public List<bool> noteCreate;
    public float noteTime;
    [SerializeField] SongInfo noteType= new SongInfo();
    Vector3 position;
    private int read;
    private int pooledAmount = 20;




    // Use this for initialization
    void Start()
    {

        notePool = new List<GameObject>();
        notePool1 = new List<GameObject>();
        notePool2 = new List<GameObject>();

        for (int i = 1; i <= 16; i++)
        {
            points[i].transform.position = new Vector3(-3.5f + 0.208f * i, 9.0f, -0.4f);
        }

        for(int i = 17; i <= 32; i++)
        {
            points[i].transform.position = new Vector3(-3.5f + 0.208f * (i+1), 9.0f, -0.4f);
        }

        points[33].transform.position = new Vector3(0.036f, 9.0f, -0.4f);
        noteData = new List<string>();
        noteCreate = new List<bool>();

        TextAsset textAsset = (TextAsset)Resources.Load("savage_demo");

        StringReader sr = new StringReader(textAsset.text);

        // 먼저 한줄을 읽는다. 

        string source = sr.ReadLine();

        noteType.Type = source.Split(' ');                // 쉼표로 구분된 데이터들을 저장할 배열


        while (source != null)
        {
            noteType.Type = source.Split(' ');
            //note[type.Position.Length] = type.Position[0];
            notePosition.Add(noteType.Type[1]);
            noteData.Add(source);
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
        }

        for(int ix = 0; ix < 15; ix++)
        {
            obj = Instantiate(Resources.Load("Note1")) as GameObject;
            obj.SetActive(false);
            notePool.Add(obj);
        }
        for(int iy = 0; iy < 40; iy++)
        {
            obj1 = Instantiate(Resources.Load("Note2")) as GameObject;
            obj1.SetActive(false);
            notePool1.Add(obj1);
        }
        for(int iz = 0; iz < 10; iz++)
        {
            obj2 = Instantiate(Resources.Load("Sphere")) as GameObject;
            obj2.SetActive(false);
            notePool2.Add(obj2);
        }

        //StartCoroutine(LoadNote());
    }

    public void PooledObject()  // 오브젝트 풀링
    {

        for(int i=0;i< notePool.Count; i++)
        {
            if (!notePool[i].activeInHierarchy)
            {
                if (int.Parse(notePosition[read]) >= 1 && int.Parse(notePosition[read]) <= 16)
                {
                    notePool[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) == 33)
                {
                    notePool[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) >= 17 && int.Parse(notePosition[read]) <= 32)
                {
                    notePool[i].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                notePool[i].SetActive(true);
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

    public void Update()
    {

        read = 0;
        noteCreate[read] = false;
        while (read <= noteData.Count)
        {

            if (noteData.Count <= read)
            {
                break;
            }

            if (noteTime >= float.Parse(time[read]) * 0.001f && noteTime <= float.Parse(time[257]) && noteCreate[read] == true)
            {

                //Debug.Log(noteTime + "," + time[read]);
                if (type[read] == "1")
                {
                    PooledObject();
                }
                if (type[read] == "2")
                {
                    PooledObject1();
                }
                if (type[read] == "3")
                {
                    PooledObject2();
                }

                if (int.Parse(notePosition[read]) == 0)
                {
                    musicNote = Instantiate(Resources.Load("musicNote")) as GameObject;
                    musicNote.transform.position = points[int.Parse(notePosition[read])].transform.position;

                    //노트가 판정 범위 도달 시 노래 재생하게 하도록(재생 노트 사라짐)
                }
/*
                if (int.Parse(notePosition[read]) >= 1 && int.Parse(notePosition[read]) <= 16)
                {
                    notePool[read].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) == 33)
                {
                    notePool[read].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else if (int.Parse(notePosition[read]) >= 17 && int.Parse(notePosition[read]) <= 32)
                {
                    notePool[read].transform.position = points[int.Parse(notePosition[read])].transform.position;
                }
                else
                    //Destroy(obj);
*/
                noteCreate[read] = false;

            }
            read++;
                
        }

            noteTime += Time.deltaTime;


    }

    IEnumerator LoadNote()
    {
        float _time = 0.01f;
        WaitForSeconds waitSec = new WaitForSeconds(_time);
        while (noteData.Count >= 1)
        {
            noteTime += _time;
            read = 1;
            while (read <= noteData.Count)
            {

                if (noteData.Count <= read)
                {
                    break;
                }

                if (noteTime >= float.Parse(time[read])*0.0001 && noteCreate[read] == true)
                {
                    GameObject obj = (GameObject)Instantiate(notePrefab);

                    Debug.Log(noteTime);

                    if (int.Parse(notePosition[read]) >= 0 && int.Parse(notePosition[read]) <= 16)
                    {
                        obj.transform.position = points[int.Parse(notePosition[read])].transform.position;
                    }

                    if (int.Parse(notePosition[read]) >= 17 && int.Parse(notePosition[read]) <= 32)
                    {
                        obj.transform.position = points[int.Parse(notePosition[read])].transform.position;
                    }
                    if (int.Parse(notePosition[read]) == 33)
                    {
                        obj.transform.position = points[33].transform.position;

                    }
                    obj.SetActive(true);
                    //Debug.Log(notePosition[i].ToString());

                    notePool.Add(obj);
                    noteCreate[read] = false;

                }
                read++;

                yield return waitSec;
            }
        }
    }

    Vector3 NotePos(int num)
    {
        for(num = 1; num <= 16; num++)
        {
            position = points[num].transform.position;
        }
        Debug.Log(position);
        return position;
    }

}
