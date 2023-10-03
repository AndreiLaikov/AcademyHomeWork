using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    public GameObject simpleBulletPrefab;
    public BulletType currentBullet;

    private void Start()
    {
        currentBullet = GetComponent<BulletType>();
    }

    [ContextMenu("SimpleShoot")]
    public void SimpleBulletShoot()
    {
        var pos = transform.position + Vector3.forward;

        Instantiate(simpleBulletPrefab, pos, transform.rotation);
        
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
                SimpleBulletShoot();
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
