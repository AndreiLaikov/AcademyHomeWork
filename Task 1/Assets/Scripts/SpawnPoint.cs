using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public SpriteRenderer activeState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeState.enabled = true;
            EventManager.NewSpawnPoint(transform);
        }
    }
}
