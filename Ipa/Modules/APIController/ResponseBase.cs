using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class ResponseBase
	{
		
		[JsonProperty( PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
		public string Status;

		[JsonProperty( PropertyName = "responseCode", NullValueHandling = NullValueHandling.Ignore)]
		public string ResponseCode;
	}
}

