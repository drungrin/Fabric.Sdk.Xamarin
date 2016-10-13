using System;

namespace CrashlyticsKit
{
    public sealed class Crashlytics : ICrashlytics
    {
        private static readonly Lazy<Crashlytics> LazyInstance = new Lazy<Crashlytics>(() => new Crashlytics());

        private Crashlytics()
        {
        }

        public static ICrashlytics Instance => LazyInstance.Value;

        public string Version
        {
            get { throw new CrashlyticsPlatformNotSupportedException(); }
        }

        public void Crash()
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetUserIdentifier(string identifier)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetUserName(string name)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetUserEmail(string email)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetObjectValue(string key, object value)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetStringValue(string key, string value)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetIntValue(string key, int value)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetBoolValue(string key, bool value)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetFloatValue(string key, float value)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetDoubleValue(string key, double value)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

        public ICrashlytics SetLongValue(string key, long value)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }

		public ICrashlytics Log(string msg)
		{
			throw new CrashlyticsPlatformNotSupportedException();
		}

        public void RecordException(Exception exception)
        {
            throw new CrashlyticsPlatformNotSupportedException();
        }
    }

    internal sealed class CrashlyticsPlatformNotSupportedException : PlatformNotSupportedException
    {
        public CrashlyticsPlatformNotSupportedException() : base("The PCL build of Crashlytics is being linked which probably means you need to use NuGet or otherwise link a platform-specific Crashlytics.Platform.dll to your main application.")
        {
        }
    }
}