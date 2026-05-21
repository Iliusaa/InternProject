using System;
using Stackspire.Combat;
using Stackspire.Enemies;
using Stackspire.Rooms;
using UnityEngine;

namespace Stackspire.Run
{
    [DisallowMultipleComponent]
    public sealed class RunScoreCounter : MonoBehaviour
    {
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private int enemyDeathScore = 20;
        [SerializeField] private int roomClearScore = 25;
        [SerializeField] private int debugCurrentRunScore;

        private int currentRunScore;

        public event Action<int> ScoreChanged;

        public int CurrentRunScore => currentRunScore;

        private void Awake()
        {
            enemyDeathScore = Mathf.Max(0, enemyDeathScore);
            roomClearScore = Mathf.Max(0, roomClearScore);

            if (roomManager == null)
            {
                roomManager = UnityEngine.Object.FindFirstObjectByType<RoomManager>();
            }
        }

        private void OnValidate()
        {
            enemyDeathScore = Mathf.Max(0, enemyDeathScore);
            roomClearScore = Mathf.Max(0, roomClearScore);
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void Start()
        {
            ResetRunScore();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        /// <summary>
        /// Resets current-run score for a new run.
        /// </summary>
        public void ResetRunScore()
        {
            SetScore(0);
        }

        private void Subscribe()
        {
            if (roomManager != null)
            {
                roomManager.EnemyDied += HandleEnemyDied;
                roomManager.RoomCleared += HandleRoomCleared;
            }
        }

        private void Unsubscribe()
        {
            if (roomManager != null)
            {
                roomManager.EnemyDied -= HandleEnemyDied;
                roomManager.RoomCleared -= HandleRoomCleared;
            }
        }

        private void HandleEnemyDied(EnemyBase enemy, DamagePayload payload)
        {
            SetScore(currentRunScore + enemyDeathScore);
        }

        private void HandleRoomCleared(int roomNumber)
        {
            SetScore(currentRunScore + roomClearScore);
        }

        private void SetScore(int value)
        {
            currentRunScore = Mathf.Max(0, value);
            debugCurrentRunScore = currentRunScore;
            ScoreChanged?.Invoke(currentRunScore);
        }
    }
}
