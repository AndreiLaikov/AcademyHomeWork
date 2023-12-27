using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float MovingSpeed = 5.0f;
    public float SprintSpeed = 5.0f;
    public float RotationSpeed = 1.0f;
    public float jumpForce;
    public bool isGrounded;
    public LayerMask ignoredLayers;
    public float animationBlendSpeed = 0.2f;

    private float targetAnimationSpeed;
    private Rigidbody rBody;
    private Vector3 upAxis;
    private bool isSprint;
    private Camera CharCamera;
    private float rotationAngle;
    private Vector3 rotatedMovement;
    private float currentSpeed;
    private Animator CharAnimator;

    public List<Rigidbody> bodies;
    public bool isDeath;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        CharAnimator = GetComponent<Animator>();
        CharCamera = Camera.main;

        ignoredLayers = ~ignoredLayers;
    }

    private void Update()
    {
        if (isDeath)
        {
            CharAnimator.enabled = false;
            foreach (var body in bodies)
            {
                body.isKinematic = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDeath)
            return;

        GroundCheck();
        MoveInput();
        JumpInput();
        Quaternion currentRot = rBody.rotation;
        Quaternion targetRot = Quaternion.Euler(0, rotationAngle, 0);

        rBody.velocity = rotatedMovement * currentSpeed + upAxis;
        rBody.rotation = Quaternion.Lerp(currentRot, targetRot, RotationSpeed);
    }

    private void MoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        isSprint = Input.GetKey(KeyCode.LeftShift);

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rotatedMovement = Quaternion.Euler(0f, CharCamera.transform.rotation.eulerAngles.y, 0f) * movement.normalized;

        currentSpeed = isSprint ? SprintSpeed : MovingSpeed;

        if (rotatedMovement.sqrMagnitude > 0.0f)
        {
            rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            targetAnimationSpeed = isSprint ? 1 : 0.5f;
        }
        else
        {
            targetAnimationSpeed = 0;
        }

        CharAnimator.SetFloat("Speed", Mathf.Lerp(CharAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
    }

    private void JumpInput()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rBody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            CharAnimator.SetTrigger("Jump");
        }

        upAxis = rBody.velocity.y * Vector3.up;
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.3f, ignoredLayers);
    }

}
