using UnityEngine;

public class FireballController : MonoBehaviour
{
    public Vector3 Direction = Vector3.left;
    public float Speed;

    private void Update()
    {
        transform.position += Speed * Direction * Time.deltaTime;
    }
    
}
