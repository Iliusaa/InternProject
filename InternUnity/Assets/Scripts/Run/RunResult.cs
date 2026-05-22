using System;
using UnityEngine;

namespace Stackspire.Run
{
    [Serializable]
    public struct RunResult
    {
        [SerializeField] private int finalScore;
        [SerializeField] private int roomsClimbed;
        [SerializeField] private int currentRunCoins;
        [SerializeField] private int totalBankedCoins;
        [SerializeField] private string killedBySource;

        public RunResult(int finalScore, int roomsClimbed, int currentRunCoins, int totalBankedCoins, string killedBySource)
        {
            this.finalScore = Mathf.Max(0, finalScore);
            this.roomsClimbed = Mathf.Max(0, roomsClimbed);
            this.currentRunCoins = Mathf.Max(0, currentRunCoins);
            this.totalBankedCoins = Mathf.Max(0, totalBankedCoins);
            this.killedBySource = string.IsNullOrWhiteSpace(killedBySource) ? "Unknown" : killedBySource;
        }

        public int FinalScore => finalScore;

        public int RoomsClimbed => roomsClimbed;

        public int CurrentRunCoins => currentRunCoins;

        public int TotalBankedCoins => totalBankedCoins;

        public string KilledBySource => string.IsNullOrWhiteSpace(killedBySource) ? "Unknown" : killedBySource;

        public static RunResult Empty => new RunResult(0, 0, 0, 0, "Unknown");
    }
}
