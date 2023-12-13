
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;
    public GameObject Hit;

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

    public void BulletHit(Vector3 pos)
    {
        CreateAudio(pos, BulletHitAudio);
    }

    public void GrenadeShoot()
    {
        audioSource.PlayOneShot(GrenadeShootAudio);
    }

    public void GrenadeExplosion(Vector3 pos)
    {
        CreateAudio(pos, GrenadeExplosionAudio);
    }

    public void TennisShoot()
    {
        audioSource.PlayOneShot(TennisShootAudio);
    }

    public void TennisHit(Vector3 pos)
    {
        CreateAudio(pos, TennisHitAudio);
    }

    private void CreateAudio(Vector3 pos, AudioClip sound)
    {
        var go = Instantiate(Hit);
        go.transform.position = pos;
        var audio = go.GetComponent<AudioSource>();
        audio.clip = sound;
        audio.Play();
    }
}
