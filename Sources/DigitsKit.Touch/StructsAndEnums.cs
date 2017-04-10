using ObjCRuntime;

namespace Bindings.DigitsKit
{  
	[Native]
	public enum DGTErrorCode : long
	{
		UnspecifiedError = 0,
		UserCanceledAuthentication = 1,
		UnableToAuthenticateNumber = 2,
		UnableToConfirmNumber = 3,
		UnableToAuthenticatePin = 4,
		UserCanceledFindContacts = 5,
		UserDeniedAddressBookAccess = 6,
		FailedToReadAddressBook = 7,
		UnableToUploadContacts = 8,
		UnableToDeleteContacts = 9,
		UnableToLookupContactMatches = 10,
		UnableToCreateEmailAddress = 11,
		UnableToUploadContactsRateLimit = 12,
		UnableToUploadContactsInternalServer0 = 13,
		UnableToUploadContactsInternalServer131 = 14,
		UnableToUploadContactsServerUnavailable = 15,
		UnableToUploadContactsEntityTooLarge = 16,
		UnableToUploadContactsBadAuthentication = 17,
		UnableToUploadContactsOutOfBoundsTimestamp = 18,
		UnableToUploadContactsGenericBadRequest = 19,
		UnableToRetrieveValidInvitationData = 20,
		UnableToDetectBranchSDK = 21,
		InvalidParameter = 22
	}

	[Native]
	public enum DGTInviteState : long
	{
		Converted = 0,
		Pending = 1
	}

	[Native]
	public enum DGTAccountFields : long
	{
		None = 1 << 0,
		Email = 1 << 1,
		DefaultOptionMask = None
	}

	[Native]
	public enum DGTContactAccessAuthorizationStatus : long
	{
		Pending = 0,
		Denied = 1,
		Accepted = 2
	}

	[Native]
	public enum DGTInAppButtonState : long
	{
		Normal = 0,
		Active = 1
	}
}