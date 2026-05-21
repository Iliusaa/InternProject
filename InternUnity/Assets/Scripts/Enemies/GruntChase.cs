using Stackspire.Combat;
using Stackspire.Player;
using UnityEngine;

namespace Stackspire.Enemies
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(EnemyBase))]
    public sealed class GruntChase : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private int contactDamageHearts = 1;
        [SerializeField] private string contactDamageSourceLabel = "Grunt";

        private Rigidbody2D enemyRigidbody;
        private EnemyBase enemyBase;

        private void Awake()
        {
            enemyRigidbody = GetComponent<Rigidbody2D>();
            enemyBase = GetComponent<EnemyBase>();
            enemyRigidbody.gravityScale = 0f;
            enemyRigidbody.freezeRotation = true;
        }

        private void OnEnable()
        {
            if (target == null)
            {
                ResolvePlayerTarget();
            }
        }

        private void FixedUpdate()
        {
            if (enemyBase.IsDead || target == null)
            {
                enemyRigidbody.linearVelocity = Vector2.zero;
                return;
            }

            Vector2 toTarget = target.position - transform.position;
            enemyRigidbody.linearVelocity = toTarget.sqrMagnitude <= Mathf.Epsilon
                ? Vector2.zero
                : toTarget.normalized * moveSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ApplyContactDamage(collision.gameObject);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            ApplyContactDamage(collision.gameObject);
        }

        private void OnDisable()
        {
            if (enemyRigidbody != null)
            {
                enemyRigidbody.linearVelocity = Vector2.zero;
            }
        }

        /// <summary>
        /// Assigns the target this Grunt should chase.
        /// </summary>
        public void SetTarget(Transform chaseTarget)
        {
            target = chaseTarget;
        }

        private void ResolvePlayerTarget()
        {
            PlayerHealth playerHealth = Object.FindFirstObjectByType<PlayerHealth>();
            target = playerHealth == null ? null : playerHealth.transform;
        }

        private void ApplyContactDamage(GameObject hitObject)
        {
            if (enemyBase.IsDead || contactDamageHearts <= 0)
            {
                return;
            }

            PlayerHealth playerHealth = hitObject.GetComponentInParent<PlayerHealth>();
            if (playerHealth == null)
            {
                return;
            }

            DamagePayload payload = new DamagePayload(
                contactDamageHearts,
                gameObject,
                contactDamageSourceLabel);

            playerHealth.TakeDamage(payload);
        }
    }
}
