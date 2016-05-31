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
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => UncaughtException(args.ExceptionObject);
            
            TaskScheduler.UnobservedTaskException += (sender, args) => UncaughtException(args.Exception);            
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

        public void RecordException(Exception exception)
        {
        }

        [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        private static extern void void_objc_msgSend(IntPtr receiver, IntPtr selector);

        private static void UncaughtException(object exeptionObject)
        {
            var exception = exeptionObject as Exception;
            if (exception == null)
                return;

            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.StackTrace), "unhandled exception stack trace");
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.Message), "unhandled exception message");
            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.SetObjectValue(new NSString(exception.GetType().FullName), "unhandled exception");

            var stackFrames = new List<CLSStackFrame>();

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

            Bindings.CrashlyticsKit.Crashlytics.SharedInstance.RecordCustomExceptionName(exception.GetType().Name,  exception.Message, stackFrames.ToArray());

            //var nse = new NSException(exception.GetType().Name, exception.Message, null);
            //var sel = new Selector("raise");
            //void_objc_msgSend(nse.Handle, sel.Handle);
        }

        private void CaptureStackFrames(Exception ex)
        {
            var frames = new List<CLSStackFrame>();

            Action<StackTrace> frameWalker = (st) =>
            {
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);

                    string filename = sf.GetFileName();
                    MethodBase method = sf.GetMethod();

                    string methodName = "";
                    if (method != null)
                    {
                        var tokens = method.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        //if (tokens.Length > 1)
                        //    methodName = tokens.Skip(1).Aggregate((a, b) => a + " " + b);
                        //else
                        //    methodName = method.ToString();}
                    }

                    frames.Add(new CLSStackFrame()
                    {
                        FileName = filename ?? (method != null ? method.DeclaringType.Name + ".cs" : "uknown"),
                        LineNumber = (uint)sf.GetFileLineNumber(),
                        Symbol = method != null ? method.DeclaringType.FullName + "." + methodName : "wrapper_managed_to_native"
                    });
                }
            };

            if (ex != null)
            {
                //get traces from exception dispath info - they're are not included in StackTrace on mono
                StackTrace[] traces = null;
                var fi = typeof(Exception).GetField("captured_traces", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (fi != null)
                    traces = fi.GetValue(ex) as StackTrace[];

                if (traces != null)
                    foreach (var st in traces)
                        frameWalker(st);

                frameWalker(new StackTrace(ex, true));

                //Bindings.CrashlyticsKit.Crashlytics.SharedInstance.RecordCustomExceptionName(ex.GetType().Name, ex.Message, frames.Cast<NSObject>().ToArray());
            }
        }
    }
}