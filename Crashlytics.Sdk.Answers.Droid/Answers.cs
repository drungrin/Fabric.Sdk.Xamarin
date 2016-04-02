using Crashlytics.Sdk.Answers.Events;
using Crashlytics.Sdk.Bindings.Answers;
using Java.Lang;
using Java.Math;
using Java.Util;

namespace Crashlytics.Sdk.Answers.Droid
{
    public class Answers : IAnswers
    {
        public void LogAddToCart(AddToCart data)
        {
            var addToCartEvent = new AddToCartEvent();

            addToCartEvent.PutItemId(data.ItemId);
            addToCartEvent.PutItemName(data.ItemName);
            addToCartEvent.PutItemPrice(BigDecimal.ValueOf(data.ItemPrice));
            addToCartEvent.PutItemType(data.ItemType);
            if (data.CurrencyCode != string.Empty)
            {
                addToCartEvent.PutCurrency(Currency.GetInstance(data.CurrencyCode));
            }

            CopyCustomAttributes(data, addToCartEvent);
            CrashlyticsAnswers.Instance.LogAddToCart(addToCartEvent);
        }

        public void LogContentView(ContentView data)
        {
            var contentViewEvent = new ContentViewEvent();
            contentViewEvent.PutContentId(data.ContentId);
            contentViewEvent.PutContentName(data.ContentName);
            contentViewEvent.PutContentType(data.ContentType);

            CopyCustomAttributes(data, contentViewEvent);

            CrashlyticsAnswers.Instance.LogContentView(contentViewEvent);
        }

        public void LogCustom(Custom data)
        {
            var customEvent = new CustomEvent(data.EventName);
            CopyCustomAttributes(data, customEvent);
            CrashlyticsAnswers.Instance.LogCustom(customEvent);
        }

        public void LogInvite(Invite data)
        {
            var inviteEvent = new InviteEvent();
            inviteEvent.PutMethod(data.Method);
            CopyCustomAttributes(data, inviteEvent);
            CrashlyticsAnswers.Instance.LogInvite(inviteEvent);
        }

        public void LogLevelEnd(LevelEnd data)
        {
            var levelEndEvent = new LevelEndEvent();
            levelEndEvent.PutLevelName(data.LevelName);
            levelEndEvent.PutScore(Double.ValueOf(data.Score));
            levelEndEvent.PutSuccess(data.Success);
            CopyCustomAttributes(data, levelEndEvent);
            CrashlyticsAnswers.Instance.LogLevelEnd(levelEndEvent);
        }

        public void LogLevelStart(LevelStart data)
        {
            var levelStartEvent = new LevelStartEvent();
            levelStartEvent.PutLevelName(data.LevelName);
            CopyCustomAttributes(data, levelStartEvent);
            CrashlyticsAnswers.Instance.LogLevelStart(levelStartEvent);
        }

        public void LogLogin(Login data)
        {
            var loginEvent = new LoginEvent();
            loginEvent.PutMethod(data.Method);
            loginEvent.PutSuccess(data.Success);
            CopyCustomAttributes(data, loginEvent);
            CrashlyticsAnswers.Instance.LogLogin(loginEvent);
        }

        public void LogPurchase(Purchase data)
        {
            var purchaseEvent = new PurchaseEvent();

            purchaseEvent.PutItemId(data.ItemId);
            purchaseEvent.PutItemName(data.ItemName);
            purchaseEvent.PutItemPrice(BigDecimal.ValueOf(data.ItemPrice));
            purchaseEvent.PutItemType(data.ItemType);
            purchaseEvent.PutSuccess(data.Success);

            if (data.CurrencyCode != string.Empty)
            {
                purchaseEvent.PutCurrency(Currency.GetInstance(data.CurrencyCode));
            }

            CopyCustomAttributes(data, purchaseEvent);
            CrashlyticsAnswers.Instance.LogPurchase(purchaseEvent);
        }

        public void LogRating(Rating data)
        {
            var ratingEvent = new RatingEvent();
            ratingEvent.PutContentId(data.ContentId);
            ratingEvent.PutContentName(data.ContentName);
            ratingEvent.PutContentType(data.ContentType);
            ratingEvent.PutRating(data.Value);
            CopyCustomAttributes(data, ratingEvent);
            CrashlyticsAnswers.Instance.LogRating(ratingEvent);
        }

        public void LogSearch(Search data)
        {
            var searchEvent = new SearchEvent();
            searchEvent.PutQuery(data.Query);
            CopyCustomAttributes(data, searchEvent);
            CrashlyticsAnswers.Instance.LogSearch(searchEvent);
        }

        public void LogShare(Share data)
        {
            var shareEvent = new ShareEvent();
            shareEvent.PutContentId(data.ContentId);
            shareEvent.PutContentName(data.ContentName);
            shareEvent.PutContentType(data.ContentType);
            shareEvent.PutMethod(data.Method);
            CopyCustomAttributes(data, shareEvent);
            CrashlyticsAnswers.Instance.LogShare(shareEvent);
        }

        public void LogSignUp(SignUp data)
        {
            var signUpEvent = new SignUpEvent();
            signUpEvent.PutMethod(data.Method);
            signUpEvent.PutSuccess(data.Success);
            CopyCustomAttributes(data, signUpEvent);
            CrashlyticsAnswers.Instance.LogSignUp(signUpEvent);
        }

        public void LogStartCheckout(StartCheckout data)
        {
            var checkoutEvent = new StartCheckoutEvent();

            checkoutEvent.PutTotalPrice(BigDecimal.ValueOf(data.TotalPrice));
            checkoutEvent.PutItemCount(data.ItemCount);

            if (data.CurrencyCode != string.Empty)
            {
                checkoutEvent.PutCurrency(Currency.GetInstance(data.CurrencyCode));
            }

            CopyCustomAttributes(data, checkoutEvent);
            CrashlyticsAnswers.Instance.LogStartCheckout(checkoutEvent);
        }

        private static void CopyCustomAttributes(Base src, AnswersEvent dst)
        {
            foreach (var attribute in src.CustomStringAttributes)
            {
                dst.PutCustomAttribute(attribute.Key, attribute.Value);
            }
            foreach (var attribute in src.CustomDoubleAttributes)
            {
                dst.PutCustomAttribute(attribute.Key, Double.ValueOf(attribute.Value));
            }
            foreach (var attribute in src.CustomLongAttributes)
            {
                dst.PutCustomAttribute(attribute.Key, Long.ValueOf(attribute.Value));
            }
            foreach (var attribute in src.CustomIntegerAttributes)
            {
                dst.PutCustomAttribute(attribute.Key, Integer.ValueOf(attribute.Value));
            }
        }
    }
}