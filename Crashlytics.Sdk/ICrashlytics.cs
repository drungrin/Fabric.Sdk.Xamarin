using System;

namespace CrashlyticsSdk
{
    public interface ICrashlytics
    {
        void LogException(Exception exception);

        void Log(string msg);

        void Log(int priority, string tag, string msg);

        void SetUserIdentifier(string identifier);

        void SetUserName(string name);

        void SetUserEmail(string email);

        void SetString(string key, string value);

        void SetBool(string key, bool value);

        void SetDouble(string key, double value);

        void SetFloat(string key, float value);

        void SetInt(string key, int value);

        void SetLong(string key, long value);

        void Crash();
    }
}