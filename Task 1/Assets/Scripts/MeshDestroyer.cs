using UnityEngine;

public class MeshDestroyer : MonoBehaviour
{
    public float minYPos = -100;
    public void Update()
    {
        if (transform.position.y < minYPos)
        {
            Destroy(gameObject);
        }
    }
}
