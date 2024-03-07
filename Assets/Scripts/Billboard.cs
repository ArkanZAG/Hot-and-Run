using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        //transform.LookAt(camera.transform.position, Vector3.up);
        
        transform.forward = camera.transform.forward;
    }
}
