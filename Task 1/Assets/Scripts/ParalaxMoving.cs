using UnityEngine;

public class ParalaxMoving : MonoBehaviour
{
    private SpriteRenderer sprite;

    private float leftBorder;
    private float rightBorder;

    public float SpeedMultiplier = 1;
    private float charSpeed;
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
        var deltaPos = charSpeed * SpeedMultiplier * Vector3.right * Time.deltaTime;
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
        isLeft = CharController.isLeft;
        charSpeed = CharController.Speed;

        Moving();
        Paralax();
    }
}
