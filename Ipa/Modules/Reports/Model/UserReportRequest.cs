using System;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace Ipa
{
	public class UserReportRequest 
	{
//		{"uniqueAppId":"2344HEUDMK3344","userName":"","courseID":""}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
	}

	public class UserReportResponse : ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ParticipantReportSummary ParticipantReportData{ get; set;}
	}
}


