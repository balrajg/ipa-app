using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class ViewProfileRequest
	{
//		{"uniqueAppId":"2344HEUDMK3344", "userName":""}
		[JsonProperty(  PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName{ get; set; }
		[JsonProperty(  PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId{ get; set; }
	}

	public class ViewProfileResponse: ResponseBase
	{
//		{"responseCode":"1000","apiResponse":{"profileInfo":{"userName":"","fullName":"","surName":"","profileImage":"<URL>", "phone":"", "emailID":"", "roleID":1},"organizationInfo":{"organizationName":"", "empId":"","designation":"","city":""}}
		[JsonProperty( PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public Profile ProfileInfo{ get; set; }

	}
}

