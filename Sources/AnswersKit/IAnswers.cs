using System.Collections.Generic;
using FabricSdk;

namespace AnswersKit
{
    public interface IAnswers : IKit
    {
        void LogSignUp(string signUpMethod, bool signUpSucceeded,
            Dictionary<string, object> customAttributes = null);

        void LogLogin(string loginMethod, bool loginSucceeded,
            Dictionary<string, object> customAttributes = null);

        void LogShare(string shareMethod, string contentName, string contentType, string contentId,
            Dictionary<string, object> customAttributes = null);

        void LogInvite(string inviteMethod, Dictionary<string, object> customAttributes = null);

        void LogPurchase(decimal itemPrice, string currency, bool purchaseSucceeded, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null);

        void LogLevelStart(string levelName, Dictionary<string, object> customAttributes = null);

        void LogLevelEnd(string levelName, double score, bool levelCompletedSuccesfully,
            Dictionary<string, object> customAttributes = null);

        void LogAddToCart(decimal itemPrice, string currency, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null);

        void LogStartCheckout(decimal totalPrice, string currency, int itemCount, Dictionary<string, object> customAttributes = null);

        void LogRating(int rating, string contentName, string contentType, string contentId,
            Dictionary<string, object> customAttributes = null);

        void LogContentView(string contentName, string contentType, string contentId,
            Dictionary<string, object> customAttributes = null);

        void LogSearch(string query, Dictionary<string, object> customAttributes = null);

        void LogCustom(string eventName, Dictionary<string, object> customAttributes = null);
    }
}