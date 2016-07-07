using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Bindings.TwitterSdk.Core;
using Bindings.FabricSdk;
using Bindings.DigitsKit;

namespace Fabric_Demo
{
    [Activity(Label = "Fabric_Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IAuthCallback
    {
        // Note: Your consumer key and secret should be obfuscated in your source code before shipping.
        private static string TWITTER_KEY = "M3Z6o5x4yczZkBfEuJDdakg0t";
        private static string TWITTER_SECRET = "lNini8NDV7ISjHWoZ8oztkpYg6A7lFECl7yojTsI31CMCAalLc";

        public void Failure(DigitsException p0)
        {
            Toast.MakeText(this, "Unable to verify you!", ToastLength.Long).Show();
        }

        public void Success(DigitsSession p0, string p1)
        {
            Toast.MakeText(this, "Number " + p0.PhoneNumber + " verified", ToastLength.Long).Show();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            TwitterAuthConfig authConfig = new TwitterAuthConfig(TWITTER_KEY, TWITTER_SECRET);
            Fabric.With(this, new TwitterCore(authConfig), new Digits());
         
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            //custom Action method
            button.Click += delegate { Digits.Authenticate(this); };

            //with Digits Authenticate Button

            DigitsAuthButton digitsButton = (DigitsAuthButton)FindViewById(Resource.Id.auth_button);
            digitsButton.Text = "Hey Authenticate Me";
            digitsButton.SetCallback(this);
        }
    }
}

