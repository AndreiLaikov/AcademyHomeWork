using UnityEngine;

public class ParalaxMoving : MonoBehaviour
{

    public float velocity = 1;
    public bool isLeft;

    void Moving()
    {
        if (isLeft)
            transform.position += velocity* Vector3.right * Time.deltaTime;
        else
            transform.position += velocity * Vector3.left * Time.deltaTime;
    }

    void Paralax()
    {

    }

    private void Update()
    {
        Moving();
        Paralax();
    }
}
