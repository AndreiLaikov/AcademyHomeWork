using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 10;
    public float JumpHeight = 2;

    public Transform GroundChecker;
    public float GroundDistance = 3;

    private const float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;
    public LayerMask GroundMask;

    private void Start()
    {
        if (Controller == null)
        {
            Debug.LogError("Missing Controller");
        }
        if (GroundChecker == null)
        {
            Debug.LogError("Missing GroundChecker");
        }
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var dir = x * transform.right + z * transform.forward;

        if (x!=0 || z!=0)
        { 
            Controller.Move(dir * Speed * Time.deltaTime);//else it's break isGrounded
        }
        
    }

    private void Jump()//v=Sqrt(h*-2*g)
    {
        //isGrounded = Physics.CheckSphere(GroundChecker.position, GroundDistance, GroundMask);

        isGrounded = Controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;//small value, not 0 for remove jitter
        }

        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * JumpHeight * gravity);
        }

        velocity.y += gravity*Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime);// dy=0.5*g*t^2
    }



}
