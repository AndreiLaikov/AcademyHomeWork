using UnityEngine;

//ПОРАБОТАТЬ С ТАЧЕМ

public class Char : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed;

    public bool isReadyToJump;

    private float jump;

    private CharacterController controller;
    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float rotation = Input.GetAxis("Mouse X");


        if (isReadyToJump && Input.GetKeyDown(KeyCode.Space))
        {
            jump = 1;
        }
        else
        {
            jump = 0;
        }    

        Vector3 movement = new Vector3(horizontal * speed, gravity+jump*speed, vertical * speed);

        //Controller.SimpleMove(transform.TransformDirection(movement));
        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        Controller.transform.Rotate(Vector3.up, rotation);

        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        isReadyToJump = true;
    }
}
