using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AttackSystem AttackSystem;


    private void Start()
    {
        AttackSystem = GetComponent<AttackSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((AttackSystem.AffectedLayers.value & (1 << collision.gameObject.layer)) != 0)
        {
            AttackSystem.SendDamage(collision.gameObject.GetComponent<HealthSystem>());
        }
    }

}
