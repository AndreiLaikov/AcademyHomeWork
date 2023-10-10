using UnityEngine;
using TMPro;
using System;

public class TouchController : MonoBehaviour
{
    public Vector2 startMovePos;
    public Vector2 sumMoveVector;

    public Vector2 startLookPos;
    public Vector2 sumLookVector;

    public CharacterMove character;
    public MouseLook cam;

    private float halfScreen;

    private void Start()
    {
        halfScreen = Screen.width / 2;
    }

    private void Update()
    {
        Drag();
        Jump();
        character.MoveWithTouch(sumMoveVector);
        cam.LookWithTouch(sumLookVector);
    }

    void Jump()
    {
        character.isJumping = false;
        Touch[] touches = Input.touches;
        for (int i = 0; i < touches.Length; i++)
        {
            if (touches[i].phase == TouchPhase.Began && touches[i].tapCount == 2)
            {
                character.isJumping = true;
            }
        }
    }

    void Drag()
    {
        Touch[] touches = Input.touches;
        
        for (int i = 0; i < touches.Length; i++)
        {

            if (touches[i].position.x < halfScreen)
            {
                if (touches[i].phase == TouchPhase.Began)
                {
                    startMovePos = touches[i].position;
                   
                }
                if (touches[i].phase == TouchPhase.Moved || touches[i].phase == TouchPhase.Stationary)
                {
                    sumMoveVector = (touches[i].position - startMovePos).normalized;
                }
                if (touches[i].phase == TouchPhase.Ended)
                {
                    sumMoveVector = Vector2.zero; 
                }
            }
            else
            {
                sumMoveVector = Vector2.zero;

                if (touches[i].phase == TouchPhase.Began)
                {
                    startLookPos = touches[i].position;
                }
                if (touches[i].phase == TouchPhase.Moved || touches[i].phase == TouchPhase.Stationary)
                {
                    sumLookVector = (touches[i].position - startLookPos).normalized;
                    startLookPos = touches[i].position;
                }
                if (touches[i].phase == TouchPhase.Ended)
                {
                    sumLookVector = Vector2.zero;
                    
                }
            }
        }
    }
   
}
