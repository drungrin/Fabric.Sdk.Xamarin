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
        private static readonly Regex StackTraceRegex = new Regex(@"\s*at\s*(\S+)\.(\S+\(?.*\)?)\s\[0x[\d\w]+\]\sin\s.+[\\/>](.*):(\d+)?");

        private static readonly Lazy<Crashlytics> LazyInstance = new Lazy<Crashlytics>(() => new Crashlytics());

        private Crashlytics() : base(new Bindings.CrashlyticsKit.Crashlytics())
        {
            AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) => UncaughtException(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => UncaughtException(args.ExceptionObject);
            TaskScheduler.UnobservedTaskException += (sender, args) => UncaughtException(args.Exception);
        }

        public static ICrashlytics Instance => LazyInstance.Value;

        public string Version => Bindings.CrashlyticsKit.Crashlytics.Instance.Version;

        public void Crash()
        {
            Bindings.CrashlyticsKit.Crashlytics.Instance.Crash();
        }

        public void RecordException(Exception exception)
        {
            Bindings.CrashlyticsKit.Crashlytics.LogException(ToThrowable(exception));
        }

        public ICrashlytics SetStringValue(string key, string value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetString(key, value);
            return this;
        }

        public ICrashlytics SetBoolValue(string key, bool value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetBool(key, value);
            return this;
        }

        public ICrashlytics SetFloatValue(string key, float value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetFloat(key, value);
            return this;
        }

        public ICrashlytics SetDoubleValue(string key, double value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetDouble(key, value);
            return this;
        }

        public ICrashlytics SetIntValue(string key, int value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetInt(key, value);
            return this;
        }

        public ICrashlytics SetLongValue(string key, long value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetLong(key, value);
            return this;
        }

        public ICrashlytics SetObjectValue(string key, object value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetString(key, value?.ToString());
            return this;
        }

        public ICrashlytics SetUserEmail(string email)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetUserEmail(email);
            return this;
        }

        public ICrashlytics SetUserIdentifier(string identifier)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetUserIdentifier(identifier);
            return this;
        }

        public ICrashlytics SetUserName(string name)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetUserName(name);
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
                    if (string.IsNullOrEmpty(file))
                        file = "filename unknown";

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

            Bindings.CrashlyticsKit.Crashlytics.SetString("unhandled exception stack trace", exception.StackTrace);
            Bindings.CrashlyticsKit.Crashlytics.SetString("unhandled exception message", exception.Message);
            Bindings.CrashlyticsKit.Crashlytics.SetString("unhandled exception", exception.GetType().FullName);

            var handler = Thread.DefaultUncaughtExceptionHandler;
            handler.UncaughtException(Thread.CurrentThread(), ToThrowable(exception));                
        }
    }
}