using UnityEngine;

public class SimpleBullet : Bullet
{
    protected override void Shoot()
    {
        base.Shoot();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        BulletDestroy();
    }
}
