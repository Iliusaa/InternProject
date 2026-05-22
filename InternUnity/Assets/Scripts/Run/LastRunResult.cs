namespace Stackspire.Run
{
    public static class LastRunResult
    {
        private static RunResult result = RunResult.Empty;

        public static bool HasResult { get; private set; }

        public static RunResult Result => HasResult ? result : RunResult.Empty;

        /// <summary>
        /// Stores the latest completed run result for the GameOver scene.
        /// </summary>
        public static void Set(RunResult newResult)
        {
            result = newResult;
            HasResult = true;
        }

        /// <summary>
        /// Clears the cached run result.
        /// </summary>
        public static void Clear()
        {
            result = RunResult.Empty;
            HasResult = false;
        }
    }
}
