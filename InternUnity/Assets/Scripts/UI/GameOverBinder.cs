using Stackspire.Run;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Stackspire.UI
{
    [DisallowMultipleComponent]
    public sealed class GameOverBinder : MonoBehaviour
    {
        [SerializeField] private Text finalScoreText;
        [SerializeField] private Text roomsClimbedText;
        [SerializeField] private Text currentRunCoinsText;
        [SerializeField] private Text totalBankedCoinsText;
        [SerializeField] private Text killedByText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private string classSelectSceneName = "ClassSelect";
        [SerializeField] private string mainMenuSceneName = "MainMenu";

        private void OnEnable()
        {
            if (restartButton != null)
            {
                restartButton.onClick.AddListener(Restart);
            }

            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.AddListener(LoadMainMenu);
            }

            Refresh();
        }

        private void OnDisable()
        {
            if (restartButton != null)
            {
                restartButton.onClick.RemoveListener(Restart);
            }

            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.RemoveListener(LoadMainMenu);
            }
        }

        /// <summary>
        /// Rebinds the visible GameOver stat labels from the latest run result.
        /// </summary>
        public void Refresh()
        {
            RunResult result = LastRunResult.Result;
            SetText(finalScoreText, $"Final Score {result.FinalScore:0000}");
            SetText(roomsClimbedText, $"Rooms Climbed {result.RoomsClimbed}");
            SetText(currentRunCoinsText, $"Coins Earned {result.CurrentRunCoins:000}");
            SetText(totalBankedCoinsText, $"Banked Coins {result.TotalBankedCoins:000}");
            SetText(killedByText, $"Killed By {result.KilledBySource}");
        }

        /// <summary>
        /// Returns to class selection for the next run.
        /// </summary>
        public void Restart()
        {
            LastRunResult.Clear();
            SceneManager.LoadScene(classSelectSceneName);
        }

        /// <summary>
        /// Returns to the main menu.
        /// </summary>
        public void LoadMainMenu()
        {
            LastRunResult.Clear();
            SceneManager.LoadScene(mainMenuSceneName);
        }

        private static void SetText(Text target, string value)
        {
            if (target != null)
            {
                target.text = value;
            }
        }
    }
}
