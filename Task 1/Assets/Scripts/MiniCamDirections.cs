using UnityEngine;
using UnityEngine.UI;

public class MiniCamDirections : MonoBehaviour
{
    public Button btnUp;
    public Button btnDown;
    public Button btnFront;
    public Button btnLeft;

    private Vector3 up = new Vector3(0, 0, 0);
    private Vector3 down = new Vector3(180, 0, 0);
    private Vector3 front = new Vector3(90, 0, 0);
    private Vector3 left = new Vector3(90, 90, 0);

    private DirEnum currentDir;

    private void Start()
    {
        currentDir = GetComponent<DirEnum>();

        btnUp.onClick.AddListener(()=>SetDirection(btnUp.GetComponent<DirEnum>()));
        btnDown.onClick.AddListener(()=>SetDirection(btnDown.GetComponent<DirEnum>()));
        btnFront.onClick.AddListener(() => SetDirection(btnFront.GetComponent<DirEnum>()));
        btnLeft.onClick.AddListener(() => SetDirection(btnLeft.GetComponent<DirEnum>()));
    }

    private void SetDirection(DirEnum direction)
    {
        currentDir.dir = direction.dir;

        switch (currentDir.dir)
        {
            case DirEnum.Directions.Up:
                transform.localRotation = Quaternion.Euler(up);
                break;
            case DirEnum.Directions.Down:
                transform.localRotation = Quaternion.Euler(down);
                break;
            case DirEnum.Directions.Left:
                transform.localRotation = Quaternion.Euler(left);
                break;
            case DirEnum.Directions.Front:
                transform.localRotation = Quaternion.Euler(front);
                break;
        }
    }

}
