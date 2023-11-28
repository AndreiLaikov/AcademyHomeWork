using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float Force;
    public float TimeToLive = 5;

    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.AddForce(transform.forward * Force);
    }

    protected void BulletDestroy()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        BulletDestroy();
    }

    protected virtual void AutoDestroy()
    {
        TimeToLive -= Time.deltaTime;
        if (TimeToLive <= 0)
            BulletDestroy();
    }

    private void Update()
    {
        AutoDestroy();
    }
}
