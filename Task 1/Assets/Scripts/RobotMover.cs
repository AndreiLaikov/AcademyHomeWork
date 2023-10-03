using UnityEngine;

public class RobotMover : MonoBehaviour
{
    public float moveVelocity = 5.0f;
    public float rotateValocity = 1.0f;

    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotate();   
    }

    private void Rotate()
    {
        float sideforce = Input.GetAxis("Horizontal") * rotateValocity;
        if (sideforce != 0)
        {
            rBody.angularVelocity = new Vector3(0, sideforce, 0);
        }
    }

    private void Move()
    {
        float forwardforce = Input.GetAxis("Vertical") * moveVelocity;
        if (forwardforce!=0)
        {
            rBody.velocity = rBody.transform.forward * forwardforce;
        }
    }

}
