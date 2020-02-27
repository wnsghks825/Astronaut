using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public Rigidbody _Rigidbody = null;
    public float Speed;

    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _Rigidbody.velocity = -transform.up * Speed * Time.deltaTime;
        if (transform.position.y < -5.0f)
            gameObject.SetActive(false);
    }
}
