using UnityEngine;

public class CharController : MonoBehaviour
{
    public static float Speed = 1;
    public static bool isLeft;
    private float currentSpeed;
    private float targetSpeed;

    public float JumpForce;

    private Rigidbody2D rb;
    public bool isGround;
    public bool isJumping;

    private string AnimatorSpeedMultiplier = "SpeedMultiplier";

    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer Renderer
    {
        get { return _spriteRenderer ?? GetComponent<SpriteRenderer>(); }
    }

    private Animator animController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        currentSpeed = Speed;
        targetSpeed = Speed;
    }

    void OnDirectionChange()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Renderer.flipX = !Renderer.flipX;
            isLeft = !isLeft;
        }
    }

    public void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            targetSpeed = currentSpeed + 1;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            targetSpeed = currentSpeed - 1;
        }

        targetSpeed = Mathf.Clamp(targetSpeed, 1, 20);
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 0.1f);

        Speed = currentSpeed;

        animController.SetFloat(AnimatorSpeedMultiplier, Speed);
    }

    private void Update()
    {
        OnDirectionChange();
        ChangeSpeed();

        Grounded();
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGround)
        {
            rb.AddForce(JumpForce * Vector2.up);
            isJumping = true;
        }
        animController.SetBool("isJumping", isJumping);
    }

    void Grounded()
    {
        isGround = rb.velocity.y == 0;
        isJumping = rb.velocity.y != 0;
    }
}
