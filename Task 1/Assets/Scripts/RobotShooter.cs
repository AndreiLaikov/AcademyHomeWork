using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    public GameObject simpleBulletPrefab;
    public GameObject tennisBulletPrefab;
    public BulletType currentBullet;

    private void Start()
    {
        currentBullet = GetComponent<BulletType>();
    }

    public void BulletShoot(GameObject bulletPrefab)
    {
        var pos = transform.position + Vector3.forward;
        Instantiate(bulletPrefab, pos, transform.rotation);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void Shoot()
    {
        switch (currentBullet.bType)
        {
            case BulletType.bTypes.Simple:
                BulletShoot(simpleBulletPrefab);
                break;
            case BulletType.bTypes.Tennis:
                BulletShoot(tennisBulletPrefab);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.GetComponent<BulletType>())
            currentBullet.bType = other.GetComponent<BulletType>().bType;
    }

    private void OnTriggerExit(Collider other)
    {
        currentBullet.bType = BulletType.bTypes.None;
    }



}
