using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherMove : MonoBehaviour
{
    private Rigidbody rBody;
    public Vector3 currentVelocity;
    public float Speed;
    public float JumpForce;
    public bool isGrounded;

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        // что бы скорость была стабильной в любом случае
        // и учитывая что мы вызываем из FixedUpdate мы умножаем на fixedDeltaTimе
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                // Обратите внимание что я делаю на основе Vector3.up а не на основе transform.up
                // если наш персонаж это шар -- его up может быть в том числе и вниз и влево и вправо. 
                // Но нам нужен скачек только вверх! Потому и Vector3.up
                rBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag != ("Player"))
        {
            isGrounded = value;
        }
    }

    private void FixedUpdate()
    {
        Jump();
        Move();
    }

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
}
