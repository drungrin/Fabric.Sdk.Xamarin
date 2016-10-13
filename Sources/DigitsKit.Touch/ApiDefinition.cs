using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using Bindings.TwitterCore;

namespace Bindings.DigitsKit
{
    // @interface DGTSession : NSObject <TWTRAuthSession>
    [BaseType(typeof(NSObject))]
    public interface DGTSession
    {
        // @property (readonly, copy, nonatomic) NSString * authToken;
        [Export("authToken")]
        string AuthToken { get; }

        // @property (readonly, copy, nonatomic) NSString * authTokenSecret;
        [Export("authTokenSecret")]
        string AuthTokenSecret { get; }

        // @property (readonly, copy, nonatomic) NSString * userID;
        [Export("userID")]
        string UserID { get; }

        // @property (readonly, copy, nonatomic) NSString * phoneNumber;
        [Export("phoneNumber")]
        string PhoneNumber { get; }

        // @property (readonly, copy, nonatomic) NSString * emailAddress;
        [Export("emailAddress")]
        string EmailAddress { get; }

        // @property (readonly, nonatomic) BOOL emailAddressIsVerified;
        [Export("emailAddressIsVerified")]
        bool EmailAddressIsVerified { get; }

        // -(instancetype)initWithAuthToken:(NSString *)authToken authTokenSecret:(NSString *)authTokenSecret userID:(NSString *)userID phoneNumber:(NSString *)phoneNumber;
        [Export("initWithAuthToken:authTokenSecret:userID:phoneNumber:")]
        IntPtr Constructor(string authToken, string authTokenSecret, string userID, string phoneNumber);

        // -(instancetype)initWithAuthToken:(NSString *)authToken authTokenSecret:(NSString *)authTokenSecret userID:(NSString *)userID phoneNumber:(NSString *)phoneNumber emailAddress:(NSString *)emailAddress emailAddressIsVerified:(BOOL)emailAddressIsVerified;
        [Export("initWithAuthToken:authTokenSecret:userID:phoneNumber:emailAddress:emailAddressIsVerified:")]
        IntPtr Constructor(string authToken, string authTokenSecret, string userID, string phoneNumber, string emailAddress, bool emailAddressIsVerified);
    }

    // @interface DGTAPIClient : NSObject
    [BaseType(typeof(NSObject))]
    interface DGTAPIClient
    {
        // -(void)authenticateWithConfiguration:(DGTAuthenticationConfiguration *)configuration delegate:(id<DGTAPIAuthenticationDelegate>)authDelegate completion:(DGTAuthenticationCompletion)completionBlock;
        [Export("authenticateWithConfiguration:delegate:completion:")]
        void AuthenticateWithConfiguration(DGTAuthenticationConfiguration configuration, DGTAPIAuthenticationDelegate authDelegate, DGTAuthenticationCompletion completionBlock);
    }

    // @protocol DGTAPIAuthenticationDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface DGTAPIAuthenticationDelegate
    {
        // @required -(void)challengeViewController:(UIViewController<DGTAPIChallengeDelegate> *)challengeViewController error:(NSError *)error;
        [Abstract]
        [Export("challengeViewController:error:")]
        void ChallengeViewController(UIViewController challengeViewController, NSError error);
    }

    // @interface DGTAuthenticateButton : UIButton
    [BaseType(typeof(UIButton))]
    interface DGTAuthenticateButton
    {
        // +(instancetype)buttonWithAuthenticationCompletion:(DGTAuthenticationCompletion)completion;
        [Static]
        [Export("buttonWithAuthenticationCompletion:")]
        DGTAuthenticateButton ButtonWithAuthenticationCompletion(DGTAuthenticationCompletion completion);

        // @property (copy, nonatomic) DGTAppearance * digitsAppearance;
        [Export("digitsAppearance", ArgumentSemantic.Copy)]
        DGTAppearance DigitsAppearance { get; set; }
    }

    // @interface DGTAppearance : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    public interface DGTAppearance : INSCopying
    {
        // @property (nonatomic, strong) UIColor * backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * accentColor;
        [Export("accentColor", ArgumentSemantic.Strong)]
        UIColor AccentColor { get; set; }

        // @property (nonatomic, strong) UIFont * headerFont;
        [Export("headerFont", ArgumentSemantic.Strong)]
        UIFont HeaderFont { get; set; }

        // @property (nonatomic, strong) UIFont * labelFont;
        [Export("labelFont", ArgumentSemantic.Strong)]
        UIFont LabelFont { get; set; }

        // @property (nonatomic, strong) UIFont * bodyFont;
        [Export("bodyFont", ArgumentSemantic.Strong)]
        UIFont BodyFont { get; set; }

        // @property (nonatomic, strong) UIImage * logoImage;
        [Export("logoImage", ArgumentSemantic.Strong)]
        UIImage LogoImage { get; set; }
    }

