using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float timeToTeleport = 1;
    public Vector3 minPos;
    public Vector3 maxPos;

    private float time;

    void Update()
    {
        time = time + Time.deltaTime;
        if(time >= timeToTeleport)
        {
            time = 0;
            RandomPos();
        }
    }

    private void RandomPos()
    {
        transform.position = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), Random.Range(minPos.z, maxPos.z));
    }
}
