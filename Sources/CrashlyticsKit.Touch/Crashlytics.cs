using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bindings.CrashlyticsKit;
using FabricSdk;
using Foundation;
using ObjCRuntime;

namespace CrashlyticsKit
{
    public sealed class Crashlytics : Kit, ICrashlytics
    {
        private static readonly Regex StackTraceRegex = new Regex(@"\s*at\s*(\S+)\.(\S+\(?.*\)?)\s\[0x[\d\w]+\]\sin\s.+[\\/>](.*):(\d+)?");

        private static readonly Lazy<Crashlytics> LazyInstance = new Lazy<Crashlytics>(() => new Crashlytics());

        private Crashlytics() : base(Bindings.CrashlyticsKit.Crashlytics.SharedInstance)
        {            
        }

        public static ICrashlytics Instance => LazyInstance.Value;

        public string Version => Bindings.CrashlyticsKit.Crashlytics.SharedInstance.Version;       

        public void Crash()
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.Crash();
        }

        public ICrashlytics SetUserIdentifier(string identifier)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetUserIdentifier(identifier);
            return this;
        }

        public ICrashlytics SetUserName(string name)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetUserName(name);
            return this;
        }

        public ICrashlytics SetUserEmail(string email)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetUserEmail(email);
            return this;
        }

        public ICrashlytics SetObjectValue(string key, object value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(NSObject.FromObject(value), key);
            return this;
        }

        public ICrashlytics SetStringValue(string key, string value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(NSObject.FromObject(value), key);
            return this;
        }

        public ICrashlytics SetIntValue(string key, int value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetIntValue(value, key);
            return this;
        }

        public ICrashlytics SetBoolValue(string key, bool value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetBoolValue(value, key);
            return this;
        }

        public ICrashlytics SetFloatValue(string key, float value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetFloatValue(value, key);
            return this;
        }

        public ICrashlytics SetDoubleValue(string key, double value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(NSNumber.FromDouble(value), key);
            return this;
        }

        public ICrashlytics SetLongValue(string key, long value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(NSNumber.FromInt64(value), key);
            return this;
        }

		public ICrashlytics Log(string msg)
		{
			CLSLog(msg);
			return this;
		}

        public void RecordException(Exception exception)
        {
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.StackTrace ?? string.Empty), "exception stack trace");
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.Message), "exception message");
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.GetType().FullName), "exception");

            var stackFrames = new List<CLSStackFrame>();

            if (exception.StackTrace != null)
            {
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

                        stackFrames.Add(new CLSStackFrame
                        {
                            FileName = file,
                            LineNumber = (uint)line,
                            Symbol = cls + "." + method,
                        });
                    }
                }
            }

            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.RecordCustomExceptionName(exception.GetType().Name, exception.Message, stackFrames.ToArray());
        }

		// extern void CLSLog (NSString * format, ...);
		[DllImport("__Internal", EntryPoint = "CLSLog")]
		//[Verify (PlatformInvoke)]
		internal static extern void __CLSLog(IntPtr format, string arg0);

		// extern void CLSLog (NSString * format, ...);
		[DllImport("__Internal", EntryPoint = "CLSLog")]
		//[Verify (PlatformInvoke)]
		internal static extern void __CLSLog_arm64(IntPtr format, IntPtr dummy1, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, string arg0);

		// extern void CLSLogv (NSString * format, va_list ap);
		[DllImport("__Internal")]
		//[Verify (PlatformInvoke)]
		internal static extern unsafe void CLSLogv(IntPtr format, sbyte* ap);

		// extern void CLSNSLog (NSString * format, ...);
		[DllImport("__Internal", EntryPoint = "CLSNSLog")]
		//[Verify (PlatformInvoke)]
		internal static extern void __CLSNSLog(IntPtr format, string arg0);

		// extern void CLSNSLog (NSString * format, ...);
		[DllImport("__Internal", EntryPoint = "CLSNSLog")]
		//[Verify (PlatformInvoke)]
		internal static extern void __CLSNSLog_arm64(IntPtr format, IntPtr dummy1, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, string arg0);

		// extern void CLSNSLogv (NSString * format, va_list ap);
		[DllImport("__Internal")]
		//[Verify (PlatformInvoke)]
		internal static extern unsafe void CLSNSLogv(IntPtr format, sbyte* ap);

		public void CLSLog(string format, params object[] arg)
		{
			using (var nsFormat = new NSString(string.Format(format, arg)))
				if (Runtime.Arch == Arch.DEVICE && IntPtr.Size == 8)
					__CLSLog_arm64(nsFormat.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "");
				else
					__CLSLog(nsFormat.Handle, "");
		}

		public void CLSNSLog(string format, params object[] arg)
		{
			using (var nsFormat = new NSString(string.Format(format, arg)))
				if (Runtime.Arch == Arch.DEVICE && IntPtr.Size == 8)
					__CLSNSLog_arm64(nsFormat.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "");
				else
					__CLSNSLog(nsFormat.Handle, "");
		}
	}

    public static class Initializer
    {
        private static readonly object InitializeLock = new object();
        private static bool _initialized;

        public static void RecordManagedException(object exceptionObject)
        {
            var exception = exceptionObject as Exception;
            if (exception == null)
                return;
            
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.StackTrace ?? string.Empty), "managed exception stack trace");
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.Message), "managed exception message");
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.GetType().FullName), "managed exception");
        }

        public static void Initialize(this ICrashlytics crashlytics)
        {
            if (_initialized) return;
            lock (InitializeLock)
            {
                if (_initialized) return;

                Fabric.Instance.Kits.Add(crashlytics);
                Fabric.Instance.AfterInitialize += Fabric_AfterInitialize;
                _initialized = true;
            }
        }

        static void Fabric_AfterInitialize(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += (s, a) => RecordManagedException(a.ExceptionObject);
            TaskScheduler.UnobservedTaskException += (s, a) => RecordManagedException(a.Exception);
        }
    }
}