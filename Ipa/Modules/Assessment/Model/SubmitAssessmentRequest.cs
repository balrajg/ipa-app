using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ipa
{
	public class SubmitAssessmentRequest
	{
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "apiRequest", NullValueHandling = NullValueHandling.Ignore)]
		public AssessmentData Data { get; set; }
//		{
//			"uniqueAppId": "2344HEUDMK3344",
//			"apiRequest": {
//				"courseID": "",
//				"userName": "",
//				"activityID": "",
//				"activityName": "",
//				"answerList": [
//					{
//						"questionID": 1,
//						"answer": "Strongly Agree"
//					},
//					{}
//				]
//			}
//		}
	}
	public class SubmitAssessmentResponse: ResponseBase
	{
		//		{"responseCode":"1000"}
	}
	public class AssessmentData
	{
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseId;
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName;
		[JsonProperty (PropertyName = "activityID", NullValueHandling = NullValueHandling.Ignore)]
		public string ActivityID;
		[JsonProperty (PropertyName = "activityName", NullValueHandling = NullValueHandling.Ignore)]
		public string ActivityName;
		[JsonProperty (PropertyName = "answerList", NullValueHandling = NullValueHandling.Ignore)]
		public List<Result> AnswerList;
	}

	public class Result
	{
		[JsonProperty (PropertyName = "questionID", NullValueHandling = NullValueHandling.Ignore)]
		public string QuestionID;
		[JsonProperty (PropertyName = "answer", NullValueHandling = NullValueHandling.Ignore)]
		public string Answer;
	}
}

