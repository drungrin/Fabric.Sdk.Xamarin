using System;
using FabricSdk;

namespace DigitsKit
{
    public class Digits : Kit, IDigits
    {
        private static readonly Lazy<Digits> LazyInstance = new Lazy<Digits>(() => new Digits());

        public static IDigits Instance => LazyInstance.Value;

        private Digits()
        {
        }

        public IDigitsSession Session
        {
            get { throw new DigitsPlatformNotSupportedException(); }
        }

        public void Authenticate(Action<IDigitsSession, ErrorCode> completionAction, bool isEmailRequired = false)
        {
            throw new DigitsPlatformNotSupportedException();
        }

        public void StartWithConsumerKey(string consumerKey, string consumerSecret)
        {
            throw new DigitsPlatformNotSupportedException();
        }

        public void Initialize()
        {
            throw new DigitsPlatformNotSupportedException();
        }
    }

    internal sealed class DigitsPlatformNotSupportedException : PlatformNotSupportedException
    {
        public DigitsPlatformNotSupportedException() : base("The PCL build of Digits is being linked which probably means you need to use NuGet or otherwise link a platform-specific Digits.Platform.dll to your main application.")
        {
        }
    }
}