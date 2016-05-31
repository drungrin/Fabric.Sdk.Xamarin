using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Bindings.TwitterCore
{
    // @protocol TWTRAuthSession <TWTRBaseSession>
    [Protocol(Name = "TWTRAuthSession"), Model]
    public interface TWTRAuthSession
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull authToken;
        [Export("authToken")]
        string AuthToken { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull authTokenSecret;
        [Export("authTokenSecret")]
        string AuthTokenSecret { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
        [Export("userID")]
        string UserID { get; }
    }

    [Protocol(Name = "TWTRCoreOAuthSigning"), Model]
    [BaseType(typeof(NSObject))]
    public interface TWTRCoreOAuthSigning
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

    [BaseType(typeof(NSObject))]
    public interface TWTRAuthConfig
    {
        // @property (readonly, copy, nonatomic) NSString * consumerKey;
        [Export("consumerKey")]
        string ConsumerKey { get; }

        // @property (readonly, copy, nonatomic) NSString * consumerSecret;
        [Export("consumerSecret")]
        string ConsumerSecret { get; }

        // -(instancetype)initWithConsumerKey:(NSString *)consumerKey consumerSecret:(NSString *)consumerSecret;
        [Export("initWithConsumerKey:consumerSecret:")]
        IntPtr Constructor(string consumerKey, string consumerSecret);
    }

    // @interface TWTRGuestSession : NSObject <TWTRBaseSession>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    public interface TWTRGuestSession
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
}