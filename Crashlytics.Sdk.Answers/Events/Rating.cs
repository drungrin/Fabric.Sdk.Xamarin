namespace CrashlyticsSdk.Answers.Events
{
    public class Rating : Base
    {
        public string ContentId { get; set; }

        public string ContentName { get; set; }

        public string ContentType { get; set; }

        public int Value { get; set; }
    }
}