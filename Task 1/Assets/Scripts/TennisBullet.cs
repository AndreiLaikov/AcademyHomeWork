using UnityEngine;

public class TennisBullet : Bullet
{
    protected override void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.TennisHit();
    }

    protected override void Shoot()
    {
        base.Shoot();
        AudioManager.Instance.TennisShoot();
    }
}
