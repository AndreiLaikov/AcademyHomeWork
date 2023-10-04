using UnityEngine;

public class MouseAiming : MonoBehaviour
{
    public float xSensitive;
    public float ySensitive;
    private float yRot;
    private float xRot;
    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Aim()
    {
        xRot -= Input.GetAxis("Mouse Y") * xSensitive;
        xRot = Mathf.Clamp(xRot, -40, 10);

        yRot += Input.GetAxis("Mouse X") * ySensitive;

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
    }

    private void Update()
    {
        rBody.isKinematic = Input.GetMouseButton(0);

        if (Input.GetMouseButton(0))
            Aim();
       
    }
}
