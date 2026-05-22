using System;

namespace Stackspire.Classes
{
    public static class ClassSelectionState
    {
        private static PlayerClassId selectedClass = PlayerClassId.Warrior;

        public static event Action<PlayerClassId> SelectionChanged;

        public static PlayerClassId SelectedClass => selectedClass;

        /// <summary>
        /// Stores the selected player class for the current runtime session.
        /// </summary>
        public static void Select(PlayerClassId playerClass)
        {
            if (selectedClass == playerClass)
            {
                return;
            }

            selectedClass = playerClass;
            SelectionChanged?.Invoke(selectedClass);
        }

        /// <summary>
        /// Restores the runtime selection to the default Warrior class.
        /// </summary>
        public static void ResetToDefault()
        {
            Select(PlayerClassId.Warrior);
        }
    }
}
