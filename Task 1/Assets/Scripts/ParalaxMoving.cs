using UnityEngine;

public class ParalaxMoving : MonoBehaviour
{
    private SpriteRenderer sprite;

    private float leftBorder;
    private float rightBorder;

    public float VelocityMultiplier = 1;
    private bool isLeft;

    private Vector3 cashedPos;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        
        rightBorder = sprite.size.x / 2;
        leftBorder = -rightBorder;

        cashedPos = transform.position;
    }

    void Moving()
    {
        var deltaPos = VelocityMultiplier * Vector3.right * Time.deltaTime;
        deltaPos = isLeft ? deltaPos : -deltaPos;

        transform.position += deltaPos;
    }

    void Paralax()
    {
        var posX = transform.position.x;

        if (posX <= leftBorder)
        {
            transform.position = new Vector3(rightBorder, cashedPos.y, cashedPos.z);
        }

        if (posX >= rightBorder)
        {
            transform.position = new Vector3(leftBorder, cashedPos.y, cashedPos.z);
        }
    }

    private void Update()
    {
        Moving();
        Paralax();
    }
}
