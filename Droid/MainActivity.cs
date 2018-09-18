using System;

using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin;
using FFImageLoading.Forms.Droid;
using Plugin.Permissions;
using Newtonsoft.Json.Linq;
using Android.Preferences;
using Acr.Settings;

namespace Ipa.Droid

{
	[Activity (Label = "Impact", MainLauncher = true,   ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.StateVisible, LaunchMode = LaunchMode.SingleInstance)]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		public static bool IsAppRunning = false;

		protected override void OnCreate (Bundle bundle)
		{


			FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
			FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

			base.OnCreate (bundle);

			//string payload = null;


			var preference = this.GetSharedPreferences("NotificationPayload",Android.Content.FileCreationMode.WorldWriteable);


			//string courseId = preference.GetString("CourseId", null);//  Edit().PutString("CourseId", data.Property("courseID").ToString());
			//string activityId = preference.GetString("ActivityId", null);//  .getString("ActivityId", data.Property("activityID").ToString());

			//var editor = preference.Edit();
			//editor.PutString("CourseId", null);
			//editor.PutString("ActivityId",null);
			//editor.Commit();

			string courseId = CrossSettings.Current.Get<string>("CourseId");
			string activityId = CrossSettings.Current.Get<string>("ActivityId");



            CrossSettings.Current.Set<string>("CourseId", null);
            CrossSettings.Current.Set<string>("ActivityId", null);

			//Insights.Initialize(Constants.INSIGHT_API_KEY, this);
			global::Xamarin.Forms.Forms.Init (this, bundle);
			CachedImageRenderer.Init(true);

			LoadApplication (new App (courseId, activityId));
		}

		protected override void OnNewIntent(Android.Content.Intent intent)
		{
			base.OnNewIntent(intent);
			if (intent.Extras != null)
			{
				Console.WriteLine(intent.Extras.GetString("paylaod"));
			}
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		protected override void OnStart()
		{
			base.OnStart();
			IsAppRunning = true;
		}

		protected override void OnStop()
		{
			base.OnStop();
			IsAppRunning = false;
		}

		protected override void OnResume()
		{
			base.OnResume();
			IsAppRunning = true;
		}
	}
}

