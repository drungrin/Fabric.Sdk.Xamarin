namespace CrashlyticsSdk.Answers.Events
{
    public class LevelEnd : Base
    {
        public string LevelName { get; set; }

        public double Score { get; set; }

        public bool Success { get; set; }
    }
}