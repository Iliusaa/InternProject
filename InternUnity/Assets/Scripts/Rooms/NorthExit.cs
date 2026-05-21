using Stackspire.Player;
using UnityEngine;

namespace Stackspire.Rooms
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider2D))]
    public sealed class NorthExit : MonoBehaviour
    {
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private SpriteRenderer stateRenderer;
        [SerializeField] private Sprite lockedSprite;
        [SerializeField] private Sprite unlockedSprite;
        [SerializeField] private Color lockedTint = new Color(0.7f, 0.1f, 0.1f, 1f);
        [SerializeField] private Color unlockedTint = new Color(1f, 0.82f, 0.32f, 1f);

        private bool isUnlocked;

        public bool IsUnlocked => isUnlocked;

        private void Awake()
        {
            Collider2D exitCollider = GetComponent<Collider2D>();
            exitCollider.isTrigger = true;
            SetLocked();
        }

        private void OnEnable()
        {
            if (roomManager == null)
            {
                roomManager = UnityEngine.Object.FindFirstObjectByType<RoomManager>();
            }

            if (roomManager != null)
            {
                roomManager.RoomCleared += HandleRoomCleared;
                roomManager.RoomAdvanced += HandleRoomAdvanced;
            }
        }

        private void OnDisable()
        {
            if (roomManager != null)
            {
                roomManager.RoomCleared -= HandleRoomCleared;
                roomManager.RoomAdvanced -= HandleRoomAdvanced;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TryAdvance(other);
        }

        /// <summary>
        /// Attempts to advance the room when the player enters the unlocked exit.
        /// </summary>
        public bool TryAdvance(Collider2D other)
        {
            if (!isUnlocked || roomManager == null)
            {
                return false;
            }

            if (other.GetComponentInParent<PlayerHealth>() == null)
            {
                return false;
            }

            roomManager.AdvanceRoom();
            return true;
        }

        private void HandleRoomCleared(int roomNumber)
        {
            SetUnlocked();
        }

        private void HandleRoomAdvanced(int roomNumber)
        {
            SetLocked();
        }

        private void SetLocked()
        {
            isUnlocked = false;
            ApplyVisualState(lockedSprite, lockedTint);
        }

        private void SetUnlocked()
        {
            isUnlocked = true;
            ApplyVisualState(unlockedSprite, unlockedTint);
        }

        private void ApplyVisualState(Sprite sprite, Color tint)
        {
            if (stateRenderer == null)
            {
                return;
            }

            if (sprite != null)
            {
                stateRenderer.sprite = sprite;
            }

            stateRenderer.color = tint;
        }
    }
}
