using UnityEngine;

public class CharController : MonoBehaviour
{
    public float MovementSpeed = 10f;
    public float SprintSpeed = 20f;
    public float RotationSpeed = 0.1f;
    private float rotationAngle = 0f;
    private bool isSprint;
    private float yVelocity = 0f;
    private const float gravity = -9.81f;
    public float jumpVelocity = 8f;
    [SerializeField] private bool isGrounded;
    public float animationBlendSpeed = 0.2f;
    private float targetAnimationSpeed;

    [SerializeField]private bool IsDeath;
    [SerializeField]private LayerMask isGroundedMask;

    private Animator charAnimator;
    public Animator CharAnimator
    {
        get { return charAnimator ?? GetComponent<Animator>(); }
    }

    
    private CharacterController controller;
    public CharacterController Controller
    {
        get { return controller ?? GetComponent<CharacterController>(); }
    }

    private Camera charCamera;
    public Camera CharCamera
    {
        get { return charCamera ?? FindObjectOfType<Camera>(); }
    }


    private void Start()
    {
       
    }

    private void Update()
    {
        Gravity();

        /*
        Death();
        if (IsDeath)
            return;
        */

        Move();
        Jump();
    }


    private void Death()
    {
        if (Input.GetKeyDown(KeyCode.E) && !IsDeath)
        {
            CharAnimator.SetTrigger("Death");
            IsDeath = true;
        }
    }

    private void Gravity()
    {
        if (!isGrounded)
        {
            yVelocity += gravity * Time.deltaTime;
        }
        else if (yVelocity < 0f)
        {
            yVelocity = -1f;
        }
        //isGrounded = Controller.isGrounded;
        isGrounded = Physics.CheckSphere(transform.position, 0.2f, isGroundedMask);
        Controller.Move(Vector3.up * yVelocity * Time.deltaTime);
    }


    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        isSprint = Input.GetKey(KeyCode.LeftShift);

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        Vector3 rotatedMovement = Quaternion.Euler(0f, CharCamera.transform.rotation.eulerAngles.y, 0f) * movement.normalized;

        float currentSpeed = isSprint ? SprintSpeed : MovementSpeed;

        Controller.Move(rotatedMovement * currentSpeed * Time.deltaTime);

        if (rotatedMovement.sqrMagnitude > 0.0f)
        {
            rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            targetAnimationSpeed = isSprint ? 1 : 0.5f;
        }
        else
        {
            targetAnimationSpeed = 0;
        }

        Quaternion currentRot = Controller.transform.localRotation;
        Quaternion targetRot = Quaternion.Euler(0, rotationAngle, 0);

        Controller.transform.localRotation = Quaternion.Lerp(currentRot, targetRot, RotationSpeed);


        CharAnimator.SetFloat("Speed", Mathf.Lerp(CharAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            yVelocity += jumpVelocity;
            CharAnimator.SetTrigger("Jump");
        }
    }
}
