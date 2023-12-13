using UnityEngine;

public class SimpleBullet : Bullet
{
    protected override void Shoot()
    {
        base.Shoot();
        AudioManager.Instance.BulletShoot();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        AudioManager.Instance.BulletHit(transform.position);
    }
}
