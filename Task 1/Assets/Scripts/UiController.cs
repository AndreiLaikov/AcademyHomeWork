using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public Button ButtonStart;
    public Button ButtonRestart;
    public TMP_Text CurrentScore;
    public TMP_Text MaxScore;

    public GameController gameController;

    private void Start()
    {
        ButtonStart.onClick.AddListener(OnButtonStartClick);
        ButtonRestart.onClick.AddListener(OnButtonRestartClick);
        ButtonRestart.gameObject.SetActive(false);

        EventManager.GameEnding += OnGameEnding;
        EventManager.PlaceSuccess += OnPlaceSuccess;
        MaxScore.text = gameController.MaxScore.ToString();
        CurrentScore.text = gameController.Score.ToString();
    }

    private void OnPlaceSuccess(int count)
    {
        CurrentScore.text = count.ToString();
    }

    private void OnGameEnding()
    {
        ButtonRestart.gameObject.SetActive(true);
        MaxScore.text = gameController.MaxScore.ToString();
    }

    private void OnButtonStartClick()
    {
        EventManager.OnGameStarting();
        ButtonStart.gameObject.SetActive(false);
    }

    private void OnButtonRestartClick()
    {
        EventManager.OnGameStarting();
        ButtonRestart.gameObject.SetActive(false);
    }
}
