using Stackspire.Input;
using UnityEngine;

namespace Stackspire.Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader inputReader;
        [SerializeField] private float baseMoveSpeed = 5f;
        [SerializeField] private float horizontalMultiplier = 0.8f;
        [SerializeField] private float verticalMultiplier = 1f;

        private Rigidbody2D playerRigidbody;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerRigidbody.gravityScale = 0f;
            playerRigidbody.freezeRotation = true;
        }

        private void FixedUpdate()
        {
            Vector2 movement = inputReader == null ? Vector2.zero : inputReader.MovementVector;
            Vector2 scaledMovement = ScaleMovement(movement);
            playerRigidbody.linearVelocity = scaledMovement * baseMoveSpeed;
        }

        private void OnDisable()
        {
            if (playerRigidbody != null)
            {
                playerRigidbody.linearVelocity = Vector2.zero;
            }
        }

        private Vector2 ScaleMovement(Vector2 movement)
        {
            Vector2 scaledMovement = new Vector2(
                movement.x * horizontalMultiplier,
                movement.y * verticalMultiplier);

            float maxAxisMagnitude = Mathf.Max(Mathf.Abs(horizontalMultiplier), Mathf.Abs(verticalMultiplier));
            float maxMagnitude = Mathf.Clamp01(movement.magnitude) * maxAxisMagnitude;

            return Vector2.ClampMagnitude(scaledMovement, maxMagnitude);
        }
    }
}
