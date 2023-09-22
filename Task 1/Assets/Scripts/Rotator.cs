using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Вращается в определенном направлении с заданной скоростью

    public bool x;
    public bool y;
    public bool z;

    public float angVel = 90;

    private Vector3 axis2;

    void Update()
    {
        axis2 = new Vector3(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(z));
        transform.rotation *= Quaternion.AngleAxis(angVel * Time.deltaTime, axis2);
    }

}
