namespace Crashlytics.Sdk.Answers.Events
{
    public class Login : Base
    {
        public string Method { get; set; }

        public bool Success { get; set; }
    }
}