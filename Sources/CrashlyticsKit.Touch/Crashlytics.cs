using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using CrashlyticsKit.Platform;
using FabricSdk;
using Foundation;
using ObjCRuntime;

namespace CrashlyticsKit
{
    public class Crashlytics : Kit, ICrashlytics
    {
        private static readonly Lazy<Crashlytics> LazyInstance = new Lazy<Crashlytics>(() => new Crashlytics());

        private Crashlytics() : base(Platform.Crashlytics.SharedInstance)
        {
        }

        public string Version => Platform.Crashlytics.SharedInstance.Version;

        public void Crash()
        {
        }

        public ICrashlytics SetUserIdentifier(string identifier)
        {
            Platform.Crashlytics.SharedInstance.SetUserIdentifier(identifier);
            return this;
        }

        public ICrashlytics SetUserName(string name)
        {
            Platform.Crashlytics.SharedInstance.SetUserName(name);
            return this;
        }

        public ICrashlytics SetUserEmail(string email)
        {
            Platform.Crashlytics.SharedInstance.SetUserEmail(email);
            return this;
        }

        public ICrashlytics SetObjectValue(string key, object value)
        {
            Platform.Crashlytics.SharedInstance.SetObjectValue(NSObject.FromObject(value), key);
            return this;
        }

        public ICrashlytics SetStringValue(string key, string value)
        {
            Platform.Crashlytics.SharedInstance.SetObjectValue(NSObject.FromObject(value), key);
            return this;
        }

        public ICrashlytics SetIntValue(string key, int value)
        {
            Platform.Crashlytics.SharedInstance.SetIntValue(value, key);
            return this;
        }

        public ICrashlytics SetBoolValue(string key, bool value)
        {
            Platform.Crashlytics.SharedInstance.SetBoolValue(value, key);
            return this;
        }

        public ICrashlytics SetFloatValue(string key, float value)
        {
            Platform.Crashlytics.SharedInstance.SetFloatValue(value, key);
            return this;
        }

        public ICrashlytics SetDoubleValue(string key, double value)
        {
            Platform.Crashlytics.SharedInstance.SetObjectValue(NSNumber.FromDouble(value), key);
            return this;
        }

        public ICrashlytics SetLongValue(string key, long value)
        {
            Platform.Crashlytics.SharedInstance.SetObjectValue(NSNumber.FromInt64(value), key);
            return this;
        }

        public void RecordException(Exception exception)
        {
            CaptureManagedInfo(exception);
            CaptureStackFrames(exception);
        }

        private void CaptureManagedInfo(Exception ex)
        {
            Platform.Crashlytics.SharedInstance.SetObjectValue(new NSString(Constants.Version), "monotouch version");

            if (ex != null)
            {
                Platform.Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.StackTrace), "unhandled exception stack trace");
                Platform.Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.Message), "unhandled exception message");
                Platform.Crashlytics.SharedInstance.SetObjectValue(new NSString(ex.GetType().FullName), "unhandled exception");
            }
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

                //Platform.Crashlytics.SharedInstance.RecordCustomExceptionName(ex.GetType().Name, ex.Message, frames.Cast<NSObject>().ToArray());
            }
        }
    }
}