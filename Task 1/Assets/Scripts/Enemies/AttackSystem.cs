using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public float damageValue;
    public LayerMask AffectedLayers;

    public void SendDamage(HealthSystem healthSystem)
    {
        healthSystem.ApplyDamage(damageValue);
    }
}
