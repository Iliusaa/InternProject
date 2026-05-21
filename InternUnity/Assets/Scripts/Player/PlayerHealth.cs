using System;
using Stackspire.Combat;
using UnityEngine;

namespace Stackspire.Player
{
    [DisallowMultipleComponent]
    public sealed class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHearts = 5;
        [SerializeField] private float invulnerabilitySeconds = 0.5f;

        private int currentHearts;
        private bool isDead;
        private float invulnerableUntilTime;
        private DamagePayload killedBy;

        public event Action<int, int> HealthChanged;
        public event Action<DamagePayload> Died;

        public int MaxHearts => maxHearts;

        public int CurrentHearts => currentHearts;

        public bool IsDead => isDead;

        public bool IsInvulnerable => !isDead && Time.time < invulnerableUntilTime;

        public DamagePayload KilledBy => killedBy;

        private void Awake()
        {
            maxHearts = Mathf.Max(1, maxHearts);
            currentHearts = maxHearts;
        }

        /// <summary>
        /// Applies incoming damage and returns true when health changed.
        /// </summary>
        public bool TakeDamage(DamagePayload payload)
        {
            if (isDead || IsInvulnerable || payload.Hearts <= 0)
            {
                return false;
            }

            currentHearts = Mathf.Max(0, currentHearts - payload.Hearts);
            invulnerableUntilTime = Time.time + invulnerabilitySeconds;
            HealthChanged?.Invoke(currentHearts, maxHearts);

            if (currentHearts == 0)
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
            killedBy = payload;
            Died?.Invoke(killedBy);
        }
    }
}
