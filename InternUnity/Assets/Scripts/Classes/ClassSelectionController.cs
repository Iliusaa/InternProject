using UnityEngine;
using UnityEngine.UI;

namespace Stackspire.Classes
{
    [DisallowMultipleComponent]
    public sealed class ClassSelectionController : MonoBehaviour
    {
        [SerializeField] private Text selectedClassText;

        private void OnEnable()
        {
            ClassSelectionState.SelectionChanged += HandleSelectionChanged;
            RefreshSelectedClassText();
        }

        private void OnDisable()
        {
            ClassSelectionState.SelectionChanged -= HandleSelectionChanged;
        }

        /// <summary>
        /// Selects Warrior as the player class.
        /// </summary>
        public void SelectWarrior()
        {
            ClassSelectionState.Select(PlayerClassId.Warrior);
        }

        /// <summary>
        /// Selects Archer as the player class.
        /// </summary>
        public void SelectArcher()
        {
            ClassSelectionState.Select(PlayerClassId.Archer);
        }

        /// <summary>
        /// Selects Mage as the player class.
        /// </summary>
        public void SelectMage()
        {
            ClassSelectionState.Select(PlayerClassId.Mage);
        }

        /// <summary>
        /// Refreshes the class-selection label from the stored runtime state.
        /// </summary>
        public void RefreshSelectedClassText()
        {
            HandleSelectionChanged(ClassSelectionState.SelectedClass);
        }

        private void HandleSelectionChanged(PlayerClassId selectedClass)
        {
            if (selectedClassText != null)
            {
                selectedClassText.text = $"Selected: {selectedClass}";
            }
        }
    }
}
