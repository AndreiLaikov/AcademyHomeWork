using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float MovementSpeed = 10f;
    public float SprintSpeed = 20f;
    public float RotationSpeed = 0.1f;

    private CharacterController controller;
    private Camera charCamera;
    private float rotationAngle = 0f;

    private bool isSprint;

    [SerializeField]private float yVelocity = 0f;
    private const float gravity = -9.81f;
    [SerializeField]private bool isJumping;
    public float jumpVelocity = 8f;
    public float minDistanceToGround = 1f;

    public bool isGrounded;

    public CharacterController Controller
    {
        get { return controller ?? GetComponent<CharacterController>(); }
    }

    public Camera CharCamera
    {
        get { return charCamera ?? FindObjectOfType<Camera>(); }
    }


    private void Update()
    {
        Move();
        Jump();
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
        }

        Quaternion currentRot = Controller.transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0, rotationAngle, 0);

        Controller.transform.rotation = Quaternion.Lerp(currentRot, targetRot, RotationSpeed);
    }

 

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            yVelocity += jumpVelocity;
        }

        if (!isGrounded)
        {
            yVelocity += gravity * Time.deltaTime;
        }
        else if (yVelocity < 0f)
        {
            yVelocity = -1f;
        }

        if(isJumping && yVelocity < 0f)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,Vector3.down,out hit, minDistanceToGround, LayerMask.GetMask("Default")))
            {
                isJumping = false;
            }
        }

        Controller.Move(Vector3.up * yVelocity * Time.deltaTime);
        isGrounded = Controller.isGrounded;
    }
}
