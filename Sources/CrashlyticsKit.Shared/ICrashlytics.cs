using System;
using FabricSdk;

namespace CrashlyticsKit
{
    public interface ICrashlytics : IKit
    {
        string Version { get; }

        void Crash();

        ICrashlytics SetUserIdentifier(string identifier);

        ICrashlytics SetUserName(string name);

        ICrashlytics SetUserEmail(string email);

        ICrashlytics SetObjectValue(string key, object value);

        ICrashlytics SetStringValue(string key, string value);

        ICrashlytics SetIntValue(string key, int value);

        ICrashlytics SetBoolValue(string key, bool value);

        ICrashlytics SetFloatValue(string key, float value);

        ICrashlytics SetDoubleValue(string key, double value);

        ICrashlytics SetLongValue(string key, long value);

		ICrashlytics Log(string msg);

        void RecordException(Exception exception);
    }
}