
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

    public void PlayShootSound(BulletType bulletType)
    {
        switch (bulletType.bType)
        {
            case BulletType.bTypes.Simple:
                audioSource.PlayOneShot(BulletShootAudio);
                break;
            case BulletType.bTypes.Grenade:
                audioSource.PlayOneShot(GrenadeShootAudio);
                break;
            case BulletType.bTypes.Tennis:
                audioSource.PlayOneShot(TennisShootAudio);
                break;
        }
    }

    public void PlayHitSound(BulletType bulletType, Vector3 position)
    {
        switch (bulletType.bType)
        {
            case BulletType.bTypes.Simple:
                CreateAudio(position, BulletHitAudio);
                break;
            case BulletType.bTypes.Grenade:
                CreateAudio(position, GrenadeExplosionAudio);
                break;
            case BulletType.bTypes.Tennis:
                CreateAudio(position, TennisHitAudio);
                break;
        }
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
