using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AttackSystem AttackSystem;
    public float forceSize;

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

    [ContextMenu("Add")]
    public void Forcing()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * forceSize,ForceMode2D.Impulse);
    }

}
