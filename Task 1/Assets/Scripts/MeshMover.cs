using UnityEngine;

public class MeshMover : MonoBehaviour
{
    public float velocity;
    public float distance;
    public bool isMoving = true;

    public float targetPosX;
    private float time = 0;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (isMoving)
            PingPongMove();
    }

    void PingPongMove()
    {
        time += Time.deltaTime;
        targetPosX = Mathf.PingPong(velocity * time, distance);
        transform.position = new Vector3(targetPosX+startPos.x, startPos.y, startPos.z);
    }
}
