using System;
using System.Collections.Generic;
using Stackspire.Enemies;
using Stackspire.Player;
using UnityEngine;

namespace Stackspire.Rooms
{
    [DisallowMultipleComponent]
    public sealed class RoomManager : MonoBehaviour
    {
        [SerializeField] private EnemyBase enemyPrefab;
        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
        [SerializeField] private Transform playerTarget;
        [SerializeField] private int currentRoomNumber = 1;
        [SerializeField] private int roomOneGruntCount = 2;

        private readonly List<EnemyBase> activeEnemies = new List<EnemyBase>();
        private bool roomClearFired;
        private bool initialRoomSpawned;

        public event Action<int> RoomCleared;
        public event Action<int> RoomAdvanced;

        public int CurrentRoomNumber => currentRoomNumber;

        public int ActiveEnemyCount => activeEnemies.Count;

        private void Awake()
        {
            currentRoomNumber = Mathf.Max(1, currentRoomNumber);
            roomOneGruntCount = Mathf.Max(0, roomOneGruntCount);
        }

        private void Start()
        {
            if (playerTarget == null)
            {
                PlayerHealth playerHealth = UnityEngine.Object.FindFirstObjectByType<PlayerHealth>();
                playerTarget = playerHealth == null ? null : playerHealth.transform;
            }

            SpawnInitialRoom();
        }

        private void OnDestroy()
        {
            for (int i = activeEnemies.Count - 1; i >= 0; i--)
            {
                if (activeEnemies[i] != null)
                {
                    activeEnemies[i].Died -= HandleEnemyDied;
                }
            }
        }

        private void SpawnInitialRoom()
        {
            if (initialRoomSpawned)
            {
                return;
            }

            initialRoomSpawned = true;
            roomClearFired = false;
            activeEnemies.Clear();

            if (enemyPrefab == null)
            {
                return;
            }

            for (int i = 0; i < roomOneGruntCount; i++)
            {
                SpawnEnemyAt(i);
            }

            CheckRoomClear();
        }

        /// <summary>
        /// Advances to the next room and respawns the current first-slice enemy set.
        /// </summary>
        public void AdvanceRoom()
        {
            if (!roomClearFired)
            {
                return;
            }

            currentRoomNumber++;
            RoomAdvanced?.Invoke(currentRoomNumber);
            SpawnCurrentRoom();
        }

        private void SpawnCurrentRoom()
        {
            ClearActiveEnemies();
            roomClearFired = false;

            if (enemyPrefab == null)
            {
                return;
            }

            for (int i = 0; i < roomOneGruntCount; i++)
            {
                SpawnEnemyAt(i);
            }

            CheckRoomClear();
        }

        private void SpawnEnemyAt(int spawnIndex)
        {
            Transform spawnPoint = GetSpawnPoint(spawnIndex);
            EnemyBase enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, transform);
            enemy.Died += HandleEnemyDied;
            activeEnemies.Add(enemy);

            GruntChase gruntChase = enemy.GetComponent<GruntChase>();
            if (gruntChase != null && playerTarget != null)
            {
                gruntChase.SetTarget(playerTarget);
            }
        }

        private void ClearActiveEnemies()
        {
            for (int i = activeEnemies.Count - 1; i >= 0; i--)
            {
                EnemyBase enemy = activeEnemies[i];
                if (enemy != null)
                {
                    enemy.Died -= HandleEnemyDied;
                    Destroy(enemy.gameObject);
                }
            }

            activeEnemies.Clear();
        }

        private Transform GetSpawnPoint(int index)
        {
            if (spawnPoints.Count == 0)
            {
                return transform;
            }

            return spawnPoints[Mathf.Clamp(index, 0, spawnPoints.Count - 1)];
        }

        private void HandleEnemyDied(EnemyBase enemy, Stackspire.Combat.DamagePayload payload)
        {
            if (enemy != null)
            {
                enemy.Died -= HandleEnemyDied;
                activeEnemies.Remove(enemy);
            }

            CheckRoomClear();
        }

        private void CheckRoomClear()
        {
            if (roomClearFired || activeEnemies.Count > 0)
            {
                return;
            }

            roomClearFired = true;
            RoomCleared?.Invoke(currentRoomNumber);
        }
    }
}
