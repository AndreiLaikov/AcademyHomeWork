using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace StackApp.UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private Button ButtonStart;
        [SerializeField] private Button ButtonRestart;
        [SerializeField] private TMP_Text CurrentScore;
        [SerializeField] private TMP_Text HighScore;

        private Player.Player currentPlayer;

        private void Start()
        {
            ButtonRestart.gameObject.SetActive(false);
            ButtonStart.onClick.AddListener(OnButtonStartClick);
            ButtonRestart.onClick.AddListener(OnButtonRestartClick);
        }

        private IEnumerator ShowButton()
        {
            yield return new WaitForSeconds(1f);
            ButtonRestart.gameObject.SetActive(true);
        }

        public void Initialize(Player.Player player)
        {
            currentPlayer = player;
            ChangeScore();
        }

        public void ChangeScore()
        {
            CurrentScore.text = currentPlayer.CurrentScore.ToString();
            HighScore.text = "High score: " + currentPlayer.HighScore.ToString();
        }

        public void ShowRestartUi()
        {
            StartCoroutine(ShowButton());
        }

        private void OnButtonRestartClick()
        {
            ButtonRestart.gameObject.SetActive(false);
            ButtonStart.gameObject.SetActive(true);
            EventController.GameRestart();
        }

        private void OnButtonStartClick()
        {
            ButtonStart.gameObject.SetActive(false);
            EventController.GameStart();
        }

        private void OnDestroy()
        {
            ButtonStart.onClick.RemoveListener(OnButtonStartClick);
            ButtonRestart.onClick.RemoveListener(OnButtonRestartClick);
        }
    }
}
