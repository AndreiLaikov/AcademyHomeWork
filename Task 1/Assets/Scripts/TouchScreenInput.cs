using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchScreenInput
{
    public event Action<Vector2> MovingInputReceiver;

    private InputMap _inputMap;//Action Input in Unity
    private RectTransform _inputMoveRect;

    Vector2 startTouchPosition;
    Vector2 delta;

    public TouchScreenInput(InputMap inputMap, RectTransform inputMoveRect)
    {
        _inputMap = inputMap;
        _inputMoveRect = inputMoveRect;

        _inputMap.TouchScreen.TouchStart.started += OnTouchStarted;
        _inputMap.TouchScreen.TouchStart.canceled += OnTouchCanceled;

    }

    private void OnTouchStarted(InputAction.CallbackContext context)
    {
        var currentTouchPos = _inputMap.TouchScreen.TouchPosition.ReadValue<Vector2>();
        bool isInMoveRect = RectTransformUtility.RectangleContainsScreenPoint(_inputMoveRect, currentTouchPos);
    
        if (isInMoveRect)
        {
            startTouchPosition = currentTouchPos;
            _inputMap.TouchScreen.TouchDelta.performed += OnTouchDeltaPerformed;
        }
    }

    private void OnTouchCanceled(InputAction.CallbackContext context)
    {
        delta = Vector2.zero;
        MovingInputReceiver?.Invoke(delta.normalized);
        
        _inputMap.TouchScreen.TouchDelta.performed -= OnTouchDeltaPerformed;
    }

    private void OnTouchDeltaPerformed(InputAction.CallbackContext context)
    {
        var currentTouchPos = _inputMap.TouchScreen.TouchPosition.ReadValue<Vector2>();
        bool isInRect = RectTransformUtility.RectangleContainsScreenPoint(_inputMoveRect, currentTouchPos);

        delta = currentTouchPos - startTouchPosition;

        if (!isInRect)
        { 
            delta = Vector2.zero;
        }

        MovingInputReceiver?.Invoke(delta.normalized);//Say outside: we got Input
    }
}
