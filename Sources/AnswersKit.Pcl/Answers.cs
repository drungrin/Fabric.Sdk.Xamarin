using System;
using System.Collections.Generic;

namespace AnswersKit
{
    public sealed class Answers : IAnswers
    {
        private static readonly Lazy<Answers> LazyInstance = new Lazy<Answers>(() => new Answers());

        private Answers()
        {

        }

        public static IAnswers Instance => LazyInstance.Value;

        
        public void LogSignUp(string signUpMethod, bool signUpSucceeded, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogLogin(string loginMethod, bool loginSucceeded, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogShare(string shareMethod, string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogInvite(string inviteMethod, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogPurchase(decimal itemPrice, string currency, bool purchaseSucceeded, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogLevelStart(string levelName, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogLevelEnd(string levelName, double score, bool levelCompletedSuccesfully, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogAddToCart(decimal itemPrice, string currency, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogStartCheckout(decimal totalPrice, string currency, int itemCount, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogRating(int rating, string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogContentView(string contentName, string contentType, string contentId, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogSearch(string query, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }

        public void LogCustom(string eventName, Dictionary<string, object> customAttributes = null)
        {
            throw new AnswersPlatformNotSupportedException();
        }
    }

    internal sealed class AnswersPlatformNotSupportedException : PlatformNotSupportedException
    {
        public AnswersPlatformNotSupportedException() : base("The PCL build of Answers is being linked which probably means you need to use NuGet or otherwise link a platform-specific Answers.Platform.dll to your main application.")
        {
            
        }
    }
}