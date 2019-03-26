﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime = 0.2f;
    public float minZoom = 6f;
    public float maxZoom = 2f;
    public float zoomLimiter = 10f;
    private Vector3 velocity;
    private Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    { 
        if (targets.Count == 0)
            return;

        Move();
        Zoom(); 
    }


    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        print (GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
        Vector2 Left = targets[0].transform.position;
            Vector2 Right = targets[0].transform.position;
        if(targets.Count > 1)
        {

            for (int i = 0; i < targets.Count; i++)
            {
                if(targets[i].transform.position.x < Left.x)
                {
                    Left = targets[i].transform.position;
                }
                if(targets[i].transform.position.x > Right.x)
                {
                    Right = targets[i].transform.position;
                }
            }

        }
        float dist =  Vector2.Distance(Left, Right);
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }


        return bounds.center;
    }
}
