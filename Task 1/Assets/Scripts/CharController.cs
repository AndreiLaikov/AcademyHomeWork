using UnityEngine;

public class CharController : MonoBehaviour
{
    public float HorizontalSpeed;
    public Rigidbody2D rBody;
    public float VerticalForce;

    private Vector2 moveVector;

    public ForceMode2D mode;

    private void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetKeyDown(KeyCode.W) ? 1 : 0;

        Move();
        Jump();
    }

    private void Move()
    {
        Vector2 velocity = new Vector2(moveVector.x * HorizontalSpeed, rBody.velocity.y);// v= m/s
        rBody.velocity = velocity;
    }

    private void Jump()
    {
        rBody.AddForce(moveVector.y * VerticalForce * Vector2.up, mode);// Force = M * m/s^2 = M * m/s/s
    }
}
