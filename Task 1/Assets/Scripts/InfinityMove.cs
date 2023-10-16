using UnityEngine;

public class InfinityMove : MonoBehaviour
{
    public Transform Player;
    public float FloorHeight = 4;
    public Transform[] floors;

    private int floorCount;

    private void Start()
    {
        floorCount = floors.Length;
    }

    public void FloorTeleportUp(int sign)
    {
        foreach (var floor in floors)
        {
            if (Player.position.y - floor.position.y > sign * 3 * FloorHeight)
            {
                floor.position += sign * floorCount * FloorHeight * Vector3.up;
            }
            floor.position -= sign * FloorHeight * Vector3.up;
        }

        Player.position -= sign * FloorHeight * Vector3.up;
    }

    public void FloorTeleportDown(int sign)
    {
        foreach (var floor in floors)
        {
            if (Player.position.y - floor.position.y < sign * 3 * FloorHeight)
            {
                floor.position += sign * floorCount * FloorHeight * Vector3.up;
            }

            floor.position -= sign * FloorHeight * Vector3.up;
        }
        Player.position -= sign * FloorHeight * Vector3.up;
    }

    private void FixedUpdate()
    {
        
        if (Player.position.y > FloorHeight)
        {
            FloorTeleportUp(1);
        }
        if (Player.position.y < -FloorHeight)
        {
            FloorTeleportDown(-1);
        }
    }
}
