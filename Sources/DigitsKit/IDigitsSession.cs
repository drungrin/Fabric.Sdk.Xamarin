using System;

namespace DigitsKit
{
    public interface IDigitsSession
    {
        string EmailAddress { get; }
        bool EmailAddressIsVerified { get; }
        string PhoneNumber { get; }
        string UserId { get; }
        string AuthTokenSecret { get; }
        string AuthToken { get; }
    }
}