using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float sensHor = 1500f;
    public float sensVert = 1500f;
    public float minVert = -45f;
    public float maxVert = 45f;
    public float _rotationX = 0f;
    // Start is called before the first frame update
   
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }
    public RotationAxes axes = 0;
    void Start()
    {
       Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) {
            body.freezeRotation = true;
        } 
    }

    // Update is called once per frame
    void Update()
    {
       if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X")*sensHor*Time.deltaTime, 0);
       }
       else if (axes == RotationAxes.MouseY) {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVert * Time.deltaTime;
            _rotationX = Mathf.Clamp(_rotationX,minVert, maxVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
       } 
    }
}
