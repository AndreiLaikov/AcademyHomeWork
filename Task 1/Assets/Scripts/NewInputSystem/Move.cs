using UnityEngine;
using TMPro;
using System;

public class Move : MonoBehaviour
{
    public InputManager inputManager;
    public float Speed = 10;
    public CharacterController Controller;

    private Vector3 resultDir;

    private void Start()
    {
        inputManager.MovingInputRecieved += OnMovingInputRecieved;
    }

    private void OnMovingInputRecieved(Vector2 delta)
    {
        var right = delta.x * Speed * transform.right;
        var forward = delta.y * Speed * transform.forward;
        
        resultDir = right + forward;

    }

    private void Update()
    {
        Controller.Move(resultDir * Time.deltaTime);
    }

    private void OnDestroy()
    {
        inputManager.MovingInputRecieved -= OnMovingInputRecieved;
    }
}
