using System.Diagnostics;
using Plugin.PushNotification;
using Newtonsoft.Json.Linq;
using Acr.Settings;
using Autofac;
using Plugin.DeviceInfo;
namespace Ipa.Notification
{


    //Class to handle push notifications listens to events such as registration, unregistration, message arrival and errors.
    public class CrossPushNotificationListener : CrossPushNotification
    {
        static int notId = 0;

        public bool CanShow
        {
            get;
            set;
        }

        public static IContainer Container;

        public void OnMessage(JObject values)
        {

            /*if (DeviceType.Android == deviceType)
			{
				*/// Default Xamarin.Forms DependancyService will not work here.
                  // This may also get called from background while App is in not running state. 
                  // So, Xamarin.Forms will not get initialized at such scenarios. 
                  // So we use 3rd party DI libraries to achive this. In our case we used Autofac0
            CanShow = false;
            try
            {
                var payload = values.ToObject<NotificationPayload>();

                Container.Resolve<INotification>().Show(notId++, payload);
            }
            catch
            {
                Debug.WriteLine("Error on OnMessage.");
            }
            /*s
			else 
			{
				var aps = values.SelectToken("aps");
				Debug.WriteLine(aps);
				var payloadObj = aps.SelectToken("payload");
				if (payloadObj != null)
				{
					Debug.WriteLine(payloadObj);
					var payload = payloadObj.ToObject<Payload>();
					if ((null != payload) && (null != payload.CourseId))
					{
						Debug.WriteLine("course id::" + payload.CourseId);
						App.CurrentApplication?.StartActivity(payload.CourseId, payload.ActivityId);
					} 

				}*/
            //var test = values.Value<JObject>("aps"); 
            //var payload = test.ToObject<NotificationPayload>();
            //if (null != payload)
            //{
            //	App.CurrentApplication?.StartActivity("1624", "L1");
            //}
            //var payloadOriginal = new JavaScriptSerializer().Deserialize<Friends>(result);
            //var payloadOriginal = JsonConvert.DeserializeObject(test);
            //payloadOriginal.GetType


            //if (!string.IsNullOrEmpty(test))
            //{
            //	var pay = JObject.Parse(test);

            //	//Debug.WriteLine(test.ToString());
            //	var payload = test.Value.ToObject<NotificationPayload>();
            //if (null != payload)
            //{
            //	App.CurrentApplication?.StartActivity("1624", "L1");
            //}
            //}
            //Debug.WriteLine(test.ToString());
        }
    }




}