using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 initialSize;
    public Vector3 initialPosition;
    public Vector3 startingBoxPosition;
    public Vector3 startMovingPosition = new Vector3(-1.5f, 0, 0);

    private GameLogic logic;
    private Camera cam;
    private Vector3 cameraStartPos;
    public int Score { get; private set; }
    public int MaxScore { get; private set; }

    private bool isStarting;

    private void Start()
    {
        logic = GetComponent<GameLogic>();
        logic.Init(initialSize,initialPosition);

        var posY = Mathf.Abs(startingBoxPosition.y*2 + initialSize.y / 2);
        logic.GenerateStartingBox(new Vector3(initialSize.x, posY,initialSize.z),startingBoxPosition);

        Score = logic.Count;
        EventManager.GameStarting += OnGameStarting;
        EventManager.PlaceSuccess += OnPlaceSuccess;
        EventManager.GameEnding += OnGameEnding;
        cam = Camera.main;
        cameraStartPos = cam.transform.position;
    }

    private void OnGameEnding()
    {
        if (Score>MaxScore)
        {
            MaxScore = Score;
        }
        isStarting = false;
    }

    private void OnPlaceSuccess(int count)
    {
        logic.CreateMovingBlock(startMovingPosition);
        Score = count;
        cam.transform.position += Vector3.up * initialSize.y;
    }

    public void OnGameStarting()
    {
        logic.Init(initialSize, initialPosition);
        Score = logic.Count;
        var posY = Mathf.Abs(startingBoxPosition.y * 2 + initialSize.y / 2);
        logic.GenerateStartingBox(new Vector3(initialSize.x, posY, initialSize.z), startingBoxPosition);

        logic.CreateMovingBlock(startMovingPosition);
        isStarting = true;
        cam.transform.position = cameraStartPos;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& isStarting)
        {
            logic.GenerateNewMeshes();
        }
    }

    private void OnDestroy()
    {
        EventManager.GameStarting -= OnGameStarting;
        EventManager.PlaceSuccess -= OnPlaceSuccess;
        EventManager.GameEnding -= OnGameEnding;
    }

}
