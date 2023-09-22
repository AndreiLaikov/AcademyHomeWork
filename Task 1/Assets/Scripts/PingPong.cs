using UnityEngine;

public class PingPong : MonoBehaviour
{
    //Движется из одной точки в другую и обратно

    public Vector3 point1;
    public Vector3 point2 = new Vector3(10, 10, 10);
    public float velocity = 5;

    private Vector3 targetPos;
    private bool isBackward;

    void Start()
    {
        transform.position = point1;
        isBackward = false;
    }


    void Update()
    {
        targetPos = isBackward ? point1 : point2;
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, velocity * Time.deltaTime);

        if(Vector3.Distance(targetPos, transform.position)<0.001f)
            isBackward = !isBackward;
    }
}
