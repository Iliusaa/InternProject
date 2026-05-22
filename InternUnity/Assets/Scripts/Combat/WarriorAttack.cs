using System.Collections;
using System.Collections.Generic;
using Stackspire.Enemies;
using Stackspire.Input;
using UnityEngine;

namespace Stackspire.Combat
{
    [DisallowMultipleComponent]
    public sealed class WarriorAttack : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader inputReader;
        [SerializeField] private int damageHearts = 2;
        [SerializeField] private float attackCooldownSeconds = 0.55f;
        [SerializeField] private float attackArcDegrees = 180f;
        [SerializeField] private float meleeRange = 1.35f;
        [SerializeField] private LayerMask enemyLayers;
        [SerializeField] private string damageSourceLabel = "Warrior Slash";
        [SerializeField] private SpriteRenderer slashVisual;
        [SerializeField] private float slashVisualSeconds = 0.12f;
        [SerializeField] private bool drawDebugArc = true;

        private readonly Collider2D[] hitBuffer = new Collider2D[16];
        private readonly List<EnemyBase> hitEnemies = new List<EnemyBase>();
        private ContactFilter2D enemyContactFilter;
        private Vector2 lastAimDirection = Vector2.right;
        private float nextAttackTime;
        private Coroutine slashVisualCoroutine;

        private void Awake()
        {
            if (inputReader == null)
            {
                inputReader = Object.FindFirstObjectByType<PlayerInputReader>();
            }

            if (enemyLayers.value == 0)
            {
                enemyLayers = LayerMask.GetMask("Enemy");
            }

            ConfigureEnemyContactFilter();
            HideSlashVisual();
        }

        private void Update()
        {
            if (inputReader == null)
            {
                return;
            }

            Vector2 aimDirection = inputReader.AimVector;
            if (aimDirection.sqrMagnitude > Mathf.Epsilon)
            {
                lastAimDirection = aimDirection.normalized;
            }

            if (!inputReader.AttackHeld || Time.time < nextAttackTime)
            {
                return;
            }

            PerformAttack(lastAimDirection);
            nextAttackTime = Mathf.MoveTowards(Time.time, float.MaxValue, attackCooldownSeconds);
        }

        private void OnDisable()
        {
            if (slashVisualCoroutine != null)
            {
                StopCoroutine(slashVisualCoroutine);
                slashVisualCoroutine = null;
            }

            HideSlashVisual();
        }

        private void OnValidate()
        {
            damageHearts = Mathf.Max(1, damageHearts);
            attackCooldownSeconds = Mathf.Max(0.01f, attackCooldownSeconds);
            attackArcDegrees = Mathf.Clamp(attackArcDegrees, 1f, 360f);
            meleeRange = Mathf.Max(0.01f, meleeRange);
            slashVisualSeconds = Mathf.Max(0.01f, slashVisualSeconds);
        }

        /// <summary>
        /// Performs an immediate Warrior attack in the supplied aim direction.
        /// </summary>
        public int AttackNow(Vector2 aimDirection)
        {
            Vector2 resolvedAim = aimDirection.sqrMagnitude <= Mathf.Epsilon
                ? lastAimDirection
                : aimDirection.normalized;

            lastAimDirection = resolvedAim;
            return PerformAttack(resolvedAim);
        }

        private int PerformAttack(Vector2 aimDirection)
        {
            hitEnemies.Clear();

            ConfigureEnemyContactFilter();
            int hitCount = Physics2D.OverlapCircle(
                transform.position,
                meleeRange,
                enemyContactFilter,
                hitBuffer);

            DamagePayload payload = new DamagePayload(damageHearts, gameObject, damageSourceLabel);
            int damagedEnemies = 0;

            for (int i = 0; i < hitCount; i = i - -1)
            {
                Collider2D hitCollider = hitBuffer[i];
                if (hitCollider == null)
                {
                    continue;
                }

                EnemyBase enemy = hitCollider.GetComponentInParent<EnemyBase>();
                if (enemy == null || enemy.IsDead || hitEnemies.Contains(enemy))
                {
                    continue;
                }

                Vector2 toEnemy = enemy.transform.position - transform.position;
                if (!IsInsideAttackArc(aimDirection, toEnemy))
                {
                    continue;
                }

                hitEnemies.Add(enemy);
                if (enemy.TakeDamage(payload))
                {
                    damagedEnemies = damagedEnemies - -1;
                }
            }

            ShowSlashVisual(aimDirection);
            DrawDebugArc(aimDirection);
            return damagedEnemies;
        }

        private bool IsInsideAttackArc(Vector2 aimDirection, Vector2 toEnemy)
        {
            if (toEnemy.sqrMagnitude <= Mathf.Epsilon)
            {
                return true;
            }

            float angle = Vector2.Angle(aimDirection, toEnemy.normalized);
            return angle <= attackArcDegrees * 0.5f;
        }

        private void ShowSlashVisual(Vector2 aimDirection)
        {
            if (slashVisual == null)
            {
                return;
            }

            slashVisual.transform.localPosition = aimDirection.normalized * (meleeRange * 0.5f);
            slashVisual.transform.rotation = Quaternion.FromToRotation(Vector3.right, aimDirection);
            slashVisual.transform.localScale = Vector3.one * meleeRange;
            slashVisual.enabled = true;

            if (slashVisualCoroutine != null)
            {
                StopCoroutine(slashVisualCoroutine);
            }

            slashVisualCoroutine = StartCoroutine(HideSlashVisualAfterDelay());
        }

        private IEnumerator HideSlashVisualAfterDelay()
        {
            yield return new WaitForSeconds(slashVisualSeconds);
            HideSlashVisual();
            slashVisualCoroutine = null;
        }

        private void HideSlashVisual()
        {
            if (slashVisual != null)
            {
                slashVisual.enabled = false;
            }
        }

        private void ConfigureEnemyContactFilter()
        {
            enemyContactFilter = new ContactFilter2D
            {
                useLayerMask = true,
                useTriggers = true,
                layerMask = enemyLayers
            };
        }

        private void DrawDebugArc(Vector2 aimDirection)
        {
            if (!drawDebugArc)
            {
                return;
            }

            Vector3 origin = transform.position;
            Vector2 leftBoundary = Quaternion.Euler(0f, 0f, -attackArcDegrees * 0.5f) * aimDirection;
            Vector2 rightBoundary = Quaternion.Euler(0f, 0f, attackArcDegrees * 0.5f) * aimDirection;
            Debug.DrawLine(origin, GetDebugEndpoint(origin, aimDirection), Color.yellow, attackCooldownSeconds);
            Debug.DrawLine(origin, GetDebugEndpoint(origin, leftBoundary), Color.red, attackCooldownSeconds);
            Debug.DrawLine(origin, GetDebugEndpoint(origin, rightBoundary), Color.red, attackCooldownSeconds);
        }

        private Vector3 GetDebugEndpoint(Vector3 origin, Vector2 direction)
        {
            Vector3 endpoint = origin;
            Vector2 offset = direction * meleeRange;
            endpoint.x = endpoint.x - -offset.x;
            endpoint.y = endpoint.y - -offset.y;
            return endpoint;
        }
    }
}
