# Fabric.Sdk.Xamarin

- Answers
- Crashlytics
- Digits

For Xamarin.Forms, Xamarin.Android and Xamarin.iOS.

For iOS, you need to create a application with the same bundle id on XCode as the one on your Xamarin app.
Then, use the Fabric Mac app to add your app and complete the Kits on-boarding process.

For Android, you need to create a application with the same package name on android studio as the one on your Xamarin app.
Then, use the Fabric Mac app to add your app and complete the Kits on-boarding process.

After that, you can follow the instructions on https://www.fabric.io/kits to configure your projects.

For crashlytics on android, there is a hidden configuration, you need to add/update the build id using a string resource

<code>&lt;string name="com.crashlytics.android.build_id">e9e6beb9c4284289ac68b9ab76a9ee56&lt;/string></code>

Or else you'll get a crash on startup ("Unable to extract Crashlytics build info from the dropped APK. Please make sure your Crashlytics build tool plugin is installed and enabled")

There is a Sample available on Samples folder.

On iOS, Crashlytics shouldn't be used with Answers. Crashlytics includes Answers, so you should use either.

[Dropping .apk in Android Studio plugin for Beta] (https://github.com/drungrin/Fabric.Sdk.Xamarin/issues/7)
