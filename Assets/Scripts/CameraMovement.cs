using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 resetCamera;

    private Camera myCamera;
    private float targetZoom;
    private float zoomFactor = 3f;

    private bool drag = false;

    void Start()
    {
        myCamera = Camera.main;
        targetZoom = myCamera.orthographicSize;
        resetCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Implementation of zoom
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 2f, 6f);
        myCamera.orthographicSize = Mathf.Lerp(myCamera.orthographicSize, targetZoom, Time.deltaTime * 10f);

        //Implementation of camera dragging
        if (Input.GetMouseButton(0))
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = origin - difference;
        }

        if (Input.GetMouseButton(2)) //middle mouse button click
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
}