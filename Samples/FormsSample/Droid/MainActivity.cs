using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CrashlyticsKit;
using FabricSdk;
using DigitsKit;

namespace FormsSample.Droid
{
    [Activity(Label = "FormsSample.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const string TwitterKey = "vKd9PQGnq3WwHQdQcCL77LBVy";
        private const string TwitterSecret = "5N1aMvb3qP6IlmRlVpr8Q3lbWOaFNc3SxEzULeXQVjLIGKZc21";

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Crashlytics.Instance.Initialize();
            Digits.Instance.Initialize(TwitterKey, TwitterSecret);
            Fabric.Instance.Debug = true;
            Fabric.Instance.Initialize(this);


            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

