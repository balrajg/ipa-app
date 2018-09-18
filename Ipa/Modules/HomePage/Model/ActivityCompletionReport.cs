using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class ActivityCompletionReport
	{
//		{
//			"uniqueAppId": "2344HEUDMK3344",
//			"userName": "",
//			"courseID": "",
//			"participantList": [
//				"<userName>",
//				"",
//				""
//			]
//		}

		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseId { get; set; }
		[JsonProperty (PropertyName = "participantList", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> ParticipantList { get; set; }
	}
	public  class ActivityCompletionReportResponse: ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ActivityDetail ParticipantInfo { get; set; }
	}
	public class ActivityDetail
	{
		[JsonProperty (PropertyName = "participantList", NullValueHandling = NullValueHandling.Ignore)]
		public List<ActivityData> ActivityData { get; set; }
	}
	public  class ActivityData
	{
		[JsonProperty (PropertyName = "activityList", NullValueHandling = NullValueHandling.Ignore)]
		public List<ParticipantDetail> ActivityList { get; set; }
	}
	public class ParticipantDetail
	{
		[JsonProperty (PropertyName = "activityID", NullValueHandling = NullValueHandling.Ignore)]
		public string ActivityID { get; set; }
		[JsonProperty (PropertyName = "activityName", NullValueHandling = NullValueHandling.Ignore)]
		public string ActivityName { get; set; }
		[JsonProperty (PropertyName = "completed", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Completed; 
		[JsonProperty (PropertyName = "pending", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Pending;
		[JsonProperty (PropertyName = "overdue", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Overdue;
	}
}

