using UnityEngine;

//ПОРАБОТАТЬ С ТАЧЕМ

public class Char : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed;

    private float yVel = 0;

    private CharacterController controller;
    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    void Update()
    {
        if (Controller.isGrounded && yVel < 0)
        {
            yVel = 0;
        }

        float horizontal = Input.GetAxis("Horizontal")* speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Mouse X")*speed;

        Vector3 movement = new Vector3(horizontal, gravity, vertical);

        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        Controller.transform.Rotate(Vector3.up, rotation);

        if (Input.GetButton("Jump") && Controller.isGrounded)
        {
            yVel += Mathf.Sqrt(-30 * gravity);
        }
        yVel += gravity * Time.deltaTime;

        Controller.Move(new Vector3(0, yVel, 0) * Time.deltaTime);
    }

}
