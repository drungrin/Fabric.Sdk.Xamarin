using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Bindings.AnswersKit
{
    // @interface Answers : NSObject
	[BaseType (typeof(NSObject))]
	interface Answers
	{
		// +(void)logSignUpWithMethod:(NSString * _Nullable)signUpMethodOrNil success:(NSNumber * _Nullable)signUpSucceededOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logSignUpWithMethod:success:customAttributes:")]
		void LogSignUpWithMethod([NullAllowed] string signUpMethodOrNil, [NullAllowed] NSNumber signUpSucceededOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logLoginWithMethod:(NSString * _Nullable)loginMethodOrNil success:(NSNumber * _Nullable)loginSucceededOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logLoginWithMethod:success:customAttributes:")]
		void LogLoginWithMethod([NullAllowed] string loginMethodOrNil, [NullAllowed] NSNumber loginSucceededOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logShareWithMethod:(NSString * _Nullable)shareMethodOrNil contentName:(NSString * _Nullable)contentNameOrNil contentType:(NSString * _Nullable)contentTypeOrNil contentId:(NSString * _Nullable)contentIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logShareWithMethod:contentName:contentType:contentId:customAttributes:")]
		void LogShareWithMethod([NullAllowed] string shareMethodOrNil, [NullAllowed] string contentNameOrNil, [NullAllowed] string contentTypeOrNil, [NullAllowed] string contentIdOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logInviteWithMethod:(NSString * _Nullable)inviteMethodOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logInviteWithMethod:customAttributes:")]
		void LogInviteWithMethod([NullAllowed] string inviteMethodOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logPurchaseWithPrice:(NSDecimalNumber * _Nullable)itemPriceOrNil currency:(NSString * _Nullable)currencyOrNil success:(NSNumber * _Nullable)purchaseSucceededOrNil itemName:(NSString * _Nullable)itemNameOrNil itemType:(NSString * _Nullable)itemTypeOrNil itemId:(NSString * _Nullable)itemIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logPurchaseWithPrice:currency:success:itemName:itemType:itemId:customAttributes:")]
		void LogPurchaseWithPrice([NullAllowed] NSDecimalNumber itemPriceOrNil, [NullAllowed] string currencyOrNil, [NullAllowed] NSNumber purchaseSucceededOrNil, [NullAllowed] string itemNameOrNil, [NullAllowed] string itemTypeOrNil, [NullAllowed] string itemIdOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logLevelStart:(NSString * _Nullable)levelNameOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logLevelStart:customAttributes:")]
		void LogLevelStart([NullAllowed] string levelNameOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logLevelEnd:(NSString * _Nullable)levelNameOrNil score:(NSNumber * _Nullable)scoreOrNil success:(NSNumber * _Nullable)levelCompletedSuccesfullyOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logLevelEnd:score:success:customAttributes:")]
		void LogLevelEnd([NullAllowed] string levelNameOrNil, [NullAllowed] NSNumber scoreOrNil, [NullAllowed] NSNumber levelCompletedSuccesfullyOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logAddToCartWithPrice:(NSDecimalNumber * _Nullable)itemPriceOrNil currency:(NSString * _Nullable)currencyOrNil itemName:(NSString * _Nullable)itemNameOrNil itemType:(NSString * _Nullable)itemTypeOrNil itemId:(NSString * _Nullable)itemIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logAddToCartWithPrice:currency:itemName:itemType:itemId:customAttributes:")]
		void LogAddToCartWithPrice([NullAllowed] NSDecimalNumber itemPriceOrNil, [NullAllowed] string currencyOrNil, [NullAllowed] string itemNameOrNil, [NullAllowed] string itemTypeOrNil, [NullAllowed] string itemIdOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logStartCheckoutWithPrice:(NSDecimalNumber * _Nullable)totalPriceOrNil currency:(NSString * _Nullable)currencyOrNil itemCount:(NSNumber * _Nullable)itemCountOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logStartCheckoutWithPrice:currency:itemCount:customAttributes:")]
		void LogStartCheckoutWithPrice([NullAllowed] NSDecimalNumber totalPriceOrNil, [NullAllowed] string currencyOrNil, [NullAllowed] NSNumber itemCountOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logRating:(NSNumber * _Nullable)ratingOrNil contentName:(NSString * _Nullable)contentNameOrNil contentType:(NSString * _Nullable)contentTypeOrNil contentId:(NSString * _Nullable)contentIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logRating:contentName:contentType:contentId:customAttributes:")]
		void LogRating([NullAllowed] NSNumber ratingOrNil, [NullAllowed] string contentNameOrNil, [NullAllowed] string contentTypeOrNil, [NullAllowed] string contentIdOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logContentViewWithName:(NSString * _Nullable)contentNameOrNil contentType:(NSString * _Nullable)contentTypeOrNil contentId:(NSString * _Nullable)contentIdOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logContentViewWithName:contentType:contentId:customAttributes:")]
		void LogContentViewWithName([NullAllowed] string contentNameOrNil, [NullAllowed] string contentTypeOrNil, [NullAllowed] string contentIdOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logSearchWithQuery:(NSString * _Nullable)queryOrNil customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logSearchWithQuery:customAttributes:")]
		void LogSearchWithQuery([NullAllowed] string queryOrNil, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);

		// +(void)logCustomEventWithName:(NSString * _Nonnull)eventName customAttributes:(NSDictionary<NSString *,id> * _Nullable)customAttributesOrNil;
		[Static]
		[Export("logCustomEventWithName:customAttributes:")]
		void LogCustomEventWithName(string eventName, [NullAllowed] NSDictionary<NSString, NSObject> customAttributesOrNil);
	}
}

