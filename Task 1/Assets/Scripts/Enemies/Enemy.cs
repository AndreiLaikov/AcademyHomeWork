using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AttackSystem AttackSystem;
    protected Rigidbody2D rBody;

    private void Awake()
    {
        AttackSystem = GetComponent<AttackSystem>();
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((AttackSystem.AffectedLayers.value & (1 << collision.gameObject.layer)) != 0)
        {
            AttackSystem.SendDamage(collision.gameObject.GetComponent<HealthSystem>());
        }
    }
}
