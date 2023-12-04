
using UnityEngine;

public class Forcer : MonoBehaviour
{
    public Rigidbody rBody;
    public float force = 1;
    private float mass = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");

        if (other.GetComponent<Rigidbody>())
        {
            Debug.Log("has RB");
            rBody = other.GetComponent<Rigidbody>();
            AddForce();
        }
        else
        {
            rBody = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //rBody = null;
        rBody.mass = mass;
    }

    public void AddForce()
    {
        if (rBody != null)
        {
            //rBody.AddForce(-Vector3.up * force, ForceMode.Impulse);
            rBody.mass = 1;
        }
    }

}
