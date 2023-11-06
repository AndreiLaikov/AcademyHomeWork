using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 initialSize;
    public Vector3 initialPosition;
    public Vector3 startMovingPosition = new Vector3(-1.5f, 0, 0);

    private GameLogic logic;
    public int Score { get; private set; }
    public int MaxScore { get; private set; }

    private bool isStarting;

    private void Start()
    {
        logic = GetComponent<GameLogic>();
        logic.Init(initialSize,initialPosition);
        Score = logic.Count;
        EventManager.GameStarting += OnGameStarting;
        EventManager.PlaceSuccess += OnPlaceSuccess;
        EventManager.GameEnding += OnGameEnding;
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
    }

    public void OnGameStarting()
    {
        logic.Init(initialSize, initialPosition);
        Score = logic.Count;
        logic.CreateMovingBlock(startMovingPosition);
        isStarting = true;
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
