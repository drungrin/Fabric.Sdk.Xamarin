using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace AnswersKit.Platform
{
    // @interface Answers : NSObject
    [BaseType(typeof(NSObject))]
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

namespace CrashlyticsKit.Platform
{   
    [BaseType(typeof(NSObject))]
    public interface CLSStackFrame
    {
        // +(instancetype _Nonnull)stackFrame;
        [Static]
        [Export("stackFrame")]
        CLSStackFrame StackFrame();

        // +(instancetype _Nonnull)stackFrameWithAddress:(NSUInteger)address;
        [Static]
        [Export("stackFrameWithAddress:")]
        CLSStackFrame StackFrameWithAddress(nuint address);

        // +(instancetype _Nonnull)stackFrameWithSymbol:(NSString * _Nonnull)symbol;
        [Static]
        [Export("stackFrameWithSymbol:")]
        CLSStackFrame StackFrameWithSymbol(string symbol);

        // @property (copy, nonatomic) NSString * _Nullable symbol;
        [NullAllowed, Export("symbol")]
        string Symbol { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable library;
        [NullAllowed, Export("library")]
        string Library { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable fileName;
        [NullAllowed, Export("fileName")]
        string FileName { get; set; }

        // @property (assign, nonatomic) uint32_t lineNumber;
        [Export("lineNumber")]
        uint LineNumber { get; set; }

        // @property (assign, nonatomic) uint64_t offset;
        [Export("offset")]
        ulong Offset { get; set; }

        // @property (assign, nonatomic) uint64_t address;
        [Export("address")]
        ulong Address { get; set; }
    }

    [BaseType(typeof(NSObject))]
    public interface Crashlytics
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull APIKey;
        [Export("APIKey")]
        string APIKey { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull version;
        [Export("version")]
        string Version { get; }

        // @property (assign, nonatomic) BOOL debugMode;
        [Export("debugMode")]
        bool DebugMode { get; set; }

        // @property (assign, nonatomic) id<CrashlyticsDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // +(Crashlytics * _Nonnull)startWithAPIKey:(NSString * _Nonnull)apiKey;
        [Static]
        [Export("startWithAPIKey:")]
        Crashlytics StartWithAPIKey(string apiKey);

        // +(Crashlytics * _Nonnull)startWithAPIKey:(NSString * _Nonnull)apiKey afterDelay:(NSTimeInterval)delay __attribute__((deprecated("Crashlytics no longer needs or uses the delay parameter.  Please use +startWithAPIKey: instead.")));
        [Static]
        [Export("startWithAPIKey:afterDelay:")]
        Crashlytics StartWithAPIKey(string apiKey, double delay);

        // +(Crashlytics * _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        Crashlytics SharedInstance { get; }

        // -(void)crash;
        [Export("crash")]
        void Crash();

        // -(void)throwException;
        [Export("throwException")]
        void ThrowException();

        // -(void)setUserIdentifier:(NSString * _Nullable)identifier;
        [Export("setUserIdentifier:")]
        void SetUserIdentifier([NullAllowed] string identifier);

        // -(void)setUserName:(NSString * _Nullable)name;
        [Export("setUserName:")]
        void SetUserName([NullAllowed] string name);

        // -(void)setUserEmail:(NSString * _Nullable)email;
        [Export("setUserEmail:")]
        void SetUserEmail([NullAllowed] string email);

        // -(void)setObjectValue:(id _Nullable)value forKey:(NSString * _Nonnull)key;
        [Export("setObjectValue:forKey:")]
        void SetObjectValue([NullAllowed] NSObject value, string key);

        // -(void)setIntValue:(int)value forKey:(NSString * _Nonnull)key;
        [Export("setIntValue:forKey:")]
        void SetIntValue(int value, string key);

        // -(void)setBoolValue:(BOOL)value forKey:(NSString * _Nonnull)key;
        [Export("setBoolValue:forKey:")]
        void SetBoolValue(bool value, string key);

        // -(void)setFloatValue:(float)value forKey:(NSString * _Nonnull)key;
        [Export("setFloatValue:forKey:")]
        void SetFloatValue(float value, string key);

        // -(void)recordCustomExceptionName:(NSString * _Nonnull)name reason:(NSString * _Nullable)reason frameArray:(NSArray<CLSStackFrame *> * _Nonnull)frameArray;
        [Export("recordCustomExceptionName:reason:frameArray:")]
        void RecordCustomExceptionName(string name, [NullAllowed] string reason, CLSStackFrame[] frameArray);

        // -(void)recordError:(NSError * _Nonnull)error;
        [Export("recordError:")]
        void RecordError(NSError error);

        // -(void)recordError:(NSError * _Nonnull)error withAdditionalUserInfo:(NSDictionary<NSString *,id> * _Nullable)userInfo;
        [Export("recordError:withAdditionalUserInfo:")]
        void RecordError(NSError error, [NullAllowed] NSDictionary<NSString, NSObject> userInfo);             
    }
}

