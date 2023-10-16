using UnityEngine;

public class InfinityMove : MonoBehaviour
{
    public Transform Level;
    public Transform Player;
    public float height = 4;

    public Transform[] floors;

    [ContextMenu ("Create")]
    public void FloorTeleport()
    {
        if (Player.localPosition.y > 4)
        {
            foreach (var floor in floors)
            {
                if (Player.localPosition.y - floor.localPosition.y > 8)
                {
                    floor.localPosition += 12 * Vector3.up;
                }
                floor.localPosition -= 4 * Vector3.up;
            }
            Player.localPosition -= 4 * Vector3.up;
        }
    }

    private void LateUpdate()
    {
        FloorTeleport();
    }
    
}
