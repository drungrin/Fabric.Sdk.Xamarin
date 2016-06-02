using System;
using System.Collections.Generic;
using System.Linq;
using CrashlyticsKit;
using DigitsKit;
using FabricSdk;
using Foundation;
using UIKit;

namespace FormsSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private const string TwitterKey = "vKd9PQGnq3WwHQdQcCL77LBVy";
        private const string TwitterSecret = "5N1aMvb3qP6IlmRlVpr8Q3lbWOaFNc3SxEzULeXQVjLIGKZc21";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Crashlytics.Instance.Initialize();
            Digits.Instance.Initialize(TwitterKey, TwitterSecret);
            Fabric.Instance.Debug = true;
            Fabric.Instance.Initialize();

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

