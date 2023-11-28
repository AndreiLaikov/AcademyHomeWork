using UnityEngine;

public class RobotMover : MonoBehaviour
{
    public float moveVelocity = 5.0f;
    public float rotateVelocity = 1.0f;
    private Rigidbody rBody;
    private Vector3 halfScreen;
    private Vector3 deltaMousePos;
    private Vector3 prevMousePos;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();

        Vector3 screen = new Vector3();
        screen.x = Screen.width;
        screen.y = Screen.height;

        halfScreen = screen / 2;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = rBody.transform.forward * vertical + rBody.transform.right * horizontal;
        rBody.velocity = movement * moveVelocity;
    }

    private void Rotate()
    {
        var mousePos = Input.mousePosition - halfScreen; //mousepos in +-half screen
        Vector3 mousePosNormalize = new Vector3(mousePos.x / halfScreen.x, mousePos.y / halfScreen.y, 0);

        deltaMousePos = mousePosNormalize - prevMousePos;
        prevMousePos = mousePosNormalize;

        var targetRotationY = Quaternion.AngleAxis(deltaMousePos.x * rotateVelocity, transform.up);
        rBody.rotation *= targetRotationY;
    }

}
