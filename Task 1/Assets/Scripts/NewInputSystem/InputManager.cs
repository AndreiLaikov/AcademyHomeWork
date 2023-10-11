using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputMap inputMap;
    private TouchScreenInput touchScreenInput;
    public RectTransform MovingZone;

    public event Action<Vector2> MovingInputRecieved;//for say outside: we recieved

    private void Awake()
    {
        inputMap = new InputMap();
        inputMap.Enable();

        InitTouchScreenInput();
    }

    void InitTouchScreenInput()
    {
        touchScreenInput = new TouchScreenInput(inputMap, MovingZone);
        touchScreenInput.MovingInputReceiver += OnMovingInputReceiver;
    }

    private void OnMovingInputReceiver(Vector2 delta)
    {
        MovingInputRecieved?.Invoke(delta);
    }
}
