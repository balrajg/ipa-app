using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class ForgetPasswordRequest
	{
//		{"deviceToken":"2344HEUDMK3344", "userName":""}
		[JsonProperty( PropertyName = "deviceToken", NullValueHandling = NullValueHandling.Ignore)]
		public string DeviceToken { get; set; }
		[JsonProperty( PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string userName { get; set; }
	}

	public class ForgetPasswodResponse: ResponseBase
	{
		//Empty Body
	}
}

