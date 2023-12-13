using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public ParticleSystem Effect;

    public float Force;
    public float TimeToLive;

    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        Shoot();
    }

    protected virtual void Shoot()
    {
        rBody.AddForce(transform.forward * Force, ForceMode.Impulse);
    }

    protected void BulletDestroy()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        
        Instantiate(Effect, transform.position, Quaternion.identity);
        BulletDestroy();
    }

    protected virtual void AutoDestroy()
    {
        TimeToLive -= Time.deltaTime;
        if (TimeToLive <= 0)
        {
            BulletDestroy();
        }
    }

    private void Update()
    {
        AutoDestroy();
    }
}
