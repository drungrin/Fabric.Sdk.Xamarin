using System;
using FabricSdk;

namespace DigitsKit
{
    public interface IDigits : IKit
    {
        IDigitsSession Session { get; }
        void Authenticate(Action<IDigitsSession, ErrorCode> completionAction, bool isEmailRequired = false);    
    }

    public enum ErrorCode
    {
        UnspecifiedError,
        UserCanceledAuthentication,
        UnableToAuthenticateNumber,
        UnableToConfirmNumber,
        UnableToAuthenticatePin,
        UserCanceledFindContacts,
        UserDeniedAddressBookAccess,
        FailedToReadAddressBook,
        UnableToUploadContacts,
        UnableToDeleteContacts,
        UnableToLookupContactMatches,
        UnableToCreateEmailAddress,
        UnableToUploadContactsRateLimit,
        UnableToUploadContactsInternalServer0,
        UnableToUploadContactsInternalServer131,
        UnableToUploadContactsServerUnavailable,
        UnableToUploadContactsEntityTooLarge,
        UnableToUploadContactsBadAuthentication,
        UnableToUploadContactsOutOfBoundsTimestamp,
        UnableToUploadContactsGenericBadRequest            
    }
}