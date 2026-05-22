using UnityEngine;

namespace Stackspire.Save
{
    public static class SaveService
    {
        private const string SaveKey = "Stackspire.MVP.SaveData.v1";

        private static SaveData cachedData;

        public static SaveData Data
        {
            get
            {
                EnsureLoaded();
                return cachedData;
            }
        }

        /// <summary>
        /// Loads saved data or creates default data when no save exists.
        /// </summary>
        public static SaveData Load()
        {
            if (!PlayerPrefs.HasKey(SaveKey))
            {
                cachedData = SaveData.CreateDefault();
                return cachedData;
            }

            string json = PlayerPrefs.GetString(SaveKey, string.Empty);
            cachedData = string.IsNullOrWhiteSpace(json) ? SaveData.CreateDefault() : JsonUtility.FromJson<SaveData>(json);
            if (cachedData == null)
            {
                cachedData = SaveData.CreateDefault();
            }

            cachedData.EnsureShape();
            return cachedData;
        }

        /// <summary>
        /// Saves the current cached data to PlayerPrefs.
        /// </summary>
        public static void Save()
        {
            EnsureLoaded();
            cachedData.EnsureShape();
            PlayerPrefs.SetString(SaveKey, JsonUtility.ToJson(cachedData));
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Clears stored save data and restores runtime defaults.
        /// </summary>
        public static void ResetSave()
        {
            PlayerPrefs.DeleteKey(SaveKey);
            PlayerPrefs.Save();
            cachedData = SaveData.CreateDefault();
        }

        /// <summary>
        /// Gets the saved high score.
        /// </summary>
        public static int GetHighScore()
        {
            return Data.HighScore;
        }

        /// <summary>
        /// Sets and saves the high score.
        /// </summary>
        public static void SetHighScore(int value)
        {
            Data.SetHighScore(value);
            Save();
        }

        /// <summary>
        /// Gets the saved total banked coins.
        /// </summary>
        public static int GetTotalBankedCoins()
        {
            return Data.TotalBankedCoins;
        }

        /// <summary>
        /// Sets and saves total banked coins.
        /// </summary>
        public static void SetTotalBankedCoins(int value)
        {
            Data.SetTotalBankedCoins(value);
            Save();
        }

        /// <summary>
        /// Adds coins to the saved bank and returns the new total.
        /// </summary>
        public static int AddBankedCoins(int coins)
        {
            int totalBankedCoins = Data.TotalBankedCoins + Mathf.Max(0, coins);
            Data.SetTotalBankedCoins(totalBankedCoins);
            Save();
            return Data.TotalBankedCoins;
        }

        /// <summary>
        /// Banks a completed run's score and coins, then returns total banked coins.
        /// </summary>
        public static int DepositRunResult(int finalScore, int currentRunCoins)
        {
            SaveData data = Data;
            data.SetHighScore(Mathf.Max(data.HighScore, finalScore));
            data.SetTotalBankedCoins(data.TotalBankedCoins + Mathf.Max(0, currentRunCoins));
            Save();
            return data.TotalBankedCoins;
        }

        /// <summary>
        /// Gets the saved level for a global upgrade.
        /// </summary>
        public static int GetUpgradeLevel(UpgradeId upgradeId)
        {
            SaveData data = Data;
            return data.UpgradeLevels[(int)upgradeId];
        }

        /// <summary>
        /// Sets and saves a global upgrade level.
        /// </summary>
        public static void SetUpgradeLevel(UpgradeId upgradeId, int level)
        {
            Data.SetUpgradeLevel(upgradeId, level);
            Save();
        }

        /// <summary>
        /// Gets whether a class special upgrade has been bought.
        /// </summary>
        public static bool IsClassSpecialUnlocked(ClassSpecialId classSpecialId)
        {
            SaveData data = Data;
            return data.ClassSpecialUnlocked[(int)classSpecialId];
        }

        /// <summary>
        /// Sets and saves whether a class special upgrade has been bought.
        /// </summary>
        public static void SetClassSpecialUnlocked(ClassSpecialId classSpecialId, bool unlocked)
        {
            Data.SetClassSpecialUnlocked(classSpecialId, unlocked);
            Save();
        }

        private static void EnsureLoaded()
        {
            if (cachedData == null)
            {
                Load();
            }
        }
    }
}
