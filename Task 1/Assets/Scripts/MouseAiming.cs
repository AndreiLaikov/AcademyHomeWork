using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAiming : MonoBehaviour
{
    public float xSensitive;
    public float ySensitive;
    private float yRot;
    private float xRot;
    private Rigidbody rBody;
    private Vector3 prevMousePos;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Aim()
    {
        xRot -= Input.GetAxis("Mouse Y") * xSensitive;
        xRot = Mathf.Clamp(xRot, -40, 10);

        yRot += Input.GetAxis("Mouse X") * ySensitive;


        transform.rotation *= Quaternion.Euler(xRot, yRot, 0);
    }

   

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            rBody.isKinematic = true;
            Aim();
        }
        else
        {
            rBody.isKinematic = false;
        }
    }
}
