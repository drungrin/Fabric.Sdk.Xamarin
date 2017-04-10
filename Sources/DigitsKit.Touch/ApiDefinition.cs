using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using Bindings.TwitterCore;

namespace Bindings.DigitsKit
{
	[Static]
	partial interface Constants
	{
		// extern NSString *const DGTErrorDomain;
		[Field("DGTErrorDomain", "__Internal")]
		NSString DGTErrorDomain { get; }
	}

	// @interface DGTSession : NSObject <TWTRAuthSession>
	[BaseType(typeof(NSObject))]
	interface DGTSession : ITWTRAuthSession
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

	// typedef void (^DGTAuthenticationCompletion)(DGTSession *, NSError *);
	delegate void DGTAuthenticationCompletion(DGTSession arg0, NSError arg1);

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

		// @optional -(UIViewController<DGTAPIChallengeDelegate> *)signUpViewControllerWithDeviceRegisterResponse:(DGTDeviceRegisterResponse *)deviceRegisterResponse;
		[Export("signUpViewControllerWithDeviceRegisterResponse:")]
		UIViewController SignUpViewControllerWithDeviceRegisterResponse(NSObject deviceRegisterResponse);

		// @optional -(UIViewController<DGTAPIChallengeDelegate> *)logInViewControllerWithLogInResponse:(DGTLogInAuthResponse *)logInResponse;
		[Export("logInViewControllerWithLogInResponse:")]
		UIViewController LogInViewControllerWithLogInResponse(NSObject logInResponse);
	}

	// @protocol DGTAuthEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface DGTAuthEventDelegate
	{
		// @optional -(void)digitsAuthenticationDidBegin:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsAuthenticationDidBegin:")]
		void DigitsAuthenticationDidBegin(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsPhoneNumberEntryScreenVisited:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsPhoneNumberEntryScreenVisited:")]
		void DigitsPhoneNumberEntryScreenVisited(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsPhoneNumberSubmitted:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsPhoneNumberSubmitted:")]
		void DigitsPhoneNumberSubmitted(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsPhoneNumberSubmissionDidSucceed:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsPhoneNumberSubmissionDidSucceed:")]
		void DigitsPhoneNumberSubmissionDidSucceed(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsConfirmationCodeEntryScreenVisited:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsConfirmationCodeEntryScreenVisited:")]
		void DigitsConfirmationCodeEntryScreenVisited(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsConfirmationCodeSubmitted:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsConfirmationCodeSubmitted:")]
		void DigitsConfirmationCodeSubmitted(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsAuthenticationDidComplete:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsAuthenticationDidComplete:")]
		void DigitsAuthenticationDidComplete(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsLogout:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsLogout:")]
		void DigitsLogout(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsTwoFactorPinEntryScreenVisited:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsTwoFactorPinEntryScreenVisited:")]
		void DigitsTwoFactorPinEntryScreenVisited(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsTwoFactorPinSubmitted:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsTwoFactorPinSubmitted:")]
		void DigitsTwoFactorPinSubmitted(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsTwoFactorPinSubmissionSucceeded:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsTwoFactorPinSubmissionSucceeded:")]
		void DigitsTwoFactorPinSubmissionSucceeded(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsEmailUpdateScreenVisited:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsEmailUpdateScreenVisited:")]
		void DigitsEmailUpdateScreenVisited(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsEmailUpdateSubmitted:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsEmailUpdateSubmitted:")]
		void DigitsEmailUpdateSubmitted(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsEmailUpdateSubmissionSucceeded:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsEmailUpdateSubmissionSucceeded:")]
		void DigitsEmailUpdateSubmissionSucceeded(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsErrorRescueScreenVisited:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsErrorRescueScreenVisited:")]
		void DigitsErrorRescueScreenVisited(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsUserDismissErrorRescue:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsUserDismissErrorRescue:")]
		void DigitsUserDismissErrorRescue(DGTAuthEventDetails authEventDetails);

		// @optional -(void)digitsUserRetryOnErrorRescueScreen:(DGTAuthEventDetails *)authEventDetails;
		[Export("digitsUserRetryOnErrorRescueScreen:")]
		void DigitsUserRetryOnErrorRescueScreen(DGTAuthEventDetails authEventDetails);
	}

	// @protocol ContactsPermissionForDigitsImpressionDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsPermissionForDigitsImpressionDetails
	{
	}

	// @protocol ContactsPermissionForDigitsAllowedDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsPermissionForDigitsAllowedDetails
	{
	}

	// @protocol ContactsPermissionForDigitsDeferredDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsPermissionForDigitsDeferredDetails
	{
	}

	// @protocol ContactsUploadStartDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsUploadStartDetails
	{
	}

	// @protocol ContactsUploadSuccessDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsUploadSuccessDetails
	{
		// @required -(int)totalContactsCount;
		[Abstract]
		[Export("totalContactsCount")]
		int TotalContactsCount { get; }

		// @required -(int)successContactsUploadCount;
		[Abstract]
		[Export("successContactsUploadCount")]
		int SuccessContactsUploadCount { get; }
	}

	// @protocol ContactsUploadFailureDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsUploadFailureDetails
	{
		// @required -(DGTErrorCode)errorCode;
		[Abstract]
		[Export("errorCode")]
		DGTErrorCode ErrorCode { get; }
	}

	// @protocol ContactsLookupStartDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsLookupStartDetails
	{
		// @required -(BOOL)hasCursor;
		[Abstract]
		[Export("hasCursor")]
		bool HasCursor { get; }
	}

	// @protocol ContactsLookupSuccessDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsLookupSuccessDetails
	{
		// @required -(int)matchCount;
		[Abstract]
		[Export("matchCount")]
		int MatchCount { get; }
	}

	// @protocol ContactsLookupFailureDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsLookupFailureDetails
	{
	}

	// @protocol ContactsDeletionStartDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsDeletionStartDetails
	{
	}

	// @protocol ContactsDeletionSuccessDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsDeletionSuccessDetails
	{
	}

	// @protocol ContactsDeletionFailureDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsDeletionFailureDetails
	{
	}

	// @protocol ContactsInvitationDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ContactsInvitationDetails
	{
	}

	// @protocol DGTContactsEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface DGTContactsEventDelegate
	{
		// @optional -(void)contactsPermissionForDigitsImpression:(id<ContactsPermissionForDigitsImpressionDetails>)details;
		[Export("contactsPermissionForDigitsImpression:")]
		void ContactsPermissionForDigitsImpression(ContactsPermissionForDigitsImpressionDetails details);

		// @optional -(void)contactsPermissionForDigitsAllowed:(id<ContactsPermissionForDigitsAllowedDetails>)details;
		[Export("contactsPermissionForDigitsAllowed:")]
		void ContactsPermissionForDigitsAllowed(ContactsPermissionForDigitsAllowedDetails details);

		// @optional -(void)contactsPermissionForDigitsDeferred:(id<ContactsPermissionForDigitsDeferredDetails>)details;
		[Export("contactsPermissionForDigitsDeferred:")]
		void ContactsPermissionForDigitsDeferred(ContactsPermissionForDigitsDeferredDetails details);

		// @optional -(void)contactsUploadStart:(id<ContactsUploadStartDetails>)details;
		[Export("contactsUploadStart:")]
		void ContactsUploadStart(ContactsUploadStartDetails details);

		// @optional -(void)contactsUploadSuccess:(id<ContactsUploadSuccessDetails>)details;
		[Export("contactsUploadSuccess:")]
		void ContactsUploadSuccess(ContactsUploadSuccessDetails details);

		// @optional -(void)contactsUploadFailure:(id<ContactsUploadFailureDetails>)details;
		[Export("contactsUploadFailure:")]
		void ContactsUploadFailure(ContactsUploadFailureDetails details);

		// @optional -(void)contactsLookupStart:(id<ContactsLookupStartDetails>)details;
		[Export("contactsLookupStart:")]
		void ContactsLookupStart(ContactsLookupStartDetails details);

		// @optional -(void)contactsLookupSuccess:(id<ContactsLookupSuccessDetails>)details;
		[Export("contactsLookupSuccess:")]
		void ContactsLookupSuccess(ContactsLookupSuccessDetails details);

		// @optional -(void)contactsLookupFailure:(id<ContactsLookupFailureDetails>)details;
		[Export("contactsLookupFailure:")]
		void ContactsLookupFailure(ContactsLookupFailureDetails details);

		// @optional -(void)contactsDeletionStart:(id<ContactsDeletionStartDetails>)details;
		[Export("contactsDeletionStart:")]
		void ContactsDeletionStart(ContactsDeletionStartDetails details);

		// @optional -(void)contactsDeletionSuccess:(id<ContactsDeletionSuccessDetails>)details;
		[Export("contactsDeletionSuccess:")]
		void ContactsDeletionSuccess(ContactsDeletionSuccessDetails details);

		// @optional -(void)contactsDeletionFailure:(id<ContactsDeletionFailureDetails>)details;
		[Export("contactsDeletionFailure:")]
		void ContactsDeletionFailure(ContactsDeletionFailureDetails details);

		// @optional -(void)contactsInvitationImpression:(id<ContactsInvitationDetails>)details;
		[Export("contactsInvitationImpression:")]
		void ContactsInvitationImpression(ContactsInvitationDetails details);
	}

	// typedef void (^DGTContactFetchCompletionBlock)(NSArray<DGTAddressBookContact *> * _Nullable, NSError * _Nullable);
	delegate void DGTContactFetchCompletionBlock([NullAllowed] DGTAddressBookContact[] arg0, [NullAllowed] NSError arg1);

	// @interface DGTContactsFetcher : NSObject
	[BaseType(typeof(NSObject))]
	interface DGTContactsFetcher
	{
		// @property (nonatomic, strong) NSArray<DGTAddressBookContact *> * _Nonnull contacts;
		[Export("contacts", ArgumentSemantic.Strong)]
		DGTAddressBookContact[] Contacts { get; set; }

		// -(void)fetchContactsOnlyInApp:(BOOL)shouldFetchInAppContactsOnly withCompletion:(DGTContactFetchCompletionBlock _Nonnull)completion;
		[Export("fetchContactsOnlyInApp:withCompletion:")]
		void FetchContactsOnlyInApp(bool shouldFetchInAppContactsOnly, DGTContactFetchCompletionBlock completion);
	}

	// @protocol DGTContactsInvitationDataSourceDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface DGTContactsInvitationDataSourceDelegate
	{
		// @optional -(void)contactsInvitationDataSource:(DGTContactsInvitationDataSource * _Nonnull)dataSource configurableCell:(DGTConfigurableTableViewCell * _Nonnull)cell forRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("contactsInvitationDataSource:configurableCell:forRowAtIndexPath:")]
		void ConfigurableCell(DGTContactsInvitationDataSource dataSource, DGTConfigurableTableViewCell cell, NSIndexPath indexPath);
	}

	// @interface DGTContactsInvitationDataSource : NSObject <UITableViewDataSource>
	[BaseType(typeof(NSObject))]
	interface DGTContactsInvitationDataSource : IUITableViewDataSource
	{
		// @property (nonatomic, strong) Class _Nullable cellClass;
		[NullAllowed, Export("cellClass", ArgumentSemantic.Strong)]
		Class CellClass { get; set; }

		// @property (nonatomic, strong) UITableView * _Nullable tableView;
		[NullAllowed, Export("tableView", ArgumentSemantic.Strong)]
		UITableView TableView { get; set; }

		// @property (nonatomic, strong) DGTContactsFetcher * _Nonnull contactsFetcher;
		[Export("contactsFetcher", ArgumentSemantic.Strong)]
		DGTContactsFetcher ContactsFetcher { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		DGTContactsInvitationDataSourceDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<DGTContactsInvitationDataSourceDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(DGTAddressBookContact * _Nonnull)contactAtIndex:(NSInteger)index;
		[Export("contactAtIndex:")]
		DGTAddressBookContact ContactAtIndex(nint index);

		// -(void)fetchContactsOnlyInApp:(BOOL)shouldFetchInAppContactsOnly withCompletion:(DGTContactFetchCompletionBlock _Nonnull)completion;
		[Export("fetchContactsOnlyInApp:withCompletion:")]
		void FetchContactsOnlyInApp(bool shouldFetchInAppContactsOnly, DGTContactFetchCompletionBlock completion);

		// -(UITableViewCell * _Nonnull)tableView:(UITableView * _Nonnull)tableView cellForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("tableView:cellForRowAtIndexPath:")]
		UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath);

		// -(NSInteger)tableView:(UITableView * _Nonnull)tableView numberOfRowsInSection:(NSInteger)section;
		[Export("tableView:numberOfRowsInSection:")]
		nint RowsInSection(UITableView tableView, nint section);
	}

	// @interface DGTConfigurableTableViewCell : UITableViewCell
	[BaseType(typeof(UITableViewCell))]
	interface DGTConfigurableTableViewCell
	{
		// -(void)configure:(DGTAddressBookContact *)contact;
		[Export("configure:")]
		void Configure(DGTAddressBookContact contact);
	}

	// @interface DGTAddressBookContact : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface DGTAddressBookContact
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull displayName;
		[Export("displayName")]
		string DisplayName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull phoneNumberFromAddressBook;
		[Export("phoneNumberFromAddressBook")]
		string PhoneNumberFromAddressBook { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull normalizedPhoneNumber;
		[Export("normalizedPhoneNumber")]
		string NormalizedPhoneNumber { get; }

		// @property (copy, nonatomic) NSString * _Nullable userID;
		[NullAllowed, Export("userID")]
		string UserID { get; set; }

		// @property (nonatomic) BOOL invited;
		[Export("invited")]
		bool Invited { get; set; }

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)displayName numberFromAddressBook:(NSString * _Nonnull)phoneNumber;
		[Export("initWithName:numberFromAddressBook:")]
		IntPtr Constructor(string displayName, string phoneNumber);
	}

	// @protocol AttributionEventDetails <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface AttributionEventDetails
	{
	}

	// @protocol DGTAttributionEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface DGTAttributionEventDelegate
	{
		// @optional -(void)inviteConversionDetectedWithMatches:(NSArray<DGTInviteStatus *> *)matches;
		[Export("inviteConversionDetectedWithMatches:")]
		void InviteConversionDetectedWithMatches(DGTInviteStatus[] matches);
	}

	// @interface DGTInviteStatus : NSObject
	[BaseType(typeof(NSObject))]
	interface DGTInviteStatus
	{
		// @property (copy, nonatomic) NSString * appID;
		[Export("appID")]
		string AppID { get; set; }

		// @property (copy, nonatomic) NSDate * inviteLastSent;
		[Export("inviteLastSent", ArgumentSemantic.Copy)]
		NSDate InviteLastSent { get; set; }

		// @property (copy, nonatomic) NSString * phoneNumber;
		[Export("phoneNumber")]
		string PhoneNumber { get; set; }

		// @property (copy, nonatomic) NSString * inviterID;
		[Export("inviterID")]
		string InviterID { get; set; }

		// @property (copy, nonatomic) NSString * friendID;
		[Export("friendID")]
		string FriendID { get; set; }

		// @property (copy, nonatomic) NSDate * convertedTime;
		[Export("convertedTime", ArgumentSemantic.Copy)]
		NSDate ConvertedTime { get; set; }

		// @property (nonatomic) DGTInviteState inviteState;
		[Export("inviteState", ArgumentSemantic.Assign)]
		DGTInviteState InviteState { get; set; }
	}

	// @interface DGTAuthEventDetails : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface DGTAuthEventDetails
	{
		// @property (readonly, assign, nonatomic) NSTimeInterval elapsedTime;
		[Export("elapsedTime")]
		double ElapsedTime { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull language;
		[Export("language", ArgumentSemantic.Strong)]
		string Language { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable countryISOCode;
		[NullAllowed, Export("countryISOCode", ArgumentSemantic.Strong)]
		string CountryISOCode { get; }
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

	// @interface DGTAuthenticationConfiguration : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface DGTAuthenticationConfiguration : INSCopying
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

	// @protocol DGTCompletionViewController <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface DGTCompletionViewController
	{
		// @required -(void)digitsAuthenticationFinishedWithSession:(DGTSession *)session error:(NSError *)error;
		[Abstract]
		[Export("digitsAuthenticationFinishedWithSession:error:")]
		void Error(DGTSession session, NSError error);
	}

	// @interface DGTContactsDebugConfiguration : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface DGTContactsDebugConfiguration : INSCopying
	{
		// -(instancetype _Nonnull)initSuccessStateWithContacts:(NSArray<DGTUser *> * _Nonnull)contacts;
		[Export("initSuccessStateWithContacts:")]
		IntPtr Constructor(DGTUser[] contacts);

		// -(instancetype _Nonnull)initErrorStateWithDigitsError:(DGTErrorCode)error;
		[Export("initErrorStateWithDigitsError:")]
		IntPtr Constructor(DGTErrorCode error);

		// +(NSArray<DGTUser *> * _Nonnull)stubbedContactsWithDigitsUserIDs:(NSArray<NSString *> * _Nonnull)digitsUserIDs;
		[Static]
		[Export("stubbedContactsWithDigitsUserIDs:")]
		DGTUser[] StubbedContactsWithDigitsUserIDs(string[] digitsUserIDs);
	}

	// typedef void (^DGTInAppInviteUserAction)(NSString * _Nonnull, NSString * _Nonnull, DGTInAppButtonState);
	delegate void DGTInAppInviteUserAction(string arg0, string arg1, DGTInAppButtonState arg2);

	// typedef NSString * _Nonnull (^DGTSMSTextBlock)(DGTAddressBookContact * _Nonnull, NSString * _Nullable);
	delegate string DGTSMSTextBlock(DGTAddressBookContact arg0, [NullAllowed] string arg1);

	// @interface DGTInviteFlowConfiguration : NSObject
	[BaseType(typeof(NSObject))]
	interface DGTInviteFlowConfiguration
	{
		// @property (readonly, copy, nonatomic) DGTSMSTextBlock _Nonnull smsPrefillText;
		[Export("smsPrefillText", ArgumentSemantic.Copy)]
		DGTSMSTextBlock SmsPrefillText { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appDisplayName;
		[Export("appDisplayName")]
		string AppDisplayName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull inviteViewTitle;
		[Export("inviteViewTitle")]
		string InviteViewTitle { get; }

		// @property (readonly, copy, nonatomic) DGTBranchConfiguration * _Nonnull branchConfig;
		[Export("branchConfig", ArgumentSemantic.Copy)]
		DGTBranchConfiguration BranchConfig { get; }

		// -(instancetype _Nonnull)initWithPrefillTextBlock:(DGTSMSTextBlock _Nullable)prefillTextBlock;
		[Export("initWithPrefillTextBlock:")]
		IntPtr Constructor([NullAllowed] DGTSMSTextBlock prefillTextBlock);

		// -(instancetype _Nonnull)initWithAppDisplayName:(NSString * _Nullable)appDisplayName withViewTitleText:(NSString * _Nullable)viewTitle withPrefillTextBlock:(DGTSMSTextBlock _Nullable)prefillTextBlock;
		[Export("initWithAppDisplayName:withViewTitleText:withPrefillTextBlock:")]
		IntPtr Constructor([NullAllowed] string appDisplayName, [NullAllowed] string viewTitle, [NullAllowed] DGTSMSTextBlock prefillTextBlock);

		// -(instancetype _Nonnull)initWithAppDisplayName:(NSString * _Nullable)appDisplayName withViewTitleText:(NSString * _Nullable)viewTitle withBranchIntegrationConfiguration:(DGTBranchConfiguration * _Nullable)branchConfig withPrefillTextBlock:(DGTSMSTextBlock _Nullable)prefillTextBlock;
		[Export("initWithAppDisplayName:withViewTitleText:withBranchIntegrationConfiguration:withPrefillTextBlock:")]
		IntPtr Constructor([NullAllowed] string appDisplayName, [NullAllowed] string viewTitle, [NullAllowed] DGTBranchConfiguration branchConfig, [NullAllowed] DGTSMSTextBlock prefillTextBlock);
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
		// @property (nonatomic, strong) DGTContactsDebugConfiguration * uploadDebugOverrides;
		[Export("uploadDebugOverrides", ArgumentSemantic.Strong)]
		DGTContactsDebugConfiguration UploadDebugOverrides { get; set; }

		// @property (nonatomic, strong) DGTContactsDebugConfiguration * lookupDebugOverrides;
		[Export("lookupDebugOverrides", ArgumentSemantic.Strong)]
		DGTContactsDebugConfiguration LookupDebugOverrides { get; set; }

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

	// @interface DGTBranchConfiguration : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface DGTBranchConfiguration : INSCopying
	{
		// @property (nonatomic, strong) NSString * title;
		[Export("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (nonatomic, strong) NSString * contentDescription;
		[Export("contentDescription", ArgumentSemantic.Strong)]
		string ContentDescription { get; set; }

		// @property (nonatomic, strong) NSString * feature;
		[Export("feature", ArgumentSemantic.Strong)]
		string Feature { get; set; }

		// -(instancetype)initWithFeature:(NSString *)feature;
		[Export("initWithFeature:")]
		IntPtr Constructor(string feature);
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

	// @interface DGTDebugConfiguration : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface DGTDebugConfiguration : INSCopying
	{
		// -(instancetype)initSuccessStateWithDigitsSession:(DGTSession *)session;
		[Export("initSuccessStateWithDigitsSession:")]
		IntPtr Constructor(DGTSession session);

		// -(instancetype)initErrorStateWithDigitsError:(DGTErrorCode)error;
		[Export("initErrorStateWithDigitsError:")]
		IntPtr Constructor(DGTErrorCode error);

		// +(DGTSession *)defaultDebugSession;
		[Static]
		[Export("defaultDebugSession")]
		DGTSession DefaultDebugSession { get; }
	}

	// @interface DGTUser : NSObject
	[BaseType(typeof(NSObject))]
	interface DGTUser
	{
		// @property (readonly, copy, nonatomic) NSString * userID;
		[Export("userID")]
		string UserID { get; }
	}

	// @interface DGTAppearance : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface DGTAppearance : INSCopying
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

		// @property (nonatomic, strong) UIFont * secondaryLabelFont;
		[Export("secondaryLabelFont", ArgumentSemantic.Strong)]
		UIFont SecondaryLabelFont { get; set; }

		// @property (nonatomic, strong) UIImage * logoImage;
		[Export("logoImage", ArgumentSemantic.Strong)]
		UIImage LogoImage { get; set; }

		// -(void)applyUIAppearanceColors;
		[Export("applyUIAppearanceColors")]
		void ApplyUIAppearanceColors();
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

	// @protocol DGTSessionUpdateDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface DGTSessionUpdateDelegate
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

	// @interface Digits : NSObject
	[BaseType(typeof(NSObject))]
	interface Digits
	{
		// +(Digits * _Nonnull)sharedInstance;
		[Static]
		[Export("sharedInstance")]
		Digits SharedInstance { get; }

		// +(BOOL)isLoggedIn;
		[Static]
		[Export("isLoggedIn")]
		bool IsLoggedIn { get; }

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
		DGTSessionUpdateDelegate SessionUpdateDelegate { get; set; }

		// @property (nonatomic, weak) id<DGTSessionUpdateDelegate> _Nullable sessionUpdateDelegate;
		[NullAllowed, Export("sessionUpdateDelegate", ArgumentSemantic.Weak)]
		NSObject WeakSessionUpdateDelegate { get; set; }

		[Wrap("WeakAuthEventDelegate")]
		[NullAllowed]
		DGTAuthEventDelegate AuthEventDelegate { get; set; }

		// @property (nonatomic, weak) id<DGTAuthEventDelegate> _Nullable authEventDelegate;
		[NullAllowed, Export("authEventDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAuthEventDelegate { get; set; }

		[Wrap("WeakContactsEventDelegate")]
		[NullAllowed]
		DGTContactsEventDelegate ContactsEventDelegate { get; set; }

		// @property (nonatomic, weak) id<DGTContactsEventDelegate> _Nullable contactsEventDelegate;
		[NullAllowed, Export("contactsEventDelegate", ArgumentSemantic.Weak)]
		NSObject WeakContactsEventDelegate { get; set; }

		[Wrap("WeakAttributionEventDelegate")]
		[NullAllowed]
		DGTAttributionEventDelegate AttributionEventDelegate { get; set; }

		// @property (nonatomic, weak) id<DGTAttributionEventDelegate> _Nullable attributionEventDelegate;
		[NullAllowed, Export("attributionEventDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAttributionEventDelegate { get; set; }

		// @property (nonatomic, strong) DGTDebugConfiguration * _Nullable debugOverrides;
		[NullAllowed, Export("debugOverrides", ArgumentSemantic.Strong)]
		DGTDebugConfiguration DebugOverrides { get; set; }

		// -(void)authenticateWithCompletion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
		[Export("authenticateWithCompletion:")]
		void AuthenticateWithCompletion(DGTAuthenticationCompletion completion);

		// -(void)authenticateWithViewController:(UIViewController * _Nullable)viewController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completion:(DGTAuthenticationCompletion _Nonnull)completion __attribute__((availability(tvos, unavailable)));
		[Export("authenticateWithViewController:configuration:completion:")]
		void AuthenticateWithViewController([NullAllowed] UIViewController viewController, DGTAuthenticationConfiguration configuration, DGTAuthenticationCompletion completion);

		// -(void)authenticateWithNavigationViewController:(UINavigationController * _Nonnull)navigationController configuration:(DGTAuthenticationConfiguration * _Nonnull)configuration completionViewController:(id<DGTCompletionViewController> _Nonnull)completionViewController __attribute__((availability(tvos, unavailable)));
		[Export("authenticateWithNavigationViewController:configuration:completionViewController:")]
		void AuthenticateWithNavigationViewController(UINavigationController navigationController, DGTAuthenticationConfiguration configuration, DGTCompletionViewController completionViewController);

		// -(void)logOut;
		[Export("logOut")]
		void LogOut();

		// -(DGTContactsFetcher * _Nonnull)createContactsFetcher __attribute__((availability(tvos, unavailable)));
		[Export("createContactsFetcher")]
		DGTContactsFetcher CreateContactsFetcher { get; }
	}

	// @interface DGTBranch : NSObject
	[BaseType(typeof(NSObject))]
	interface DGTBranch
	{
		// +(void)initSessionWithDigits:(Digits * _Nonnull)digits withBranch:(Branch * _Nonnull)branch withLaunchOptions:(NSDictionary * _Nullable)options andRegisterDeepLinkHandler:(void (^ _Nullable)(NSDictionary * _Nonnull, NSError * _Nullable))callback;
		[Static]
		[Export("initSessionWithDigits:withBranch:withLaunchOptions:andRegisterDeepLinkHandler:")]
		void InitSessionWithDigits(Digits digits, NSObject branch, [NullAllowed] NSDictionary options, [NullAllowed] Action<NSDictionary, NSError> callback);
	}

	// typedef void (^DGTInvitationFlowCompletion)(NSError *);
	delegate void DGTInvitationFlowCompletion(NSError arg0);

	// @protocol DGTContactsPickerActionEventDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface DGTContactsPickerActionEventDelegate
	{
		// @optional -(void)inviteSMSSentToContact:(NSString *)contactName withPhoneNumber:(NSString *)phoneNumber;
		[Export("inviteSMSSentToContact:withPhoneNumber:")]
		void WithPhoneNumber(string contactName, string phoneNumber);
	}

	// @interface DGTInvites : NSObject
	[BaseType(typeof(NSObject))]
	interface DGTInvites
	{
		// -(void)startInvitationFlowWithPresenterViewController:(UIViewController *)presenterViewController withConfiguration:(DGTInviteFlowConfiguration *)configuration withUserActionNotifyDelegate:(id<DGTContactsPickerActionEventDelegate>)userActionNotifyDelegate withFlowCompletion:(DGTInvitationFlowCompletion)flowCompletion;
		[Export("startInvitationFlowWithPresenterViewController:withConfiguration:withUserActionNotifyDelegate:withFlowCompletion:")]
		void StartInvitationFlowWithPresenterViewController(UIViewController presenterViewController, DGTInviteFlowConfiguration configuration, DGTContactsPickerActionEventDelegate userActionNotifyDelegate, DGTInvitationFlowCompletion flowCompletion);
	}

}