using UnityEngine;

public class Damager : MonoBehaviour
{
    public float timeToLive = 5;
    public float startForce;
    private float time;

    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.AddForce(Vector3.forward * startForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Moving>() != null)
        {
            collision.gameObject.GetComponent<Moving>().isDeath = true;
            rBody.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Moving>() != null)
        {
            Debug.Log("");
            other.gameObject.GetComponent<Moving>().isDeath = true;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
