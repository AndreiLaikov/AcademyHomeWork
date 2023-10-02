using UnityEngine;

public class PlaneRotate : MonoBehaviour
{
    private Transform root;

    public float velocity;

    private float prevMousePos;
    private float deltaMousePos;
    private float mousePos;
    private Quaternion deltaRot;

    private void Start()
    {
        root = this.transform;
    }

    private void Update()
    {
        mousePos = Input.mousePosition.x - Screen.width;
        if (Input.GetMouseButton(0))
        {
            deltaMousePos = prevMousePos - mousePos;
            deltaRot = Quaternion.AngleAxis(deltaMousePos * velocity, root.up);
        }
        else
        {
            deltaRot = Quaternion.identity;
        }

        prevMousePos = mousePos;
        root.rotation = deltaRot * root.rotation;
    }
} 
