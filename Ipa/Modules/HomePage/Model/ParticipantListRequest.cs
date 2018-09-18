using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class ParticipantListRequest 
	{
		[JsonProperty(PropertyName ="uniqueAppId", NullValueHandling = NullValueHandling.Ignore) ]
		public string UniqueAppId {get; set;}
		[JsonProperty(PropertyName ="userName", NullValueHandling = NullValueHandling.Ignore) ]
		public string UserName {get; set;}
		[JsonProperty(PropertyName ="courseID", NullValueHandling = NullValueHandling.Ignore) ]
		public string CourseID {get; set;}
	}
	public class ParticipantListResponse :ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ParticipantData Data { get; set; }
	}

	public class ParticipantData
	{
		[JsonProperty (PropertyName = "participantList", NullValueHandling = NullValueHandling.Ignore)]
		public List<Reportee> ReportList { get; set; }
	}
}


