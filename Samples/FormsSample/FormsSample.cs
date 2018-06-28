using System;
using System.Collections.Generic;
using AnswersKit;
using CrashlyticsKit;
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

