using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    public GameObject simpleBulletPrefab;
    public GameObject tennisBulletPrefab;
    public GameObject grenadeBulletPrefab;
    public BulletType currentBullet;

    public Transform gunTransform;

    private void Start()
    {
        currentBullet = GetComponent<BulletType>();
    }

    public void BulletShoot(string name)
    {
        //Instantiate(bulletPrefab, gunPosition.position, gunPosition.rotation);
        BulletsPull.Instance.GetObject(name, gunTransform.position, gunTransform.rotation);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void Shoot()
    {
        if (currentBullet.bType == BulletType.bTypes.None)
            return;

        BulletShoot(currentBullet.bType.ToString());
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
