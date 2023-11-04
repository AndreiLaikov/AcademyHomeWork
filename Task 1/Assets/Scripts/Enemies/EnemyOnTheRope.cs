using UnityEngine;

public class EnemyOnTheRope : Enemy
{
    public float angularForce;
    public float angularVel;

    private void Start()
    {
        rBody.AddForce(transform.right * angularForce*1000);
    }

    public void Update()
    {
        angularVel = rBody.angularVelocity;
        rBody.AddForce(transform.right * angularForce);
    }
}
