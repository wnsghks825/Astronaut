using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Moving : MonoBehaviour
{
    //public GameObject _dragon;
    private Vector3 initMousePos;
    private GameObject mSelectObject;
    private bool bMouseDown=false;

    //처음마우스 클릭시
    void OnMouseDown()
    {
        initMousePos = Input.mousePosition;
        initMousePos.z = 10;
        initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);

        //Debug.Log("mouse Down : " + initMousePos);
    }
    //마우스 드래그시
    /*
    void OnMouseDrag()
    {
        Vector3 worldPoint = Input.mousePosition;
        worldPoint.z = 10;
        worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);

        Vector3 diffPos = worldPoint - initMousePos;
        diffPos.z = 0;
        diffPos.y = 0;

        initMousePos = Input.mousePosition;
        initMousePos.z = 10;
        initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);

        _dragon.transform.position =
            new Vector3(Mathf.Clamp(_dragon.transform.position.x + diffPos.x, -4.5f, 4.5f),
                        _dragon.transform.position.y,
                        _dragon.transform.position.z);
        }
        */
    private void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if (!bMouseDown && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            mSelectObject = hit.collider.gameObject;

            if (mSelectObject.tag == "Player")
                bMouseDown = true;

        }

        if (bMouseDown && Input.GetMouseButtonUp(0))
        {
            bMouseDown = false;
        }

        else if (bMouseDown)
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);



            if(hit.point.x != 0 )
                mSelectObject.transform.position = new Vector3(Mathf.Clamp(hit.point.x, -3.5f, 3.5f), mSelectObject.transform.position.y, mSelectObject.transform.position.z);

		}

    }
}
