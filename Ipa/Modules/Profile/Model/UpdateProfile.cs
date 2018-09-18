using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class UpdateProfileRequest
	{
		//{"uniqueAppId":"2344HEUDMK3344", "userName":"","apiRequest":{"profileInfo":{"userName":"","password":"","fullName":"","surName":"","profileImage":"<URL>", "phone":"", "emailId":""},"organizationInfo":{"organizationName":"", "empId":"","designation":"","city":""}}
		[JsonProperty(PropertyName ="uniqueAppId", NullValueHandling = NullValueHandling.Ignore) ]
		public string UniqueAppId {get; set;}
		[JsonProperty(PropertyName ="userName", NullValueHandling = NullValueHandling.Ignore) ]
		public string UserName { get; set; }
		[JsonProperty(PropertyName ="apiRequest", NullValueHandling = NullValueHandling.Ignore) ]
		public Profile ProfileInfo{ get; set;}

	}

	public class UpdateProfileResponse: ResponseBase
	{
//		{"responseCode":"1000"}

	}
}

