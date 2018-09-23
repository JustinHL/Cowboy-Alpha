﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableFunction : MonoBehaviour
{

    //Initialize Variables
    public int slot;
    GameObject getTarget;
    private byte code;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    public void init(int slot, FunctionBullet functionBullet){
        this.slot = slot;
        code = functionBullet.GetCode();
    }
    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {   
            Debug.Log("re");
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if (getTarget != null)
            {
                isMouseDragging = true;
                //Converting world position to screen position.
                positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {   
            if(isMouseDragging){
                isMouseDragging = false;
                int slot = ((int )(transform.position.y)) + 5;
                if(slot < 0)slot = 0;

            } 
        }

        //Is mouse Moving
        if (isMouseDragging)
        {   
            Debug.Log("draging");
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

            //converting screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
        }


    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {   
        Debug.Log("Clicked");

        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Physics.Raycast(ray.origin, Vector3.forward, 999));
        if (Physics.Raycast(ray.origin, Vector3.forward, out hit))
        {
            target = hit.collider.gameObject;
            Debug.Log("hit");
        }
        return target;
    }

}