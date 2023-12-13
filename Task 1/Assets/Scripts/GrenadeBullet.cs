using UnityEngine;

public class GrenadeBullet : Bullet
{
    public float power;
    public float radius;
    public LayerMask mask;

    private void Explode()
    {    
        Vector3 explosionTransform = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionTransform, radius, mask);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionTransform, radius);
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        AudioManager.Instance.GrenadeExplosion(transform.position);
        Explode();
    }

    protected override void Shoot()
    {
        base.Shoot();
        AudioManager.Instance.GrenadeShoot();
    }
}