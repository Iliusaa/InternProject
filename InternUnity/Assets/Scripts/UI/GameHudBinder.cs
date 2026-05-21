using Stackspire.Player;
using Stackspire.Rooms;
using Stackspire.Run;
using UnityEngine;
using UnityEngine.UI;

namespace Stackspire.UI
{
    [DisallowMultipleComponent]
    public sealed class GameHudBinder : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private RunScoreCounter scoreCounter;
        [SerializeField] private RunCoinCounter coinCounter;
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private Text heartsText;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text roomText;
        [SerializeField] private Text coinsText;

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
        }

        private void OnEnable()
        {
            Subscribe();
            RefreshAll();
        }

        private void Start()
        {
            RefreshAll();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        /// <summary>
        /// Rebinds all HUD labels from the current gameplay state.
        /// </summary>
        public void RefreshAll()
        {
            RefreshHearts();
            RefreshScore();
            RefreshRoom();
            RefreshCoins();
        }

        private void Subscribe()
        {
            if (playerHealth != null)
            {
                playerHealth.HealthChanged += HandleHealthChanged;
            }

            if (scoreCounter != null)
            {
                scoreCounter.ScoreChanged += HandleScoreChanged;
            }

            if (coinCounter != null)
            {
                coinCounter.CoinsChanged += HandleCoinsChanged;
            }

            if (roomManager != null)
            {
                roomManager.RoomAdvanced += HandleRoomChanged;
            }
        }

        private void Unsubscribe()
        {
            if (playerHealth != null)
            {
                playerHealth.HealthChanged -= HandleHealthChanged;
            }

            if (scoreCounter != null)
            {
                scoreCounter.ScoreChanged -= HandleScoreChanged;
            }

            if (coinCounter != null)
            {
                coinCounter.CoinsChanged -= HandleCoinsChanged;
            }

            if (roomManager != null)
            {
                roomManager.RoomAdvanced -= HandleRoomChanged;
            }
        }

        private void HandleHealthChanged(int currentHearts, int maxHearts)
        {
            SetHearts(currentHearts, maxHearts);
        }

        private void HandleScoreChanged(int score)
        {
            SetScore(score);
        }

        private void HandleCoinsChanged(int coins)
        {
            SetCoins(coins);
        }

        private void HandleRoomChanged(int roomNumber)
        {
            SetRoom(roomNumber);
        }

        private void RefreshHearts()
        {
            if (playerHealth == null)
            {
                SetHearts(0, 0);
                return;
            }

            int currentHearts = playerHealth.CurrentHearts;
            if (currentHearts == 0 && playerHealth.MaxHearts > 0 && !playerHealth.IsDead)
            {
                currentHearts = playerHealth.MaxHearts;
            }

            SetHearts(currentHearts, playerHealth.MaxHearts);
        }

        private void RefreshScore()
        {
            SetScore(scoreCounter == null ? 0 : scoreCounter.CurrentRunScore);
        }

        private void RefreshRoom()
        {
            SetRoom(roomManager == null ? 1 : roomManager.CurrentRoomNumber);
        }

        private void RefreshCoins()
        {
            SetCoins(coinCounter == null ? 0 : coinCounter.CurrentRunCoins);
        }

        private void SetHearts(int currentHearts, int maxHearts)
        {
            if (heartsText != null)
            {
                heartsText.text = $"Hearts {Mathf.Max(0, currentHearts)}/{Mathf.Max(0, maxHearts)}";
            }
        }

        private void SetScore(int score)
        {
            if (scoreText != null)
            {
                scoreText.text = $"Score {Mathf.Max(0, score):0000}";
            }
        }

        private void SetRoom(int roomNumber)
        {
            if (roomText != null)
            {
                roomText.text = $"Room {Mathf.Max(1, roomNumber)}";
            }
        }

        private void SetCoins(int coins)
        {
            if (coinsText != null)
            {
                coinsText.text = $"Coins {Mathf.Max(0, coins):000}";
            }
        }
    }
}
