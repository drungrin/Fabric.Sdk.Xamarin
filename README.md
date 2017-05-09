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

For crashlytics on android, please see below on how to generate a unique build UUID. 

Or else you'll get a crash on startup ("Unable to extract Crashlytics build info from the dropped APK. Please make sure your Crashlytics build tool plugin is installed and enabled")

There is a Sample available on Samples folder.

On iOS, Crashlytics shouldn't be used with Answers. Crashlytics includes Answers, so you should use either.

[Dropping .apk in Android Studio plugin for Beta] (https://github.com/drungrin/Fabric.Sdk.Xamarin/issues/7)

## Android Fabric UUID

### Install Android Studio
[Download and install android studio](https://developer.android.com/studio/index.html), and [follow the instructions to integrate Fabric with your project](https://fabric.io/kits/android/crashlytics/install).

Ensure that in your AndroidManifest.xml file in the AS project you have the same package name, version number and version code (build number) as your Xamarin Studio / Visual Studio project. 

### Updating Crashlytics Build ID
In order to automate the process Crashlytics has a plugin for Android Studio (“AS”) that creates a UUID for a version.& build number when you make the project. Since there is no plugin for Xamarin, whenever we increment the build number or version number we will need to amend the same values in the dummy AS project and build it.

Once the project is open in AS click the project browser on the left, under App select -> manifests -> AndroidManifest.xml. Ammend the version name and version code (Build Number) and then click the Make button (Hammer circled below).

![Image 1][img1]

When the build is finished you will see the following in the bottom right:

![Image 2][img2]

Make sure that it is a recent finish, and not one from before you made the changes **otherwise the UUID will not work**.

### Generating the UUID
Select the search icon in the top right of AS:

![Image3][img3]

Search for:

com_crashlytics_build_id.xml

Or navigate to:

![Image 4][img4]

Then copy the UUID in the <string/> XML tag and paste it into Strings.xml in Xamarin Studio here:

![Image 5][img5]

In the format 
<code>&lt;string name="com.crashlytics.android.build_id">build_id&lt;/string></code>

And presto everything should work! Just check the log output shows:

[Fabric] Build ID is: <New Build ID>

### Checking A Crash Has Sent
Put a breakpoint on the line after Fabric.Instance.Initialize(this) - and look at the fabric log output at that point. The two lines you are looking for are an HTTP response code (202) and uploaded with ID.

If ID is blank then the build UUID is incorrect.

[img1]: assets/1.png?raw=true "Android Manfiest"
[img2]: assets/2.png?raw=true "Build Complete"
[img3]: assets/3.png?raw=true "Search Button"
[img4]: assets/4.png?raw=true "File Location"
[img5]: assets/5.png?raw=true "XS Structure"
