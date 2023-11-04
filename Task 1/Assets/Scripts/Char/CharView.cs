using System.Collections;
using UnityEngine;

public class CharView : MonoBehaviour
{
    private Color mainColor = Color.white;
    private Color damageColor = Color.red;
    private SpriteRenderer sprite;

    private float duration = 0.5f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        EventManager.OnDamageRecieved += DamageRecieved;
    }

    private void DamageRecieved()
    {
        StartCoroutine(ColorAnimation());
    }

    private IEnumerator ColorAnimation()
    {
        float time = 0;

        while (time < 1)
        {
            sprite.color = Color.Lerp(damageColor,mainColor,time);
            time += Time.deltaTime / duration;
            yield return null;
        }
    }

    private void OnDestroy()
    {
        EventManager.OnDamageRecieved -= DamageRecieved;
    }
}
