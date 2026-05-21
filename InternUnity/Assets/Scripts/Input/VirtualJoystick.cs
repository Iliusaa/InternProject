using UnityEngine;
using UnityEngine.EventSystems;

namespace Stackspire.Input
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public sealed class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform thumb;
        [SerializeField] private float activeRadius = 100f;
        [SerializeField] private float deadZone = 0.12f;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField, Range(0f, 1f)] private float idleAlpha = 0.4f;
        [SerializeField, Range(0f, 1f)] private float heldAlpha = 0.6f;

        private RectTransform rectTransform;
        private Camera eventCamera;
        private Vector2 direction;
        private float magnitude;
        private bool isHeld;

        /// <summary>
        /// Normalized joystick direction after dead-zone filtering.
        /// </summary>
        public Vector2 Direction => direction;

        /// <summary>
        /// Analog joystick magnitude from 0 to 1 after dead-zone filtering.
        /// </summary>
        public float Magnitude => magnitude;

        /// <summary>
        /// Whether a pointer is currently holding this joystick.
        /// </summary>
        public bool IsHeld => isHeld;

        private void Awake()
        {
            CacheComponents();
            ResetOutput();
            ApplyVisualState();
        }

        private void OnEnable()
        {
            ResetOutput();
            ApplyVisualState();
        }

        private void OnValidate()
        {
            activeRadius = Mathf.Max(1f, activeRadius);
            deadZone = Mathf.Clamp01(deadZone);
        }

        /// <summary>
        /// Starts joystick input from a pointer press.
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            isHeld = true;
            eventCamera = eventData.pressEventCamera;
            UpdateOutput(eventData);
            ApplyVisualState();
        }

        /// <summary>
        /// Updates joystick input from a pointer drag.
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            if (!isHeld)
            {
                isHeld = true;
                eventCamera = eventData.pressEventCamera;
            }

            UpdateOutput(eventData);
            ApplyVisualState();
        }

        /// <summary>
        /// Clears joystick input when the pointer is released.
        /// </summary>
        public void OnPointerUp(PointerEventData eventData)
        {
            isHeld = false;
            eventCamera = null;
            ResetOutput();
            ApplyVisualState();
        }

        private void CacheComponents()
        {
            if (!TryGetComponent(out rectTransform))
            {
                enabled = false;
                return;
            }

            if (canvasGroup == null)
            {
                TryGetComponent(out canvasGroup);
            }
        }

        private void UpdateOutput(PointerEventData eventData)
        {
            if (rectTransform == null)
            {
                CacheComponents();
            }

            if (rectTransform == null)
            {
                return;
            }

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform,
                eventData.position,
                eventCamera,
                out Vector2 localPoint);

            Vector2 clamped = Vector2.ClampMagnitude(localPoint, activeRadius);
            float rawMagnitude = clamped.magnitude / activeRadius;

            if (rawMagnitude <= deadZone)
            {
                direction = Vector2.zero;
                magnitude = 0f;
            }
            else
            {
                direction = clamped.normalized;
                magnitude = Mathf.InverseLerp(deadZone, 1f, rawMagnitude);
            }

            if (thumb != null)
            {
                thumb.anchoredPosition = clamped;
            }
        }

        private void ResetOutput()
        {
            direction = Vector2.zero;
            magnitude = 0f;

            if (thumb != null)
            {
                thumb.anchoredPosition = Vector2.zero;
            }
        }

        private void ApplyVisualState()
        {
            if (canvasGroup != null)
            {
                canvasGroup.alpha = isHeld ? heldAlpha : idleAlpha;
            }
        }
    }
}
