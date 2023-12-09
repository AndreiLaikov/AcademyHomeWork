using UnityEngine;

public class GrenadeBullet : Bullet
{
    public float power;
    public float radius;
    public LayerMask mask;

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

        AudioManager.Instance.GrenadeExplosion(explosionPos);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Explode();
    }

    protected override void Shoot()
    {
        base.Shoot();
        AudioManager.Instance.GrenadeShoot();
    }
}