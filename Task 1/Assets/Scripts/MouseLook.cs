using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform Camera;
    public float MouseSensitivity;
    public Vector2 RotationRestriction;
    private float xRotation;


    private void Start()
    {
        if(Camera == null)
        {
            Debug.LogError("Missing camera");
        }
    }


    public void LookWithTouch(Vector2 touchDir)
    {
        float yRotation = touchDir.x * MouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);

        float mouseY = touchDir.y * MouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, RotationRestriction.x, RotationRestriction.y);

        Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
