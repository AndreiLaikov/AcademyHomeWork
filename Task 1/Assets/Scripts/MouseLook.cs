using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform Body;
    public float MouseSensitivity;
    public Vector2 RotationRestriction;
    private float xRotation;


    private void Start()
    {
        if(Body == null)
        {
            Debug.LogError("Missing body");
        }
    }


    public void LookWithTouch(Vector2 touchDir)
    {
        float yRotation = touchDir.x * MouseSensitivity * Time.deltaTime;
        Body.Rotate(Vector3.up, yRotation);

        float mouseY = touchDir.y * MouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, RotationRestriction.x, RotationRestriction.y);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
