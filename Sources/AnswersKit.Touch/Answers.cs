using System;
using System.Collections.Generic;
using FabricSdk;
using Foundation;

namespace AnswersKit
{
    public sealed class Answers : Kit, IAnswers
    {
        private static readonly Lazy<Answers> LazyInstance = new Lazy<Answers>(() => new Answers());

        private Answers() : base(new Bindings.AnswersKit.Answers())
        {

        }

        public static IAnswers Instance => LazyInstance.Value;

        

        public void LogSignUp(string signUpMethod, bool signUpSucceeded, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogSignUpWithMethod(signUpMethod, signUpSucceeded, ToNsDictionary(customAttributes));
        }

        public void LogLogin(string loginMethod, bool loginSucceeded, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogLoginWithMethod(loginMethod, loginSucceeded, ToNsDictionary(customAttributes));
        }

        public void LogShare(string shareMethod, string contentName, string contentType, string contentId,
            Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogShareWithMethod(shareMethod, contentName, contentType, contentId, ToNsDictionary(customAttributes));
        }

        public void LogInvite(string inviteMethod, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogInviteWithMethod(inviteMethod, ToNsDictionary(customAttributes));
        }

        public void LogPurchase(decimal itemPrice, string currency, bool purchaseSucceeded, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogPurchaseWithPrice(new NSDecimalNumber(itemPrice), currency, purchaseSucceeded, itemName, itemType, itemId, ToNsDictionary(customAttributes));
        }

        public void LogLevelStart(string levelName, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogLevelStart(levelName, ToNsDictionary(customAttributes));
        }

        public void LogLevelEnd(string levelName, double score, bool levelCompletedSuccesfully, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogLevelEnd(levelName, score, levelCompletedSuccesfully, ToNsDictionary(customAttributes));
        }

        public void LogAddToCart(decimal itemPrice, string currency, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogAddToCartWithPrice(new NSDecimalNumber(itemPrice), currency, itemName, itemType, itemId, ToNsDictionary(customAttributes));
        }

        public void LogStartCheckout(decimal totalPrice, string currency, int itemCount, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogStartCheckoutWithPrice(new NSDecimalNumber(totalPrice), currency, itemCount, ToNsDictionary(customAttributes));
        }

        public void LogRating(int rating, string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogRating(rating, contentName, contentType, contentId, ToNsDictionary(customAttributes));
        }

        public void LogContentView(string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogContentViewWithName(contentName, contentType, contentId, ToNsDictionary(customAttributes));
        }

        public void LogSearch(string query, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogSearchWithQuery(query, ToNsDictionary(customAttributes));
        }

        public void LogCustom(string eventName, Dictionary<string, object> customAttributes = null)
        {
            Bindings.AnswersKit.Answers.LogCustomEventWithName(eventName, ToNsDictionary(customAttributes));
        }

        private static NSDictionary<NSString, NSObject> ToNsDictionary(IDictionary<string, object> source)
        {
            if (source == null) return null;

            var keys = new object[source.Keys.Count];
            var i = 0;
            foreach (var key in source.Keys)
            {
                keys[i] = key;
                i++;
            }
            var objects = new object[source.Values.Count];
            source.Values.CopyTo(objects, 0);
            return NSDictionary<NSString, NSObject>.FromObjectsAndKeys(objects, keys);
        }
    }

    public static class Initializer
    {
        private static readonly object InitializeLock = new object();
        private static bool _initialized;

        public static void Initialize(this IAnswers answers)
        {
            if (_initialized) return;
            lock (InitializeLock)
            {
                if (_initialized) return;

                Fabric.Instance.Kits.Add(answers);

                _initialized = true;
            }
        }
    }
}