using Stackspire.Combat;
using Stackspire.Player;
using Stackspire.Rooms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stackspire.Run
{
    [DisallowMultipleComponent]
    public sealed class RunEndController : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private RunScoreCounter scoreCounter;
        [SerializeField] private RunCoinCounter coinCounter;
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private string gameOverSceneName = "GameOver";
        [SerializeField] private int placeholderExistingBankedCoins;

        private bool runEnded;

        private void Awake()
        {
            if (playerHealth == null)
            {
                playerHealth = UnityEngine.Object.FindFirstObjectByType<PlayerHealth>();
            }

            if (scoreCounter == null)
            {
                scoreCounter = UnityEngine.Object.FindFirstObjectByType<RunScoreCounter>();
            }

            if (coinCounter == null)
            {
                coinCounter = UnityEngine.Object.FindFirstObjectByType<RunCoinCounter>();
            }

            if (roomManager == null)
            {
                roomManager = UnityEngine.Object.FindFirstObjectByType<RoomManager>();
            }

            placeholderExistingBankedCoins = Mathf.Max(0, placeholderExistingBankedCoins);
        }

        private void OnEnable()
        {
            if (playerHealth != null)
            {
                playerHealth.Died += HandlePlayerDied;
            }
        }

        private void OnValidate()
        {
            placeholderExistingBankedCoins = Mathf.Max(0, placeholderExistingBankedCoins);
        }

        private void OnDisable()
        {
            if (playerHealth != null)
            {
                playerHealth.Died -= HandlePlayerDied;
            }
        }

        private void HandlePlayerDied(DamagePayload killedBy)
        {
            if (runEnded)
            {
                return;
            }

            runEnded = true;
            int currentRunCoins = coinCounter == null ? 0 : coinCounter.CurrentRunCoins;
            int totalBankedCoins = placeholderExistingBankedCoins + currentRunCoins;
            RunResult result = new RunResult(
                scoreCounter == null ? 0 : scoreCounter.CurrentRunScore,
                GetRoomsClimbed(),
                currentRunCoins,
                totalBankedCoins,
                killedBy.SourceLabel);

            LastRunResult.Set(result);
            SceneManager.LoadScene(gameOverSceneName);
        }

        private int GetRoomsClimbed()
        {
            int currentRoomNumber = roomManager == null ? 1 : roomManager.CurrentRoomNumber;
            return Mathf.Max(0, currentRoomNumber - 1);
        }
    }
}
