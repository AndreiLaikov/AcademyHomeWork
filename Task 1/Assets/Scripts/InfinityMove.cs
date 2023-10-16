using UnityEngine;

public class InfinityMove : MonoBehaviour
{
    public Transform Player;
    public float FloorHeight = 4;
    private int floorCount;
    public Transform[] floors;


    private void Start()
    {
        floorCount = floors.Length;
    }

    public void FloorTeleportUp()
    {
        if (Player.position.y > FloorHeight)
        {
            foreach (var floor in floors)
            {
                if (Player.position.y - floor.position.y > 3 * FloorHeight)
                {
                    floor.position += floorCount * FloorHeight * Vector3.up;
                }
                floor.position -= FloorHeight * Vector3.up;
            }
            Player.position -= FloorHeight * Vector3.up;
        }
    }

    public void FloorTeleportDown()
    {
        if (Player.position.y < -FloorHeight)
        {
            foreach (var floor in floors)
            {
                if (Player.position.y - floor.position.y < -3 * FloorHeight)
                {
                    floor.position -= floorCount * FloorHeight * Vector3.up;
                }
                floor.position += FloorHeight * Vector3.up;
            }
            Player.position += FloorHeight * Vector3.up;
        }
    }

    private void Teleport()
    {

    }

    private void LateUpdate()
    {
        FloorTeleportUp();
        FloorTeleportDown();
    }
    
}
