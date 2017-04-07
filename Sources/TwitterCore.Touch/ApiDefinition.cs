using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Bindings.TwitterCore
{
	[Static]
	partial interface Constants
	{
		// extern NSString *const _Nonnull TWTRAPIErrorDomain;
		[Field("TWTRAPIErrorDomain", "__Internal")]
		NSString TWTRAPIErrorDomain { get; }

		// extern NSString *const _Nonnull TWTRErrorDomain;
		[Field("TWTRErrorDomain", "__Internal")]
		NSString TWTRErrorDomain { get; }

		// extern NSString *const _Nonnull TWTRLogInErrorDomain;
		[Field("TWTRLogInErrorDomain", "__Internal")]
		NSString TWTRLogInErrorDomain { get; }

		// extern NSString *const _Nonnull TWTROAuthEchoRequestURLStringKey;
		[Field("TWTROAuthEchoRequestURLStringKey", "__Internal")]
		NSString TWTROAuthEchoRequestURLStringKey { get; }

		// extern NSString *const _Nonnull TWTROAuthEchoAuthorizationHeaderKey;
		[Field("TWTROAuthEchoAuthorizationHeaderKey", "__Internal")]
		NSString TWTROAuthEchoAuthorizationHeaderKey { get; }
	}

	// @interface TWTRAuthConfig : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface TWTRAuthConfig
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull consumerKey;
		[Export("consumerKey")]
		string ConsumerKey { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull consumerSecret;
		[Export("consumerSecret")]
		string ConsumerSecret { get; }

		// -(instancetype _Nonnull)initWithConsumerKey:(NSString * _Nonnull)consumerKey consumerSecret:(NSString * _Nonnull)consumerSecret;
		[Export("initWithConsumerKey:consumerSecret:")]
		IntPtr Constructor(string consumerKey, string consumerSecret);
	}

	// @protocol TWTRBaseSession <NSObject, NSCoding>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWTRBaseSession : INSCoding
	{
	}

	// @protocol TWTRAuthSession <TWTRBaseSession>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWTRAuthSession : TWTRBaseSession
	{
		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull authToken;
		[Abstract]
		[Export("authToken")]
		string AuthToken { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull authTokenSecret;
		[Abstract]
		[Export("authTokenSecret")]
		string AuthTokenSecret { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
		[Abstract]
		[Export("userID")]
		string UserID { get; }
	}

	// @protocol TWTRCoreOAuthSigning <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWTRCoreOAuthSigning
	{
		// @required -(NSDictionary * _Nonnull)OAuthEchoHeadersForRequestMethod:(NSString * _Nonnull)method URLString:(NSString * _Nonnull)URLString parameters:(NSDictionary * _Nullable)parameters error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export("OAuthEchoHeadersForRequestMethod:URLString:parameters:error:")]
		NSDictionary URLString(string method, string URLString, [NullAllowed] NSDictionary parameters, [NullAllowed] out NSError error);

		// @required -(NSDictionary * _Nonnull)OAuthEchoHeadersToVerifyCredentials;
		[Abstract]
		[Export("OAuthEchoHeadersToVerifyCredentials")]
		NSDictionary OAuthEchoHeadersToVerifyCredentials { get; }
	}

	// typedef void (^TWTRGuestLogInCompletion)(TWTRGuestSession * _Nullable, NSError * _Nullable);
	delegate void TWTRGuestLogInCompletion([NullAllowed] TWTRGuestSession arg0, [NullAllowed] NSError arg1);

	// @interface TWTRGuestSession : NSObject <TWTRBaseSession>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface TWTRGuestSession : TWTRBaseSession
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull accessToken;
		[Export("accessToken")]
		string AccessToken { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull guestToken;
		[Export("guestToken")]
		string GuestToken { get; }

		// @property (readonly, nonatomic) BOOL probablyNeedsRefreshing;
		[Export("probablyNeedsRefreshing")]
		bool ProbablyNeedsRefreshing { get; }

		// -(instancetype _Nonnull)initWithSessionDictionary:(NSDictionary * _Nonnull)sessionDictionary;
		[Export("initWithSessionDictionary:")]
		IntPtr Constructor(NSDictionary sessionDictionary);

		// -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nonnull)accessToken guestToken:(NSString * _Nullable)guestToken;
		[Export("initWithAccessToken:guestToken:")]
		IntPtr Constructor(string accessToken, [NullAllowed] string guestToken);
	}

	// typedef void (^TWTRLogInCompletion)(TWTRSession * _Nullable, NSError * _Nullable);
	delegate void TWTRLogInCompletion([NullAllowed] TWTRSession arg0, [NullAllowed] NSError arg1);

	// @interface TWTRSession : NSObject <TWTRAuthSession>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface TWTRSession : TWTRAuthSession
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull authToken;
		[Export("authToken")]
		string AuthToken { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull authTokenSecret;
		[Export("authTokenSecret")]
		string AuthTokenSecret { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull userName;
		[Export("userName")]
		string UserName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
		[Export("userID")]
		string UserID { get; }

		// -(instancetype _Nonnull)initWithSessionDictionary:(NSDictionary * _Nonnull)sessionDictionary;
		[Export("initWithSessionDictionary:")]
		IntPtr Constructor(NSDictionary sessionDictionary);

		// -(instancetype _Nonnull)initWithAuthToken:(NSString * _Nonnull)authToken authTokenSecret:(NSString * _Nonnull)authTokenSecret userName:(NSString * _Nonnull)userName userID:(NSString * _Nonnull)userID __attribute__((objc_designated_initializer));
		[Export("initWithAuthToken:authTokenSecret:userName:userID:")]
		[DesignatedInitializer]
		IntPtr Constructor(string authToken, string authTokenSecret, string userName, string userID);
	}

	// typedef void (^TWTRSessionStoreRefreshCompletion)(id _Nullable, NSError * _Nullable);
	delegate void TWTRSessionStoreRefreshCompletion([NullAllowed] NSObject arg0, [NullAllowed] NSError arg1);

	// @protocol TWTRSessionRefreshingStore <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWTRSessionRefreshingStore
	{
		// @required -(void)refreshSessionClass:(Class _Nonnull)sessionClass sessionID:(NSString * _Nullable)sessionID completion:(TWTRSessionStoreRefreshCompletion _Nonnull)completion;
		[Abstract]
		[Export("refreshSessionClass:sessionID:completion:")]
		void RefreshSessionClass(Class sessionClass, [NullAllowed] string sessionID, TWTRSessionStoreRefreshCompletion completion);

		// @required -(BOOL)isExpiredSession:(id _Nonnull)session response:(NSHTTPURLResponse * _Nonnull)response;
		[Abstract]
		[Export("isExpiredSession:response:")]
		bool IsExpiredSession(NSObject session, NSHttpUrlResponse response);

		// @required -(BOOL)isExpiredSession:(id _Nonnull)session error:(NSError * _Nonnull)error;
		[Abstract]
		[Export("isExpiredSession:error:")]
		bool IsExpiredSession(NSObject session, NSError error);
	}

	// typedef void (^TWTRSessionStoreSaveCompletion)(id<TWTRAuthSession> _Nullable, NSError * _Nullable);
	delegate void TWTRSessionStoreSaveCompletion([NullAllowed] TWTRAuthSession arg0, [NullAllowed] NSError arg1);

	// typedef void (^TWTRSessionStoreBatchFetchCompletion)(NSArray * _Nonnull);
	delegate void TWTRSessionStoreBatchFetchCompletion(NSObject[] arg0);

	// typedef void (^TWTRSessionStoreDeleteCompletion)(id<TWTRAuthSession> _Nullable);
	delegate void TWTRSessionStoreDeleteCompletion([NullAllowed] TWTRAuthSession arg0);

	// @protocol TWTRUserSessionStore <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWTRUserSessionStore
	{
		// @required -(void)saveSession:(id<TWTRAuthSession> _Nonnull)session completion:(TWTRSessionStoreSaveCompletion _Nonnull)completion;
		[Abstract]
		[Export("saveSession:completion:")]
		void SaveSession(TWTRAuthSession session, TWTRSessionStoreSaveCompletion completion);

		// @required -(void)saveSessionWithAuthToken:(NSString * _Nonnull)authToken authTokenSecret:(NSString * _Nonnull)authTokenSecret completion:(TWTRSessionStoreSaveCompletion _Nonnull)completion;
		[Abstract]
		[Export("saveSessionWithAuthToken:authTokenSecret:completion:")]
		void SaveSessionWithAuthToken(string authToken, string authTokenSecret, TWTRSessionStoreSaveCompletion completion);

		// @required -(id<TWTRAuthSession> _Nullable)sessionForUserID:(NSString * _Nonnull)userID;
		[Abstract]
		[Export("sessionForUserID:")]
		[return: NullAllowed]
		TWTRAuthSession SessionForUserID(string userID);

		// @required -(NSArray * _Nonnull)existingUserSessions;
		[Abstract]
		[Export("existingUserSessions")]
		NSObject[] ExistingUserSessions { get; }

		// @required -(id<TWTRAuthSession> _Nullable)session;
		[Abstract]
		[NullAllowed, Export("session")]
		TWTRAuthSession Session { get; }

		// @required -(void)logOutUserID:(NSString * _Nonnull)userID;
		[Abstract]
		[Export("logOutUserID:")]
		void LogOutUserID(string userID);
	}

	// typedef void (^TWTRSessionGuestLogInCompletion)(TWTRGuestSession * _Nullable, NSError * _Nullable);
	delegate void TWTRSessionGuestLogInCompletion([NullAllowed] TWTRGuestSession arg0, [NullAllowed] NSError arg1);

	// @protocol TWTRGuestSessionStore <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWTRGuestSessionStore
	{
		// @required -(void)fetchGuestSessionWithCompletion:(TWTRSessionGuestLogInCompletion _Nonnull)completion;
		[Abstract]
		[Export("fetchGuestSessionWithCompletion:")]
		void FetchGuestSessionWithCompletion(TWTRSessionGuestLogInCompletion completion);
	}

	// @protocol TWTRSessionStore <TWTRUserSessionStore, TWTRGuestSessionStore, TWTRSessionRefreshingStore>
	[Protocol, Model]
	interface TWTRSessionStore : TWTRUserSessionStore, TWTRGuestSessionStore, TWTRSessionRefreshingStore
	{
		// @required @property (readonly, nonatomic) TWTRAuthConfig * _Nonnull authConfig;
		[Abstract]
		[Export("authConfig")]
		TWTRAuthConfig AuthConfig { get; }
	}
}