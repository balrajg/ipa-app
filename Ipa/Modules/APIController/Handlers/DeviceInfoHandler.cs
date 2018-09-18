using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp.Portable;
using Plugin.DeviceInfo;

namespace Ipa
{
	public class DeviceInfoHandler
	{
		public static async Task UpdateDeviceInfo( Action<DeviceResponse> successCallback = null, Action<ResponseBase> errorCallback = null){
			RestRequest request = new RestRequest ("/lms/api/registerapp", Method.PUT);
            String deviceId = CrossDeviceInfo.Current.Id == "unknown" ? "TestDeviceForDebug" : CrossDeviceInfo.Current.Id;
            request.AddBody(new DeviceInfo()
			{
				Device = CrossDeviceInfo.Current.Model,

				Os = (CrossDeviceInfo.Current.Platform == Plugin.DeviceInfo.Abstractions.Platform.Android) ? "android" : "ios",
				UniqueDeviceId = deviceId
            });
			DeviceResponse response = await APIServiceProvider.ServiceProvider.Execute<DeviceResponse> (request);  //ecute<object> (request);
			if ((response != null) && (response.ResponseCode == "1000"))
			{
				successCallback?.Invoke(response);
			}
			else {
				errorCallback?.Invoke((ResponseBase)response);
			}
		}
	}

	public class DeviceInfo
	{
		[JsonProperty (PropertyName = "uniqueDeviceId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueDeviceId { get; set; }
		[JsonProperty (PropertyName = "device", NullValueHandling = NullValueHandling.Ignore)]
		public string Device { get; set; }
		[JsonProperty (PropertyName = "os", NullValueHandling = NullValueHandling.Ignore)]
		public string Os { get; set; }
	}


	public class DeviceResponse: ResponseBase
	{
		[JsonProperty (PropertyName = "deviceToken", NullValueHandling = NullValueHandling.Ignore)]
		public string DeviceToken { get; set; }
	}
}

