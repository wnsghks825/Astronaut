using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    public GameObject PlayerMissile;
    public Transform MissileLocation;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SkillFire()
    {
        Instantiate(PlayerMissile, MissileLocation.position, MissileLocation.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        //SkillFire();
    }
}
