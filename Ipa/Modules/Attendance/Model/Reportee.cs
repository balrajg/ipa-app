using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class Reportee
	{
		[JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty(PropertyName = "fullName", NullValueHandling = NullValueHandling.Ignore)]
		public string FullName { get; set; }
		[JsonProperty(PropertyName = "surName", NullValueHandling = NullValueHandling.Ignore)]
		public string SurName { get; set; }
		[JsonProperty(PropertyName = "profileImage", NullValueHandling = NullValueHandling.Ignore)]
		public string ProfileImage { get; set; }
		[JsonProperty(PropertyName = "empID", NullValueHandling = NullValueHandling.Ignore)]
		public string EmpId { get; set; }
	}
}

