using System;
using Stackspire.Combat;
using Stackspire.Enemies;
using Stackspire.Rooms;
using UnityEngine;

namespace Stackspire.Run
{
    [DisallowMultipleComponent]
    public sealed class RunCoinCounter : MonoBehaviour
    {
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private int debugCurrentRunCoins;

        private int currentRunCoins;

        public event Action<int> CoinsChanged;

        public int CurrentRunCoins => currentRunCoins;

        private void Awake()
        {
            if (roomManager == null)
            {
                roomManager = UnityEngine.Object.FindFirstObjectByType<RoomManager>();
            }
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void Start()
        {
            ResetRunCoins();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        /// <summary>
        /// Resets current-run coins for a new run.
        /// </summary>
        public void ResetRunCoins()
        {
            SetCoins(0);
        }

        private void Subscribe()
        {
            if (roomManager != null)
            {
                roomManager.EnemyDied += HandleEnemyDied;
            }
        }

        private void Unsubscribe()
        {
            if (roomManager != null)
            {
                roomManager.EnemyDied -= HandleEnemyDied;
            }
        }

        private void HandleEnemyDied(EnemyBase enemy, DamagePayload payload)
        {
            SetCoins(currentRunCoins + 1);
        }

        private void SetCoins(int value)
        {
            currentRunCoins = Mathf.Max(0, value);
            debugCurrentRunCoins = currentRunCoins;
            CoinsChanged?.Invoke(currentRunCoins);
        }
    }
}
