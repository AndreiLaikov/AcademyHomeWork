using System;
using UnityEngine;

public class DesktopInput: MonoBehaviour
{
    public event Action<Vector2> MovingInputReciever;
    public event Action<bool> JumpingInputReciever;

    private void OnButtonsMoveClick()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");
        Vector2 delta = new Vector2(deltaX, deltaY);

        MovingInputReciever?.Invoke(delta);
    }

    void OnButtonJumpClick()
    {
        bool isJumping = Input.GetButton("Jump");

        JumpingInputReciever?.Invoke(isJumping);
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            OnButtonsMoveClick();
        }

        if (Input.GetButton("Jump"))
        {
            OnButtonJumpClick();
        }
    }
}
