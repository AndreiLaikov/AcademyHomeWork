using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]private float currentHealth;
    public float maxHealth;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        private set
        {
            currentHealth = value;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damageValue)
    {
        currentHealth -= damageValue;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void ApplyHealing(float healValue)
    {
        currentHealth += healValue;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
