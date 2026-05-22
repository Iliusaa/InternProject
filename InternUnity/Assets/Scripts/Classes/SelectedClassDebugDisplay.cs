using UnityEngine;
using UnityEngine.UI;

namespace Stackspire.Classes
{
    [DisallowMultipleComponent]
    public sealed class SelectedClassDebugDisplay : MonoBehaviour
    {
        [SerializeField] private Text selectedClassText;

        private void OnEnable()
        {
            ClassSelectionState.SelectionChanged += HandleSelectionChanged;
            Refresh();
        }

        private void OnDisable()
        {
            ClassSelectionState.SelectionChanged -= HandleSelectionChanged;
        }

        /// <summary>
        /// Refreshes the debug display from the stored runtime class selection.
        /// </summary>
        public void Refresh()
        {
            HandleSelectionChanged(ClassSelectionState.SelectedClass);
        }

        private void HandleSelectionChanged(PlayerClassId selectedClass)
        {
            if (selectedClassText != null)
            {
                selectedClassText.text = $"Class: {selectedClass}";
            }
        }
    }
}
