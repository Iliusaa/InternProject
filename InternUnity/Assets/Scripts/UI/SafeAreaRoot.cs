using UnityEngine;

namespace Stackspire.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public sealed class SafeAreaRoot : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Rect lastSafeArea;
        private Vector2Int lastScreenSize;

        private void Awake()
        {
            CacheRectTransform();
        }

        private void OnEnable()
        {
            ApplySafeAreaIfNeeded(force: true);
        }

        private void Update()
        {
            ApplySafeAreaIfNeeded(force: false);
        }

        private void OnRectTransformDimensionsChange()
        {
            if (isActiveAndEnabled)
            {
                ApplySafeAreaIfNeeded(force: true);
            }
        }

        private void ApplySafeAreaIfNeeded(bool force)
        {
            Rect safeArea = Screen.safeArea;
            Vector2Int screenSize = new Vector2Int(Screen.width, Screen.height);

            if (!force && safeArea == lastSafeArea && screenSize == lastScreenSize)
            {
                return;
            }

            lastSafeArea = safeArea;
            lastScreenSize = screenSize;
            ApplySafeArea(safeArea, screenSize);
        }

        private void ApplySafeArea(Rect safeArea, Vector2Int screenSize)
        {
            if (rectTransform == null)
            {
                CacheRectTransform();
            }

            if (screenSize.x <= 0 || screenSize.y <= 0)
            {
                return;
            }

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= screenSize.x;
            anchorMin.y /= screenSize.y;
            anchorMax.x /= screenSize.x;
            anchorMax.y /= screenSize.y;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }

        private void CacheRectTransform()
        {
            if (!TryGetComponent(out rectTransform))
            {
                enabled = false;
            }
        }
    }
}
