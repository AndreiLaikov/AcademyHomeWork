
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;

    [Header ("Bullet")]
    public AudioClip BulletShootAudio;
    public AudioClip BulletHitAudio;

    [Header("Grenade")]
    public AudioClip GrenadeShootAudio;
    public AudioClip GrenadeExplosionAudio;

    [Header("Tennis")]
    public AudioClip TennisShootAudio;
    public AudioClip TennisHitAudio;


    public void BulletShoot()
    {
        audioSource.PlayOneShot(BulletShootAudio);
    }

    public void BulletHit()
    {
        audioSource.PlayOneShot(BulletHitAudio);
    }

    public void GrenadeShoot()
    {
        audioSource.PlayOneShot(GrenadeShootAudio);
    }

    public void GrenadeExplosion(Vector3 position)
    {
        var go = new GameObject("Explosion");
        go.transform.position = position;
        var audio = go.AddComponent<AudioSource>();
        audio.spatialBlend = 1;
        audio.clip = GrenadeExplosionAudio;
        audio.maxDistance = 5;
        audio.Play();
    }

    public void TennisShoot()
    {
        audioSource.PlayOneShot(TennisShootAudio);
    }

    public void TennisHit()
    {
        audioSource.PlayOneShot(TennisHitAudio);
    }
}
