using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetPraticipantRatingQuestionList
	{
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }	
	}
	public class PraticipantRatingQuestionListResponse :ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public RateQuestionList QuestionInfo{ get; set; }
	}
	public class RateQuestionList
	{
		[JsonProperty (PropertyName = "questionList", NullValueHandling = NullValueHandling.Ignore)]
		public List<RateQuestion> QuestionData{ get ; set; }
	}
	public class RateQuestion
	{
		[JsonProperty (PropertyName = "questionID", NullValueHandling = NullValueHandling.Ignore)]
		public string QuestionID{ get; set; }
		[JsonProperty (PropertyName = "questionText", NullValueHandling = NullValueHandling.Ignore)]
		public string QuestionText{ get; set; }
		[JsonProperty (PropertyName = "questionType", NullValueHandling = NullValueHandling.Ignore)]
		public string QuestionType{ get; set; }
		[JsonProperty (PropertyName = "optionList", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> OptionList{ get; set; }
	}

}


