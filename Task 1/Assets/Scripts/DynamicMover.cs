using UnityEngine;

public class DynamicMover : MonoBehaviour
{
    public float SpeedX;
    public float Length;

    private Rigidbody2D rBody;

    public enum MovingType
    {
        None,
        PingPong,
        OneWay
    };

    public MovingType currentType;

    private Vector2 startPos;
    private Vector2 newPos;

    private void Start()
    {
        startPos = transform.position;
        rBody = GetComponent<Rigidbody2D>();
    }

    void PingPongMove()
    {
        newPos = new Vector2(Mathf.PingPong(Time.time * SpeedX, Length), 0);
        rBody.MovePosition(newPos + startPos);
    }

    void OneWayMove()
    {
        newPos += new Vector2(SpeedX * Time.deltaTime, 0);
        rBody.MovePosition(newPos + startPos);

        if(newPos.magnitude > Length)
        {
            DestroyEnemy();
        }
    }

    private void Update()
    {
        switch (currentType)
        {
            case MovingType.None:
                break;
            case MovingType.PingPong:
                PingPongMove();
                break;
            case MovingType.OneWay:
                OneWayMove();
                break;
            default:
                break;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
