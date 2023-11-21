using UnityEngine;
namespace StackApp.Blocks
{
    public class BlockDestroyer : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.y < -100)// Destroy falling blocks
            {
                Destroy(gameObject);
            }
        }
    }
}