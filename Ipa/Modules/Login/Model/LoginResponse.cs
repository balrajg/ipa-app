using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class LoginResponse : ResponseBase
	{
		//{"responseCode":"1000","roleID":[1,2],"uniqueAppId":"2344HEUDMK3344"}
		[JsonProperty ( PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set;}
	}
}

