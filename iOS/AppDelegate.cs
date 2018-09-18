using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using FFImageLoading.Forms.Touch;
using FFImageLoading.Forms.Platform;
using Xamarin;
using ImageCircle.Forms.Plugin.iOS;
using CachedImageRenderer = FFImageLoading.Forms.Platform.CachedImageRenderer;

namespace Ipa.iOS 
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

			//Insights.Initialize(Constants.INSIGHT_API_KEY);

			global::Xamarin.Forms.Forms.Init ();
			CachedImageRenderer.Init();
			ImageCircleRenderer.Init();

//			UINavigationBar.Appearance.BarTintColor = UIColor.Red;
			//CrossPushNotification.Initialize<CrossPushNotificationListener>();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}

		const string TAG = "PushNotification-APN";

		/*public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
		{
			if (CrossPushNotification.Current is IPushNotificationHandler)
			{
				((IPushNotificationHandler)CrossPushNotification.Current).OnErrorReceived(error);
			}
		}

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			if (CrossPushNotification.Current is IPushNotificationHandler)
			{
				((IPushNotificationHandler)CrossPushNotification.Current).OnRegisteredSuccess(deviceToken);
			}

		}

		public override void DidRegisterUserNotificationSettings(UIApplication application, UIUserNotificationSettings notificationSettings)
		{
			application.RegisterForRemoteNotifications();
		}
        */
		/* Uncomment if using remote background notifications. To support this background mode, enable the Remote notifications option from the Background modes section of iOS project properties. (You can also enable this support by including the UIBackgroundModes key with the remote-notification value in your app�s Info.plist file.)*/
		/*public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			if (CrossPushNotification.Current is IPushNotificationHandler)
			{
				((IPushNotificationHandler)CrossPushNotification.Current).OnMessageReceived(userInfo);
			}
		}

		public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
		{
			if (CrossPushNotification.Current is IPushNotificationHandler)
			{
				((IPushNotificationHandler)CrossPushNotification.Current).OnMessageReceived(userInfo);
			}
		} */
	}

}

