
using Ipa.DependancyServices;
using Ipa.Droid.DependancyService;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace Ipa.Droid.DependancyService
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}