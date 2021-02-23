using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHealthBar : MonoBehaviour
{
    public Camera theCamera;
 
    void Update()
    {
        var rotation = theCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.back,
            rotation * Vector3.down);
    }
}
