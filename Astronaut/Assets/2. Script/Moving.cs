using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Moving : MonoBehaviour
{
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

    private void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if (Time.timeScale == 0)
        {
            bMouseDown = false;
        }
        else
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
}
