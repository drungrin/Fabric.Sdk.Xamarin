using ObjCRuntime;

namespace Bindings.DigitsKit
{
    [Native]
    public enum DGTErrorCode : int
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
        UnableToUploadContactsGenericBadRequest = 19
    }

    [Native]
    public enum DGTAccountFields : ulong
    {
        None = 1,
        Email = 2,
        DefaultOptionMask = None
    }

    [Native]
    public enum DGTContactAccessAuthorizationStatus : ulong
    {
        Pending = 0,
        Denied = 1,
        Accepted = 2
    }
}