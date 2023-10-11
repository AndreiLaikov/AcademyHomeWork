using UnityEngine;
using System;

public class MouseInput : MonoBehaviour
{
    public event Action<Vector2> MovingInputReciever;

    private void OnMouseMove()
    {
        var yRot = Input.GetAxis("Mouse X");
        var xRot = Input.GetAxis("Mouse Y");
        Vector2 delta = new Vector2(yRot, xRot);

        MovingInputReciever?.Invoke(delta);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            OnMouseMove();
        }
    }
}
