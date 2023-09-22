using UnityEngine;

public class PingPong : MonoBehaviour
{
    //Движется из одной точки в другую и обратно

    public Vector3 point1;
    public Vector3 point2 = new Vector3(10, 10, 10);
    public float velocity = 5;

    private Vector3 targetpos;
    private bool isBackward;

    void Start()
    {
        transform.position = point1;
        isBackward = false;
    }


    void Update()
    {
        if (isBackward)
            targetpos = point1;
        else
            targetpos = point2;

        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetpos, velocity * Time.deltaTime);

      //  if (transform.position == targetpos)
        //    isBackward = !isBackward;

        if(Vector3.Distance(targetpos,transform.position)<0.01f)
            isBackward = !isBackward;
    }
}
