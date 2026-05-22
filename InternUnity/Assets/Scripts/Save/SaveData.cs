using System;
using UnityEngine;

namespace Stackspire.Save
{
    public enum UpgradeId
    {
        Toughness = 0,
        Power = 1,
        Agility = 2,
        Greed = 3
    }

    public enum ClassSpecialId
    {
        Warrior = 0,
        Archer = 1,
        Mage = 2
    }

    [Serializable]
    public sealed class SaveData
    {
        public const int UpgradeCount = 4;
        public const int ClassSpecialCount = 3;

        [SerializeField] private int highScore;
        [SerializeField] private int totalBankedCoins;
        [SerializeField] private int[] upgradeLevels = new int[UpgradeCount];
        [SerializeField] private bool[] classSpecialUnlocked = new bool[ClassSpecialCount];

        public int HighScore => highScore;

        public int TotalBankedCoins => totalBankedCoins;

        public int[] UpgradeLevels => upgradeLevels;

        public bool[] ClassSpecialUnlocked => classSpecialUnlocked;

        /// <summary>
        /// Creates save data with MVP default values.
        /// </summary>
        public static SaveData CreateDefault()
        {
            SaveData data = new SaveData();
            data.EnsureShape();
            return data;
        }

        /// <summary>
        /// Clamps invalid values and restores missing arrays after JSON loading.
        /// </summary>
        public void EnsureShape()
        {
            highScore = Mathf.Max(0, highScore);
            totalBankedCoins = Mathf.Max(0, totalBankedCoins);
            upgradeLevels = EnsureIntArray(upgradeLevels, UpgradeCount);
            classSpecialUnlocked = EnsureBoolArray(classSpecialUnlocked, ClassSpecialCount);

            for (int i = 0; i < upgradeLevels.Length; i++)
            {
                upgradeLevels[i] = Mathf.Clamp(upgradeLevels[i], 0, 5);
            }
        }

        /// <summary>
        /// Sets the saved high score.
        /// </summary>
        public void SetHighScore(int value)
        {
            highScore = Mathf.Max(0, value);
        }

        /// <summary>
        /// Sets the saved total banked coins.
        /// </summary>
        public void SetTotalBankedCoins(int value)
        {
            totalBankedCoins = Mathf.Max(0, value);
        }

        /// <summary>
        /// Sets a global upgrade level.
        /// </summary>
        public void SetUpgradeLevel(UpgradeId upgradeId, int level)
        {
            EnsureShape();
            upgradeLevels[(int)upgradeId] = Mathf.Clamp(level, 0, 5);
        }

        /// <summary>
        /// Sets whether a class special upgrade has been bought.
        /// </summary>
        public void SetClassSpecialUnlocked(ClassSpecialId classSpecialId, bool unlocked)
        {
            EnsureShape();
            classSpecialUnlocked[(int)classSpecialId] = unlocked;
        }

        private static int[] EnsureIntArray(int[] source, int length)
        {
            int[] result = new int[length];
            if (source == null)
            {
                return result;
            }

            Array.Copy(source, result, Mathf.Min(source.Length, length));
            return result;
        }

        private static bool[] EnsureBoolArray(bool[] source, int length)
        {
            bool[] result = new bool[length];
            if (source == null)
            {
                return result;
            }

            Array.Copy(source, result, Mathf.Min(source.Length, length));
            return result;
        }
    }
}
