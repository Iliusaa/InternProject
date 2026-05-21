using System;
using Stackspire.Combat;
using UnityEngine;

namespace Stackspire.Enemies
{
    [DisallowMultipleComponent]
    public sealed class EnemyBase : MonoBehaviour
    {
        [SerializeField] private string enemyTypeLabel = "Enemy";
        [SerializeField] private int maxHealth = 6;
        [SerializeField] private bool disableOnDeath = true;

        private int currentHealth;
        private bool isDead;

        public event Action<EnemyBase, int, int> HealthChanged;
        public event Action<EnemyBase, DamagePayload> Died;

        public string EnemyTypeLabel => enemyTypeLabel;

        public int MaxHealth => maxHealth;

        public int CurrentHealth => currentHealth;

        public bool IsDead => isDead;

        private void Awake()
        {
            maxHealth = Mathf.Max(1, maxHealth);
            currentHealth = maxHealth;
        }

        private void OnValidate()
        {
            maxHealth = Mathf.Max(1, maxHealth);
        }

        /// <summary>
        /// Applies incoming damage and returns true when enemy health changed.
        /// </summary>
        public bool TakeDamage(DamagePayload payload)
        {
            if (isDead || payload.Hearts <= 0)
            {
                return false;
            }

            currentHealth = Mathf.Max(0, currentHealth - payload.Hearts);
            HealthChanged?.Invoke(this, currentHealth, maxHealth);

            if (currentHealth == 0)
            {
                Die(payload);
            }

            return true;
        }

        private void Die(DamagePayload payload)
        {
            if (isDead)
            {
                return;
            }

            isDead = true;
            Died?.Invoke(this, payload);

            if (disableOnDeath)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
