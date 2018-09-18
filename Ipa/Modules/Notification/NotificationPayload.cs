using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class NotificationPayload
	{
		[JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
		public NotificationInfo Info { get; set; }
		[JsonProperty(PropertyName = "payload", NullValueHandling = NullValueHandling.Ignore)]
		public Payload payload { get; set; }
	}

	public class NotificationInfo
	{
		[JsonProperty(PropertyName = "body", NullValueHandling = NullValueHandling.Ignore)]
		public string Body { set; get;}
		[JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
		public string Title { set; get;}
	}

	public class Payload
	{
		[JsonProperty(PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseId { set; get;}
		[JsonProperty(PropertyName = "activityID", NullValueHandling = NullValueHandling.Ignore)]
		public string ActivityId { set; get; }
	}
}

