using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// MonoBehaviour 이벤트함수
    /// </summary>
    private void Reset()
    {
        gameObject.layer = LayerMask.NameToLayer("DestroyNode");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NodeType4"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
