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
    private bool isJumping;
    public float jumpVelocity = 8f;
    public float minDistanceToGround = 1f;
    [SerializeField] private bool isGrounded;
    public float animationBlendSpeed = 0.2f;
    private float targetAnimationSpeed;

    [SerializeField]private bool isSpawning;
    [SerializeField]private bool IsDeath;
    [SerializeField]private LayerMask isGroundedMask;
    [SerializeField] private bool isFighting;

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

    private void Update()
    {
        
        Gravity();

        Death();
        if (IsDeath)
            return;

        Spawn();
        if (isSpawning)
            return;

        Move();
        Jump();
        Fight();
    }

    private void Spawn()
    {
        var clipName = CharAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        isSpawning = clipName == "EllenSpawn";
    }

    private void Death()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, isGroundedMask);
        Controller.Move(Vector3.up * yVelocity * Time.deltaTime);
    }

    private void Fight()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            int i = Random.Range(0, 3);
            CharAnimator.SetInteger("ComboNum", i);
            CharAnimator.SetTrigger("Fight");
            isFighting = true;
        }

        CharAnimator.applyRootMotion = isFighting;
    }

    public void OnFightEnd()
    {
        isFighting = false;
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

        Quaternion currentRot = Controller.transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0, rotationAngle, 0);

        Controller.transform.rotation = Quaternion.Lerp(currentRot, targetRot, RotationSpeed);

        CharAnimator.SetFloat("Speed", Mathf.Lerp(CharAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            yVelocity += jumpVelocity;
            CharAnimator.SetTrigger("Jump");
        }

        if(isJumping && yVelocity < 0f)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,Vector3.down,out hit, minDistanceToGround, LayerMask.GetMask("Default")))
            {
                isJumping = false;
                CharAnimator.SetTrigger("Land");
            }
        }

        CharAnimator.SetFloat("SpeedY", yVelocity / jumpVelocity);
    }
}
