using System;
using System.Collections.Generic;
using System.Globalization;
using Android.Content;
using Bindings.AnswersKit;
using FabricSdk;
using Java.Lang;
using Java.Math;
using Java.Util;
using Byte = Java.Lang.Byte;
using Double = Java.Lang.Double;

namespace AnswersKit
{
    public sealed class Answers : Kit, IAnswers
    {
        private static readonly Lazy<Answers> LazyInstance = new Lazy<Answers>(() => new Answers());

        private Answers() : base(new Bindings.AnswersKit.Answers())
        {

        }

        public static IAnswers Instance => LazyInstance.Value;
        
        public void LogSignUp(string signUpMethod, bool signUpSucceeded,
            Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new SignUpEvent();
            answersEvent.PutMethod(signUpMethod);
            answersEvent.PutSuccess(signUpSucceeded);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogSignUp(answersEvent);
        }

        public void LogLogin(string loginMethod, bool loginSucceeded,
            Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new LoginEvent();
            answersEvent.PutMethod(loginMethod);
            answersEvent.PutSuccess(loginSucceeded);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogLogin(answersEvent);
        }

        public void LogShare(string shareMethod, string contentName, string contentType, string contentId,
            Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new ShareEvent();
            answersEvent.PutMethod(shareMethod);
            answersEvent.PutContentName(contentName);
            answersEvent.PutContentType(contentType);
            answersEvent.PutContentId(contentId);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogShare(answersEvent);
        }

        public void LogInvite(string inviteMethod, Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new InviteEvent();
            answersEvent.PutMethod(inviteMethod);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogInvite(answersEvent);
        }

        public void LogPurchase(decimal itemPrice, string currency, bool purchaseSucceeded, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new PurchaseEvent();
            answersEvent.PutItemPrice(new BigDecimal(itemPrice.ToString(CultureInfo.InvariantCulture)));
            answersEvent.PutSuccess(purchaseSucceeded);
            answersEvent.PutItemName(itemName);
            answersEvent.PutItemType(itemType);
            answersEvent.PutItemId(itemId);
            answersEvent.PutCustomAttributes(customAttributes);
            if (currency != string.Empty)
                answersEvent.PutCurrency(Currency.GetInstance(currency));
            Bindings.AnswersKit.Answers.Instance.LogPurchase(answersEvent);
        }

        public void LogLevelStart(string levelName, Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new LevelStartEvent();
            answersEvent.PutLevelName(levelName);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogLevelStart(answersEvent);
        }

        public void LogLevelEnd(string levelName, double score, bool levelCompletedSuccesfully,
            Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new LevelEndEvent();
            answersEvent.PutLevelName(levelName);
            answersEvent.PutScore(Double.ValueOf(score));
            answersEvent.PutSuccess(levelCompletedSuccesfully);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogLevelEnd(answersEvent);
        }

        public void LogAddToCart(decimal itemPrice, string currency, string itemName, string itemType, string itemId, Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new AddToCartEvent();
            answersEvent.PutItemPrice(new BigDecimal(itemPrice.ToString(CultureInfo.InvariantCulture)));
            answersEvent.PutItemName(itemName);
            answersEvent.PutItemType(itemType);
            answersEvent.PutItemId(itemId);
            if (currency != string.Empty)
                answersEvent.PutCurrency(Currency.GetInstance(currency));
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogAddToCart(answersEvent);
        }

        public void LogStartCheckout(decimal totalPrice, string currency, int itemCount, Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new StartCheckoutEvent();
            answersEvent.PutTotalPrice(new BigDecimal(totalPrice.ToString(CultureInfo.InvariantCulture)));
            answersEvent.PutItemCount(itemCount);
            if (currency != string.Empty)
                answersEvent.PutCurrency(Currency.GetInstance(currency));
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogStartCheckout(answersEvent);
        }

        public void LogRating(int rating, string contentName, string contentType, string contentId,
            Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new RatingEvent();
            answersEvent.PutRating(rating);
            answersEvent.PutContentName(contentName);
            answersEvent.PutContentType(contentType);
            answersEvent.PutContentId(contentId);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogRating(answersEvent);
        }

        public void LogContentView(string contentName, string contentType, string contentId,
            Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new ContentViewEvent();
            answersEvent.PutContentName(contentName);
            answersEvent.PutContentType(contentType);
            answersEvent.PutContentId(contentId);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogContentView(answersEvent);
        }

        public void LogSearch(string query, Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new SearchEvent();
            answersEvent.PutQuery(query);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogSearch(answersEvent);
        }

        public void LogCustom(string eventName, Dictionary<string, object> customAttributes = null)
        {
            var answersEvent = new CustomEvent(eventName);
            answersEvent.PutCustomAttributes(customAttributes);
            Bindings.AnswersKit.Answers.Instance.LogCustom(answersEvent);
        }
    }

    internal static class EventMixin
    {
        internal static void PutCustomAttributes(this AnswersEvent answersEvent,
            Dictionary<string, object> customAttributes)
        {
            if (customAttributes == null) return;
            foreach (var customAttribute in customAttributes)
            {
                if (customAttribute.Value is int)
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key, Integer.ValueOf((int) customAttribute.Value));
                }
                else if (customAttribute.Value is long)
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key, Long.ValueOf((long) customAttribute.Value));
                }
                else if (customAttribute.Value is float)
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key, Float.ValueOf((float) customAttribute.Value));
                }
                else if (customAttribute.Value is double)
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key,
                        Double.ValueOf((double) customAttribute.Value));
                }
                else if (customAttribute.Value is short)
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key, Short.ValueOf((short) customAttribute.Value));
                }
                else if (customAttribute.Value is sbyte)
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key,
                        Byte.ValueOf((sbyte) customAttribute.Value));
                }
                else if (customAttribute.Value is decimal)
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key,
                        new BigDecimal(customAttribute.Value.ToString()));
                }
                else
                {
                    answersEvent.PutCustomAttribute(customAttribute.Key, customAttribute.Value?.ToString());
                }
            }
        }
    }

    public static class Initializer
    {
        private static readonly object InitializeLock = new object();
        private static bool _initialized;

        public static void Initialize(this IAnswers answers, Context context)
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
