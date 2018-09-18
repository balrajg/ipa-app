using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class ParticipantReportSummary
	{
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName;
		[JsonProperty (PropertyName = "emailId", NullValueHandling = NullValueHandling.Ignore)]
		public string MailId;
		[JsonProperty (PropertyName = "managerName", NullValueHandling = NullValueHandling.Ignore)]
		public string ManagerName;
		[JsonProperty (PropertyName = "managerEmail", NullValueHandling = NullValueHandling.Ignore)]
		public string ManagerEmail;
		[JsonProperty (PropertyName = "l1FeedbackScore", NullValueHandling = NullValueHandling.Ignore)]
		public List<Score> L1FeedbackScore;
		[JsonProperty (PropertyName = "l2BeliefPreScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2BeliefPreScore;
		[JsonProperty (PropertyName = "l2BeliefPostScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2BeliefPostScore;
		[JsonProperty (PropertyName = "l2OverallBeliefChange", NullValueHandling = NullValueHandling.Ignore)]
		public string L2OverallBeliefChange;
		[JsonProperty (PropertyName = "l2BChangeOnPotential", NullValueHandling = NullValueHandling.Ignore)]
		public string L2BChangeOnPotential;
		[JsonProperty (PropertyName = "l2TotalSkillPreScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2TotalSkillPreScore;
		[JsonProperty (PropertyName = "l2TotalSkillPostScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2TotalSkillPostScore;
		[JsonProperty (PropertyName = "l2OverallSkillChange", NullValueHandling = NullValueHandling.Ignore)]
		public string L2OverallSkillChange;
		[JsonProperty (PropertyName = "l2SChangeOnPotential", NullValueHandling = NullValueHandling.Ignore)]
		public string L2SChangeOnPotential;
		[JsonProperty (PropertyName = "lapScore", NullValueHandling = NullValueHandling.Ignore)]
		public string LapScore;
	}


}

