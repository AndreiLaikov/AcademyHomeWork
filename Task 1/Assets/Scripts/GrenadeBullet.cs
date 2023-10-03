
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public float force;
    public float power;
    public float radius;
    public LayerMask mask;

    private Rigidbody rBody;

    public void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.AddForce(transform.forward * force);
    }

    private void Explode()
    {    
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius, mask);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
        Destroy(gameObject);
    }

}