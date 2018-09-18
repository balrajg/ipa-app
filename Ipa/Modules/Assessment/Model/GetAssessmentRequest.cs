using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetAssesmentRequest
	{
//		{
//			"uniqueAppId": "2344HEUDMK3344",
//			"courseID": "",
//			"activityID": "",
//			"activityName": ""
//		}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseId { get; set; }
		[JsonProperty (PropertyName = "activityID", NullValueHandling = NullValueHandling.Ignore)]
		public string ActivityId { get; set; }
		[JsonProperty (PropertyName = "activityName", NullValueHandling = NullValueHandling.Ignore)]
		public string ActivityName { get; set; }

	}

	public class GetAssesmentResponse : ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public List<ReviewQuestion> QuestionList { get; set; }
	}

	public class ReviewQuestion
	{
		[JsonProperty (PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
		public string Id { get; set; }
		[JsonProperty (PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
		public string Category { get; set; }
		[JsonProperty (PropertyName = "questionText", NullValueHandling = NullValueHandling.Ignore)]
		public string QuestionText { get; set; }
		[JsonProperty (PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
		public int Type { get; set; }
		[JsonProperty (PropertyName = "options", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Options { get; set; }

	}
}

