using UnityEngine;

public class TennisBullet : MonoBehaviour
{
    public float force;
    public float timeToLive = 50;

    private Rigidbody rBody;

    public void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.AddForce(transform.forward * force);
    }

    public void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
            BulletDestroy();
    }

    private void BulletDestroy()
    {
        Destroy(gameObject);
    }
}
