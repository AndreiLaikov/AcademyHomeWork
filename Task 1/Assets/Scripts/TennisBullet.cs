using UnityEngine;

public class TennisBullet : Bullet
{
    protected override void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.PlayHitSound(currentBulletType, transform.position);
    }
}
