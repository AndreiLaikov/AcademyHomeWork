using UnityEngine;

public class PingPongLerp : MonoBehaviour
{
    //Движется из одной точки в другую и обратно

    public Vector3 point1;
    public Vector3 point2 = new Vector3(10, 10, 10);
    public float velocity = 5;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isBackward;

    private float time;

    void Start()
    {
        transform.position = point1;
        isBackward = false;
    }


    void Update()
    {
        startPos = isBackward ? point2 : point1;
        targetPos = isBackward ? point1 : point2;
        Move();
    }

    private void Move()
    {
        var dist = Vector3.Distance(point1, point2);
        var timeToMove = dist / velocity;
        time = time + Time.deltaTime;

        if (time >= timeToMove)
        {
            time = 0;
            isBackward = !isBackward;
        }

        transform.position = Vector3.Lerp(startPos, targetPos, time / timeToMove);

    }
}
