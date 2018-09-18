using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class LoginRequest
	{
		//{"deviceToken":"DEV3342V4", "userName":"", "password":""}
		[JsonProperty ( PropertyName = "deviceToken", NullValueHandling = NullValueHandling.Ignore)]
		public string DeviceToken { get; set;}
		[JsonProperty ( PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set;}
		[JsonProperty ( PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
		public string Password { get; set;}
		[JsonProperty ( PropertyName = "deviceID", NullValueHandling = NullValueHandling.Ignore)]
		public string DeviceID { get; set;}


		public override string ToString()
		{
			return string.Format("[LoginRequest: DeviceToken={0}, UserName={1}, Password={2}, DeviceID={3}]", DeviceToken, UserName, Password, DeviceID);
		}
	}
}

