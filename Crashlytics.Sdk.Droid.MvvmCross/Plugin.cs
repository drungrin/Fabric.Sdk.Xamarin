using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace Crashlytics.Sdk.Droid.MvvmCross
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<ICrashlytics>(new Crashlytics());
        }
    }
}