using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed = 30f;
    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput);
    }

    public Quaternion getRotation()
    {
        return transform.rotation;
    }

    public void saveRotation(Quaternion saveRotati)
    {
        transform.rotation = saveRotati;
    }
}
