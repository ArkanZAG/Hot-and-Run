using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesLockPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = initialPosition;
    }
}
