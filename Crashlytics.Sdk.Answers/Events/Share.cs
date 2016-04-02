namespace Crashlytics.Sdk.Answers.Events
{
    public class Share : Base
    {
        public string Method { get; set; }

        public string ContentId { get; set; }

        public string ContentName { get; set; }

        public string ContentType { get; set; }
    }
}

