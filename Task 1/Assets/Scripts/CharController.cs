using UnityEngine;

public class CharController : MonoBehaviour
{
    public float HorizontalSpeed;
    public Rigidbody2D rBody;
    public float VerticalForce;
    public Transform GroundCheckerTransform;

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask mask;

    private Vector2 moveVector;


    private void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetKeyDown(KeyCode.W) ? 1 : 0;

        GroundCheck();
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
        if (isGrounded)
        {
            rBody.AddForce(moveVector.y * VerticalForce * Vector2.up, ForceMode2D.Force);// Force = M * m/s^2 = M * m/s/s
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(GroundCheckerTransform.position, Vector2.down, 0.1f, mask);
    }
}
