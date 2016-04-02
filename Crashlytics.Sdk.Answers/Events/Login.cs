namespace Crashlytics.Sdk.Answers.Events
{
    public class Login : Base
    {
        public string LoginMethod { get; set; }

        public bool LoginSucceeded { get; set; }
    }
}