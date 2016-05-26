using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Android.Runtime;
using FabricSdk;
using Java.Lang;
using Exception = System.Exception;

namespace CrashlyticsKit
{
    public class Crashlytics : Kit, ICrashlytics
    {
        private static readonly Regex StackTraceRegex = new Regex(@"\s*at\s*(\S+)\.(\S+\(?.*\)?)\s\[0x[\d\w]+\]\sin\s\S+[\\/](\S+):(\d+)?");

        private static readonly Lazy<Crashlytics> LazyInstance = new Lazy<Crashlytics>(() => new Crashlytics());

        private Crashlytics() : base(new Platform.Crashlytics())
        {
            AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) => UncaughtException(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => UncaughtException(args.ExceptionObject);
            TaskScheduler.UnobservedTaskException += (sender, args) => UncaughtException(args.Exception);
        }

        public static ICrashlytics Instance => LazyInstance.Value;

        public string Version => Platform.Crashlytics.Instance.Version;

        public void Crash()
        {
            Platform.Crashlytics.Instance.Crash();
        }

        public void RecordException(Exception exception)
        {
            Platform.Crashlytics.LogException(ToThrowable(exception));
        }

        public ICrashlytics SetStringValue(string key, string value)
        {
            Platform.Crashlytics.SetString(key, value);
            return this;
        }

        public ICrashlytics SetBoolValue(string key, bool value)
        {
            Platform.Crashlytics.SetBool(key, value);
            return this;
        }

        public ICrashlytics SetFloatValue(string key, float value)
        {
            Platform.Crashlytics.SetFloat(key, value);
            return this;
        }

        public ICrashlytics SetDoubleValue(string key, double value)
        {
            Platform.Crashlytics.SetDouble(key, value);
            return this;
        }

        public ICrashlytics SetIntValue(string key, int value)
        {
            Platform.Crashlytics.SetInt(key, value);
            return this;
        }

        public ICrashlytics SetLongValue(string key, long value)
        {
            Platform.Crashlytics.SetLong(key, value);
            return this;
        }

        public ICrashlytics SetObjectValue(string key, object value)
        {
            Platform.Crashlytics.SetString(key, value?.ToString());
            return this;
        }

        public ICrashlytics SetUserEmail(string email)
        {
            Platform.Crashlytics.SetUserEmail(email);
            return this;
        }

        public ICrashlytics SetUserIdentifier(string identifier)
        {
            Platform.Crashlytics.SetUserIdentifier(identifier);
            return this;
        }

        public ICrashlytics SetUserName(string name)
        {
            Platform.Crashlytics.SetUserName(name);
            return this;
        }

        private static Throwable ToThrowable(Exception exception)
        {
            while (exception is AggregateException)
                exception = exception.InnerException;

            var throwable = exception as Throwable;

            if (throwable != null)
            {
                throwable.Data.Add("Crashlytics", true);
                return throwable;
            }

            throwable = new Throwable(exception.Message);
            throwable.Data.Add("Crashlytics", true);

            var stackTrace = new List<StackTraceElement>();
            foreach (Match match in StackTraceRegex.Matches(exception.StackTrace))
            {
                var cls = match.Groups[1].Value;
                var method = match.Groups[2].Value;
                var file = match.Groups[3].Value;
                var line = Convert.ToInt32(match.Groups[4].Value);
                if (!cls.StartsWith("System.Runtime.ExceptionServices") &&
                    !cls.StartsWith("System.Runtime.CompilerServices"))
                {
                    stackTrace.Add(new StackTraceElement(cls, method, file, line));
                }
            }
            throwable.SetStackTrace(stackTrace.ToArray());

            if (exception.InnerException != null)
            {
                throwable.InitCause(ToThrowable(exception.InnerException));
            }

            return throwable;
        }

        private static void UncaughtException(object exeptionObject)
        {
            var exception = exeptionObject as Exception;
            if (exception == null)
                return;
            if (exception.Data.Contains("Crashlytics"))
                return;

            Platform.Crashlytics.SetString(exception.StackTrace, "unhandled exception stack trace");
            Platform.Crashlytics.SetString(exception.Message, "unhandled exception message");
            Platform.Crashlytics.SetString(exception.GetType().FullName, "unhandled exception");

            var handler = Thread.DefaultUncaughtExceptionHandler;
            handler.UncaughtException(Thread.CurrentThread(), ToThrowable(exception));                
        }
    }
}