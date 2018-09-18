using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class ParticipantRating
	{
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseId{ get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName{ get; set; }
		[JsonProperty (PropertyName = "rating", NullValueHandling = NullValueHandling.Ignore)]
		public List<RatingAnswer> Rating{ get; set; }
	}
	public class RatingAnswer
	{
		[JsonProperty (PropertyName = "questionID", NullValueHandling = NullValueHandling.Ignore)]
		public string QuestionID{ get; set; }
		[JsonProperty (PropertyName = "answer", NullValueHandling = NullValueHandling.Ignore)]
		public string AnswerText{ get; set; }
	}
}

