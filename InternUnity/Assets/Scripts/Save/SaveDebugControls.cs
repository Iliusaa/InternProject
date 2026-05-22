using UnityEngine;

namespace Stackspire.Save
{
    [DisallowMultipleComponent]
    public sealed class SaveDebugControls : MonoBehaviour
    {
        [SerializeField] private int debugHighScore;
        [SerializeField] private int debugTotalBankedCoins;

        private void OnEnable()
        {
            RefreshDebugValues();
        }

        /// <summary>
        /// Reloads visible debug values from the save service.
        /// </summary>
        [ContextMenu("Refresh Debug Values")]
        public void RefreshDebugValues()
        {
            SaveData data = SaveService.Load();
            debugHighScore = data.HighScore;
            debugTotalBankedCoins = data.TotalBankedCoins;
        }

        /// <summary>
        /// Clears the PlayerPrefs-backed MVP save.
        /// </summary>
        [ContextMenu("Reset Save Data")]
        public void ResetSaveData()
        {
            SaveService.ResetSave();
            RefreshDebugValues();
        }
    }
}
