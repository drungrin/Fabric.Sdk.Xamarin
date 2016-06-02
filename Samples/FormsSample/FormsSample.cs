using System;
using System.Collections.Generic;
using AnswersKit;
using CrashlyticsKit;
using DigitsKit;
using Xamarin.Forms;

namespace FormsSample
{
    public class App : Application
    {
        public App()
        {
            var forceCrashButton = new Button
            {
                Text = "Force Crash!"
            };
            forceCrashButton.Clicked += (sender, e) => Crashlytics.Instance.Crash();


            var forceManagedCrashButton = new Button
            {
                Text = "Force Managed Crash!"
            };
            forceManagedCrashButton.Clicked += (sender, e) => (new int[0])[0] = 0;

            var triggerKeyMetricButton = new Button
            {
                Text = "Trigger Key Metric"
            };
            triggerKeyMetricButton.Clicked += (sender, e) => Answers.Instance.LogCustom("Video Played", new Dictionary<string, object> {
                { "Category", "Comedy" },
                { "Length", 350 }
            });

            var digitsButton = new Button
            {
                Text = "Digits Auth"
            };
            digitsButton.Clicked += (sender, e) => Digits.Instance.Authenticate((session, code) =>
            {
                if (session == null)
                {
                    MainPage.DisplayAlert("Error", $"Error authenticating. ErrorCode: {code}", "OK");
                }
                else
                {
                    MainPage.DisplayAlert("Authenticated", $"UserId: {session.UserId}, PhoneNumber: {session.PhoneNumber}", "OK");
                }
            });


            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        triggerKeyMetricButton,
                        forceCrashButton,
                        forceManagedCrashButton,
                        digitsButton
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

