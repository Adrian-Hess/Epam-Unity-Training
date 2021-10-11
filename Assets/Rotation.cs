using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float sensHor;
    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensHor, 0);
        //transform.Rotate(Input.GetAxis("Mouse Y") * sensHor, 0, 0);
    }
}
