using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainNote : MonoBehaviour
{
    public GameObject NoteExplosion;
    public GameObject MiniExplosion;
    private GameObject obj;
    public GameObject EffectExplosion;
    MeshRenderer background;
    Background fade;
    public float HP;

    public void Start()
    {
        background = GameObject.Find("Quad").GetComponent<MeshRenderer>();
        fade = GameObject.Find("Background").GetComponent<Background>();
    }

    public void OnTriggerEnter(Collider other)
    {

        switch (other.GetComponent<Collider>().name)
        {
            case "Note1(Clone)":
                obj = Instantiate(NoteExplosion, new Vector3(other.transform.position.x, -3.7f, -1.5f), NoteExplosion.transform.rotation);
                Player.Instance.IncreaseHP(1f);
                Player.Instance.IncreaseGauge(0.01f);
                Player.score += 1;
                other.gameObject.SetActive(false);
                Destroy(obj, 1);
                break;

            case "Note2(Clone)":
                obj = Instantiate(MiniExplosion, new Vector3(other.transform.position.x, -3.7f, -0.75f), MiniExplosion.transform.rotation);
                Player.Instance.IncreaseHP(0.1f);
                Player.Instance.IncreaseGauge(0.01f);
                Player.score += 1;
                other.gameObject.SetActive(false);
                Destroy(obj, 1);
                break;

            case "Sphere(Clone)":
                background.material = Resources.Load("Background", typeof(Material)) as Material;
                obj = Instantiate(EffectExplosion, new Vector3(other.transform.position.x, -3.7f, -0.75f), MiniExplosion.transform.rotation);
                Player.Instance.IncreaseHP(0.1f);
                Player.Instance.IncreaseGauge(0.01f);
                Player.score += 1;
                other.gameObject.SetActive(false);
                Destroy(obj, 1);
                break;

            case "Note":
                background.material = Resources.Load("Background1", typeof(Material)) as Material;
                break;
        }
    }

}
