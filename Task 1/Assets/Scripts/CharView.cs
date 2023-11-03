using UnityEngine;

public class CharView : MonoBehaviour
{
    private Color mainColor = Color.white;
    private Color damageColor = Color.red;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        EventManager.OnDamageRecieved += DamageRecieved;
    }

    private void DamageRecieved()
    {
        sprite.color = damageColor;
    }

    private void OnDestroy()
    {
        EventManager.OnDamageRecieved -= DamageRecieved;
    }
}
