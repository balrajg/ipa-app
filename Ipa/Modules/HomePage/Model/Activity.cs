using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class Activity
	{
		[JsonProperty (PropertyName = "activityID", NullValueHandling = NullValueHandling.Ignore) ]
		public string ActivityId;
		[JsonProperty (PropertyName = "activityName", NullValueHandling = NullValueHandling.Ignore) ]
		public string ActivityName;
		[JsonProperty (PropertyName = "expectedDate", NullValueHandling = NullValueHandling.Ignore) ]
		public DateTime ExpectedDate;
		[JsonProperty (PropertyName = "actionId", NullValueHandling = NullValueHandling.Ignore) ]
		public int ActionId;
		[JsonProperty (PropertyName = "completedDate", NullValueHandling = NullValueHandling.Ignore) ]
		public DateTime CompletedDate;
		[JsonProperty (PropertyName = "status", NullValueHandling = NullValueHandling.Ignore) ]
		public int Status;
	}
}

