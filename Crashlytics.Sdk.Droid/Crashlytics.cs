using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Android.App;
using Android.Runtime;
using Java.Lang;
using Exception = System.Exception;
using NativeCrashlytics = CrashlyticsSdk.Bindings.Crashlytics;
using System.Threading.Tasks;

namespace CrashlyticsSdk.Droid
{
    public class Crashlytics : ICrashlytics
    {
        private static readonly Regex StackTraceRegex = new Regex(@"\s*at\s*(\S+)\.(\S+\(?.*\)?)\s\[0x[\d\w]+\]\sin\s\S+[\\/](\S+):(\d+)");

        public Crashlytics()
        {
            FabricSdk.Bindings.Fabric.With(Application.Context, new NativeCrashlytics());

            AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) => UncaughtException(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => UncaughtException(args.ExceptionObject);
            TaskScheduler.UnobservedTaskException += (sender, args) => UncaughtException(args.Exception);
        }

        public void Crash()
        {
            NativeCrashlytics.Instance.Crash();
        }

        public void Log(string msg)
        {
            NativeCrashlytics.Log(msg);
        }

        public void Log(int priority, string tag, string msg)
        {
            NativeCrashlytics.Log(priority, tag, msg);
        }

        public void LogException(Exception exception)
        {
            NativeCrashlytics.LogException(ToThrowable(exception));
        }

        public void SetBool(string key, bool value)
        {
            NativeCrashlytics.SetBool(key, value);
        }

        public void SetDouble(string key, double value)
        {
            NativeCrashlytics.SetDouble(key, value);
        }

        public void SetFloat(string key, float value)
        {
            NativeCrashlytics.SetFloat(key, value);
        }

        public void SetInt(string key, int value)
        {
            NativeCrashlytics.SetInt(key, value);
        }

        public void SetLong(string key, long value)
        {
            NativeCrashlytics.SetLong(key, value);
        }

        public void SetString(string key, string value)
        {
            NativeCrashlytics.SetString(key, value);
        }

        public void SetUserEmail(string email)
        {
            NativeCrashlytics.SetUserEmail(email);
        }

        public void SetUserIdentifier(string identifier)
        {
            NativeCrashlytics.SetUserIdentifier(identifier);
        }

        public void SetUserName(string name)
        {
            NativeCrashlytics.SetUserName(name);
        }

        private void UncaughtException(object exeptionObject)
        {
            var exception = exeptionObject as Exception;
            if (exception == null)
                return;
            if (exception.Data.Contains("Crashlytics"))
                return;
            var handler = Thread.DefaultUncaughtExceptionHandler;
            try
            {
                handler.UncaughtException(Thread.CurrentThread(), ToThrowable(exception));
            }
            catch (Exception ignored)
            {
                ignored.GetType(); 
            }
        }

        private static Throwable ToThrowable(Exception exception)
        {
            while (exception is AggregateException)
                exception = exception.InnerException;

            var throwable = new Throwable(exception.Message);
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
    }
}