using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform Body;
    public Transform rotationPivot;
    public float distance;
    public float MouseSensitivity;
    public Vector2 RotationRestriction;
    private float xRotation;


    private Quaternion tQuat;
    private Quaternion endQuat;

    private void Start()
    {
        if(Body == null)
        {
            Debug.LogError("Missing body");
        }

       // tQuat = transform.rotation;
       // endQuat = transform.rotation;
    }

    private void HorizontalRotation()
    {
        float yRotation = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;

        Body.Rotate(Vector3.up, yRotation);
    }

    private void VerticalRotation()
    {
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, RotationRestriction.x, RotationRestriction.y);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
    }

    private void CamRot()
    {
        var newPos = endQuat * Vector3.forward * (-distance);
        transform.localPosition = newPos;

        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;
        var delta = Quaternion.AngleAxis(mouseY, transform.right);
        tQuat = delta * tQuat;

        endQuat = tQuat;
       
    }

    private void CamLookAt()
    {
        var camOnObj = rotationPivot.position - transform.position;
        transform.rotation = Quaternion.LookRotation(camOnObj, Vector3.up);
    }

    private void Update()
    {
        HorizontalRotation();
        VerticalRotation();

        //CamRot();
        //CamLookAt();
    }
}