    // @interface DGTAuthenticationConfiguration : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface DGTAuthenticationConfiguration : INSCopying
    {
        // @property (nonatomic, strong) DGTAppearance * appearance;
        [Export("appearance", ArgumentSemantic.Strong)]
        DGTAppearance Appearance { get; set; }

        // @property (nonatomic, strong) NSString * phoneNumber;
        [Export("phoneNumber", ArgumentSemantic.Strong)]
        string PhoneNumber { get; set; }

        // @property (nonatomic, strong) NSString * title;
        [Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // -(instancetype)initWithAccountFields:(DGTAccountFields)accountFields;
        [Export("initWithAccountFields:")]
        IntPtr Constructor(DGTAccountFields accountFields);
    }

    public delegate void DGTAuthenticationCompletion(DGTSession arg0, NSError arg1);

    // @interface Digits : NSObject
    [BaseType(typeof(NSObject))]
    public interface Digits
    {
        // extern NSString *const DGTErrorDomain;
        [Field("DGTErrorDomain", "__Internal")]
        NSString DGTErrorDomain { get; }

        // +(Digits * _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        Digits SharedInstance { get; }

        // -(void)startWithConsumerKey:(NSString * _Nonnull)consumerKey consumerSecret:(NSString * _Nonnull)consumerSecret;
        [Export("startWithConsumerKey:consumerSecret:")]
        void StartWithConsumerKey(string consumerKey, string consumerSecret);

        // -(void)startWithConsumerKey:(NSString * _Nonnull)consumerKey consumerSecret:(NSString * _Nonnull)consumerSecret accessGroup:(NSString * _Nullable)accessGroup;
        [Export("startWithConsumerKey:consumerSecret:accessGroup:")]
        void StartWithConsumerKey(string consumerKey, string consumerSecret, [NullAllowed] string accessGroup);

        // -(DGTSession * _Nullable)session;
        [NullAllowed, Export("session")]
        DGTSession Session { get; }

        // @property (readonly, nonatomic, strong) TWTRAuthConfig * _Nonnull authConfig;
        [Export("authConfig", ArgumentSemantic.Strong)]
        TWTRAuthConfig AuthConfig { get; }

        [Wrap("WeakSessionUpdateDelegate")]
        [NullAllowed]
        IDGTSessionUpdateDelegate SessionUpdateDelegate { get; set; }

        // @property (nonatomic, weak) id<DGTSessionUpdateDelegate> _Nullable sessionUpdateDelegate;
        [NullAllowed, Export("sessionUpdateDelegate", ArgumentSemantic.Weak)]
        NSObject WeakSessionUpdateDelegate { get; set; }

        // -(void)authenticateWithCompletion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
        [Export("authenticateWithCompletion:")]
        void AuthenticateWithCompletion(DGTAuthenticationCompletion completion);

        // -(void)authenticateWithViewController:(UIViewController * _Nullable)viewController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
        [Export("authenticateWithViewController:configuration:completion:")]
        void AuthenticateWithViewController([NullAllowed] UIViewController viewController, DGTAuthenticationConfiguration configuration, DGTAuthenticationCompletion completion);

        // -(void)authenticateWithNavigationViewController:(UINavigationController * _Nonnull)navigationController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completionViewController:(id<DGTCompletionViewController> _Nonnull)completionViewController __attribute__((availability(tvos, unavailable)));
        [Export("authenticateWithNavigationViewController:configuration:completionViewController:")]
        void AuthenticateWithNavigationViewController(UINavigationController navigationController, DGTAuthenticationConfiguration configuration, IDGTCompletionViewController completionViewController);

        // -(void)logOut;
        [Export("logOut")]
        void LogOut();
    }

    [Protocol(Name = "DGTCompletionViewController"), Model]
    [BaseType(typeof(NSObject))]
    public interface IDGTCompletionViewController
    {
        // @required -(void)digitsAuthenticationFinishedWithSession:(DGTSession *)session error:(NSError *)error;
        [Abstract]
        [Export("digitsAuthenticationFinishedWithSession:error:")]
        void Error(DGTSession session, NSError error);
    }

    // @protocol DGTSessionUpdateDelegate <NSObject>
    [Protocol(Name = "DGTSessionUpdateDelegate"), Model]
    [BaseType(typeof(NSObject))]
    public interface IDGTSessionUpdateDelegate
    {
        // @required -(void)digitsSessionHasChanged:(DGTSession *)newSession;
        [Abstract]
        [Export("digitsSessionHasChanged:")]
        void DigitsSessionHasChanged(DGTSession newSession);

        // @required -(void)digitsSessionExpiredForUserID:(NSString *)userID;
        [Abstract]
        [Export("digitsSessionExpiredForUserID:")]
        void DigitsSessionExpiredForUserID(string userID);
    }

    // typedef void (^DGTUploadContactsCompletion)(DGTContactsUploadResult *, NSError *);
    delegate void DGTUploadContactsCompletion(DGTContactsUploadResult arg0, NSError arg1);

    // typedef void (^DGTLookupContactsCompletion)(NSArray *, NSString *, NSError *);
    delegate void DGTLookupContactsCompletion(NSObject[] arg0, string arg1, NSError arg2);

    // typedef void (^DGTDeleteAllUploadedContactsCompletion)(NSError *);
    delegate void DGTDeleteAllUploadedContactsCompletion(NSError arg0);


    // @interface DGTContacts : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface DGTContacts
    {
        // +(DGTContactAccessAuthorizationStatus)contactsAccessAuthorizationStatus;
        [Static]
        [Export("contactsAccessAuthorizationStatus")]
        DGTContactAccessAuthorizationStatus ContactsAccessAuthorizationStatus { get; }

        // -(instancetype)initWithUserSession:(DGTSession *)userSession;
        [Export("initWithUserSession:")]
        IntPtr Constructor(DGTSession userSession);

        // -(void)startContactsUploadWithCompletion:(DGTUploadContactsCompletion)completion;
        [Export("startContactsUploadWithCompletion:")]
        void StartContactsUploadWithCompletion(DGTUploadContactsCompletion completion);

        // -(void)startContactsUploadWithTitle:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
        [Export("startContactsUploadWithTitle:completion:")]
        void StartContactsUploadWithTitle(string title, DGTUploadContactsCompletion completion);

        // -(void)startContactsUploadWithPresenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
        [Export("startContactsUploadWithPresenterViewController:title:completion:")]
        void StartContactsUploadWithPresenterViewController(UIViewController presenterViewController, string title, DGTUploadContactsCompletion completion);

        // -(void)startContactsUploadWithDigitsAppearance:(DGTAppearance *)appearance presenterViewController:(UIViewController *)presenterViewController title:(NSString *)title completion:(DGTUploadContactsCompletion)completion;
        [Export("startContactsUploadWithDigitsAppearance:presenterViewController:title:completion:")]
        void StartContactsUploadWithDigitsAppearance(DGTAppearance appearance, UIViewController presenterViewController, string title, DGTUploadContactsCompletion completion);

        // -(void)lookupContactMatchesWithCursor:(NSString *)cursor completion:(DGTLookupContactsCompletion)completion;
        [Export("lookupContactMatchesWithCursor:completion:")]
        void LookupContactMatchesWithCursor(string cursor, DGTLookupContactsCompletion completion);

        // -(void)deleteAllUploadedContactsWithCompletion:(DGTDeleteAllUploadedContactsCompletion)completion;
        [Export("deleteAllUploadedContactsWithCompletion:")]
        void DeleteAllUploadedContactsWithCompletion(DGTDeleteAllUploadedContactsCompletion completion);
    }

    // @interface DGTContactsUploadResult : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface DGTContactsUploadResult
    {
        // @property (readonly, nonatomic) NSUInteger totalContacts;
        [Export("totalContacts")]
        nuint TotalContacts { get; }

        // @property (readonly, nonatomic) NSUInteger numberOfUploadedContacts;
        [Export("numberOfUploadedContacts")]
        nuint NumberOfUploadedContacts { get; }
    }

    // @interface DGTUser : NSObject
    [BaseType(typeof(NSObject))]
    interface DGTUser
    {
        // @property (readonly, copy, nonatomic) NSString * userID;
        [Export("userID")]
        string UserID { get; }
    }

    // @interface DGTOAuthSigning : NSObject <TWTRCoreOAuthSigning>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface DGTOAuthSigning : ITWTRCoreOAuthSigning
    {
        // -(instancetype)initWithAuthConfig:(TWTRAuthConfig *)authConfig authSession:(DGTSession *)authSession __attribute__((objc_designated_initializer));
        [Export("initWithAuthConfig:authSession:")]
        [DesignatedInitializer]
        IntPtr Constructor(TWTRAuthConfig authConfig, DGTSession authSession);

        // -(NSDictionary *)OAuthEchoHeadersToVerifyCredentialsWithParams:(NSDictionary *)params;
        [Export("OAuthEchoHeadersToVerifyCredentialsWithParams:")]
        NSDictionary OAuthEchoHeadersToVerifyCredentialsWithParams(NSDictionary @params);
    }
}

