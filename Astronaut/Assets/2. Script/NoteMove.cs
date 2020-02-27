using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public Rigidbody _Rigidbody = null;
    public float Speed;
    [SerializeField] GameObject ObstacleExplosion = null;
    private GameObject obj;

    private void Reset()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Node");
    }

    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _Rigidbody.velocity = -transform.up * Speed * Time.deltaTime;
        if (transform.position.y < -5.0f&& transform.position.z <= - 0.4f)
        {
            gameObject.SetActive(false);
            obj = Instantiate(ObstacleExplosion, new Vector3(transform.position.x, -3.7f, -1.5f), Quaternion.identity);
        }
        if (obj != null)
            Destroy(obj, 1.0f);
    }
}
