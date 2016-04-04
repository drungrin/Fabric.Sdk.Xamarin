using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace Crashlytics.Sdk.Answers.Droid.MvvmCross
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IAnswers>(new Answers());
        }
    }
}