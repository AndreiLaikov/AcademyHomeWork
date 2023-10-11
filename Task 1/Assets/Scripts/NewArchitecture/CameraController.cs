using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraPivot;
    public float MouseSensitivity = 1000;
    public Vector2 RotationRestriction = new Vector2(-20, 30);
    private float xRotation = 0;

    private MouseInput mInput;

    private void Start()
    {
        mInput = gameObject.AddComponent<MouseInput>();
        mInput.MovingInputReciever += LookWithTouch;
    }

    private void LookWithTouch(Vector2 delta)
    {
        float yRotation = delta.x * MouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up, yRotation);

        float mouseY = delta.y * MouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, RotationRestriction.x, RotationRestriction.y);

        CameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
