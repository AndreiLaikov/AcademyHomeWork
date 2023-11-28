using UnityEngine;

public class MouseAiming : MonoBehaviour
{
    public float Sensitivity;
    public float MaxAngle;

    private Vector3 halfScreen;
    private Vector3 deltaMousePos;
    private Vector3 prevMousePos;

    private void Start()
    {
        Vector3 screen = new Vector3();
        screen.x = Screen.width;
        screen.y = Screen.height;

        halfScreen = screen / 2;
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        var mousePos = Input.mousePosition - halfScreen; //mousepos in +-half screen
        Vector3 mousePosNormalize = new Vector3(mousePos.x / halfScreen.x, mousePos.y / halfScreen.y, 0);

        deltaMousePos = mousePosNormalize - prevMousePos;
        prevMousePos = mousePosNormalize;

        var targetRotationX = Quaternion.AngleAxis(-deltaMousePos.y * Sensitivity, transform.right);

        Quaternion resultQuat = targetRotationX * transform.rotation;

        if (Quaternion.Angle(transform.rotation, resultQuat) < MaxAngle)
        {
            transform.rotation = resultQuat;
        }

    }
}
