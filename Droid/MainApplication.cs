using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Autofac;
using Plugin.CurrentActivity;

namespace Ipa.Droid
{
	//You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
	{
		public static Context AppContext;

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!
			AppContext = this.ApplicationContext;

			//TODO: Initialize CrossPushNotification Plugin
			//TODO: Replace string parameter with your Android SENDER ID
			//TODO: Specify the listener class implementing IPushNotificationListener interface in the Initialize generic
			//CrossPushNotification.Initialize<CrossPushNotificationListener>(Constants.ANDROID_PROJECT_ID);
			ContainerBuilder builder = new ContainerBuilder();
			//builder.RegisterType<NotificationImplement>().As<INotification>().SingleInstance();

			//CrossPushNotificationListener.Container = builder.Build();

			//StartPushService();
        }
        /*
		public static void StartPushService()
		{
			AppContext.StartService(new Intent(AppContext, typeof(PushNotificationService)));

			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
			{

				PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(PushNotificationService)), 0);
				AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
				alarm.Cancel(pintent);
			}
		}

		public static void StopPushService()
		{
			AppContext.StopService(new Intent(AppContext, typeof(PushNotificationService)));
			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
			{
				PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(PushNotificationService)), 0);
				AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
				alarm.Cancel(pintent);
			}
		}
        */

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

		void IActivityLifecycleCallbacks.OnActivityCreated(Android.App.Activity activity, Bundle savedInstanceState)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		void IActivityLifecycleCallbacks.OnActivityDestroyed(Android.App.Activity activity)
		{
			
		}

		void IActivityLifecycleCallbacks.OnActivityPaused(Android.App.Activity activity)
		{
			
		}

		void IActivityLifecycleCallbacks.OnActivityResumed(Android.App.Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		void IActivityLifecycleCallbacks.OnActivitySaveInstanceState(Android.App.Activity activity, Bundle outState)
		{
			
		}

		void IActivityLifecycleCallbacks.OnActivityStarted(Android.App.Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		void IActivityLifecycleCallbacks.OnActivityStopped(Android.App.Activity activity)
		{
			
		}
	}
}