using System;
using Bindings.DigitsKit;
using FabricSdk;
using Foundation;

namespace DigitsKit
{
    public class Digits : Kit, IDigits
    {
        private static readonly Lazy<Digits> LazyInstance = new Lazy<Digits>(() => new Digits());

        public static IDigits Instance => LazyInstance.Value;

        private Digits() : base(new Bindings.DigitsKit.Digits())
        {
        }

        public IDigitsSession Session => new InternalDigitsSession(Bindings.DigitsKit.Digits.SharedInstance.Session);

        public void Authenticate(Action<IDigitsSession, ErrorCode> completionAction, bool isEmailRequired = false)
        {
            
            var configuration = new DGTAuthenticationConfiguration(isEmailRequired ? DGTAccountFields.Email : DGTAccountFields.None);
            Bindings.DigitsKit.Digits.SharedInstance.AuthenticateWithNavigationViewController(null, configuration, new InternalCompletionViewController());
        }

        public void StartWithConsumerKey(string consumerKey, string consumerSecret)
        {
            Bindings.DigitsKit.Digits.SharedInstance.StartWithConsumerKey(consumerKey, consumerSecret);
        }

        public void Initialize()
        {
        }
    }

    internal class InternalDigitsSession : IDigitsSession
    {
        public InternalDigitsSession()
        {
        }

        public InternalDigitsSession(DGTSession session)
        {
            EmailAddress = session.EmailAddress;
            EmailAddressIsVerified = session.EmailAddressIsVerified;
            PhoneNumber = session.PhoneNumber;
            AuthTokenSecret = session.AuthTokenSecret;
            AuthToken = session.AuthToken;
            UserId = session.UserID;
        }

        public string EmailAddress { get; internal set; }
        public bool EmailAddressIsVerified { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string UserId { get; internal set; }
        public string AuthTokenSecret { get; internal set; }
        public string AuthToken { get; internal set; }
    }

    internal class InternalCompletionViewController : IDGTCompletionViewController
    {
        public event Action<IDigitsSession, ErrorCode> OnCompletion;

        public override void Error(DGTSession session, NSError error)
        {
            ErrorCode errorCode;
            switch (error.Code)
            {
                case 1:
                    errorCode = ErrorCode.UserCanceledAuthentication;
                    break;
                case 2:
                    errorCode = ErrorCode.UnableToAuthenticateNumber;
                    break;
                case 3:
                    errorCode = ErrorCode.UnableToConfirmNumber;
                    break;
                case 4:
                    errorCode = ErrorCode.UnableToAuthenticatePin;
                    break;
                case 5:
                    errorCode = ErrorCode.UserCanceledFindContacts;
                    break;
                case 6:
                    errorCode = ErrorCode.UserDeniedAddressBookAccess;
                    break;
                case 7:
                    errorCode = ErrorCode.FailedToReadAddressBook;
                    break;
                case 8:
                    errorCode = ErrorCode.UnableToUploadContacts;
                    break;
                case 9:
                    errorCode = ErrorCode.UnableToDeleteContacts;
                    break;
                case 10:
                    errorCode = ErrorCode.UnableToLookupContactMatches;
                    break;
                case 11:
                    errorCode = ErrorCode.UnableToCreateEmailAddress;
                    break;
                case 12:
                    errorCode = ErrorCode.UnableToUploadContactsRateLimit;
                    break;
                case 13:
                    errorCode = ErrorCode.UnableToUploadContactsInternalServer0;
                    break;
                case 14:
                    errorCode = ErrorCode.UnableToUploadContactsInternalServer131;
                    break;
                case 15:
                    errorCode = ErrorCode.UnableToUploadContactsServerUnavailable;
                    break;
                case 16:
                    errorCode = ErrorCode.UnableToUploadContactsEntityTooLarge;
                    break;
                case 17:
                    errorCode = ErrorCode.UnableToUploadContactsBadAuthentication;
                    break;
                case 18:
                    errorCode = ErrorCode.UnableToUploadContactsOutOfBoundsTimestamp;
                    break;
                case 19:
                    errorCode = ErrorCode.UnableToUploadContactsGenericBadRequest;
                    break;
                default:
                    errorCode = ErrorCode.UnspecifiedError;
                    break;
            }
            
            OnCompletion?.Invoke(session == null ? null : new InternalDigitsSession(session), errorCode);
        }
    }
}