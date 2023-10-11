using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 10;
    public float JumpHeight = 2;

    private const float gravity = -9.81f;
    private bool isGrounded;
    private Vector3 upVelocity;
    public bool isJumping;

    private Vector3 resultDir;

    private void Start()
    {
        if (Controller == null)
        {
            Debug.LogError("Missing Controller");
        }
    }

    private void Update()
    {
        Jump();
    }

    public void MoveWithTouch(Vector2 touchDir)
    {
        var right = touchDir.x * Speed * transform.right;
        var forward = touchDir.y * Speed * transform.forward ;
        
        resultDir = right + forward + upVelocity;
        Controller.Move(resultDir * Time.deltaTime);
    }

    public void Jump()// dy=0.5*g* t^2
    {

        isGrounded = Controller.isGrounded;

        if (isGrounded && upVelocity.y < 0)
        {
            upVelocity.y = -2.0f;//small value, not 0 for remove jitter
        }

        if(isJumping && isGrounded)
        {
            upVelocity.y = Mathf.Sqrt(-2f * JumpHeight * gravity); //v=Sqrt(h*-2*g)
        }

        upVelocity.y += gravity*Time.deltaTime;
        upVelocity = new Vector3(0, upVelocity.y, 0);
    }


}
