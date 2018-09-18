
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Android.Content.PM;
using Android.Support.V7.App;

namespace Ipa.Droid
{
	[Activity (NoHistory = true,Theme="@style/MyTheme", Icon = "@drawable/Ipa", ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]		
	public class SplashActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			System.Threading.Thread.Sleep(1000); 
			this.StartActivity(typeof(MainActivity));
		}
	}
}

