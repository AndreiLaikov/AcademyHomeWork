using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    public GameObject simpleBulletPrefab;
    public GameObject tennisBulletPrefab;
    public GameObject grenadeBulletPrefab;
    public BulletType currentBullet;

    public Transform gunPosition;

    private void Start()
    {
        currentBullet = GetComponent<BulletType>();
    }

    public void BulletShoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, gunPosition.position, transform.rotation);
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
            case BulletType.bTypes.Grenade:
                BulletShoot(grenadeBulletPrefab);
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
