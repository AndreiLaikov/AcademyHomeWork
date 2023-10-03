using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    public GameObject simpleBulletPrefab;

    [ContextMenu("SimpleShoot")]
    public void SimpleBulletShoot()
    {
        var pos = transform.position + Vector3.forward;
        Instantiate(simpleBulletPrefab, pos, Quaternion.identity);
    }
}
