using Crashlytics.Sdk.Answers.Events;

namespace Crashlytics.Sdk.Answers
{
    public interface IAnswers
    {
        void LogCustom(Custom data);

        void LogPurchase(Purchase data);

        void LogLogin(Login data);

        void LogShare(Share data);

        void LogInvite(Invite data);

        void LogSignUp(SignUp data);

        void LogLevelStart(LevelStart data);

        void LogLevelEnd(LevelEnd data);

        void LogAddToCart(AddToCart data);

        void LogStartCheckout(StartCheckout data);

        void LogRating(Rating data);

        void LogContentView(ContentView data);

        void LogSearch(Search data);
    }
}