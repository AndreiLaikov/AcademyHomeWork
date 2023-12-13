using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public ParticleSystem Effect;
    public TrailRenderer trail;

    public BulletType currentBulletType;
    public float Force;
    public float TimeToLive;

    private float timeToLive;

    private Rigidbody rBody;


    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        trail.GetComponent<TrailRenderer>();
        currentBulletType = GetComponent<BulletType>();
    }

    private void OnEnable()
    {
        Shoot();
        timeToLive = TimeToLive;
    }

    private void OnDisable()
    {
        rBody.velocity = Vector3.zero;
    }

    protected virtual void Shoot()
    {
        rBody.AddForce(transform.forward * Force, ForceMode.Impulse);
    }

    protected void BulletDestroy()
    {
        gameObject.SetActive(false);
        trail.Clear();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.PlayHitSound(currentBulletType, transform.position);
        Instantiate(Effect, transform.position, Quaternion.identity);
    }

    protected virtual void AutoDestroy()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            BulletDestroy();
        }
    }

    private void Update()
    {
        AutoDestroy();
    }
}
