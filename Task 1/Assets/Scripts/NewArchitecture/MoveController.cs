using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float Speed = 3f;
    public float JumpHeight = 2f;
    public CharacterController Controller;

    private Vector3 resultDir;
    private float yVelocity;
    private const float gravity = -9.81f;
    private bool isGrounded;

    private DesktopInput dInput;

    private void Start()
    {
        dInput = gameObject.AddComponent<DesktopInput>();
        dInput.MovingInputReciever += OnMoveRecieved;
        dInput.JumpingInputReciever += OnJumpRecieved;
    }

    private void OnMoveRecieved(Vector2 delta)
    {
        var right = delta.x * Speed * transform.right;
        var forward = delta.y * Speed * transform.forward;
        
        resultDir = right + forward;
        Controller.Move(resultDir * Time.deltaTime);
    }

    private void OnJumpRecieved(bool isJumping)
    {
        if (isJumping && isGrounded)
        {
            yVelocity = Mathf.Sqrt(-2f * JumpHeight * gravity); //v=Sqrt(h*-2*g)
        }
    }

    private void Update()
    {
        Gravity();
    }

    private void Gravity()
    {
        yVelocity += gravity * Time.deltaTime;

        if (isGrounded && yVelocity < 0)
        {
            yVelocity = -2.0f;//small value, not 0 for remove jitter
        }
        Controller.Move(Vector3.up * yVelocity * Time.deltaTime);

        isGrounded = Controller.isGrounded;
    }
}
