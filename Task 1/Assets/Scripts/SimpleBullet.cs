using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public float force;
    public float timeToLive = 5;

    private Rigidbody rBody;

    public void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.AddForce(Vector3.forward * force);
    }

    public void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
            BulletDestroy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        BulletDestroy();
    }

    private void BulletDestroy()
    {
        Destroy(gameObject);
    }
}
