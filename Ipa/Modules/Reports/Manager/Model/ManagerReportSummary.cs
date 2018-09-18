using System;

using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ipa
{
	public class ManagerReportSummary 
	{
		[JsonProperty (PropertyName = "participant", NullValueHandling = NullValueHandling.Ignore)]
		public List<Reportee> ParticipantList;
		[JsonProperty (PropertyName = "manager", NullValueHandling = NullValueHandling.Ignore)]
		public string ManagerName;
		[JsonProperty (PropertyName = "managerEmail", NullValueHandling = NullValueHandling.Ignore)]
		public string ManagerEmail;
		[JsonProperty (PropertyName = "trFromDate", NullValueHandling = NullValueHandling.Ignore)]
		public string TrFromDate;
		[JsonProperty (PropertyName = "trToDate", NullValueHandling = NullValueHandling.Ignore)]
		public string TrToDate;
		[JsonProperty (PropertyName = "attendance", NullValueHandling = NullValueHandling.Ignore)]
		public string Attendance;
		[JsonProperty (PropertyName = "l1FeedbackScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L1FeedbackScore;
		[JsonProperty (PropertyName = "l2BeliefPreScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2BeliefPreScore;
		[JsonProperty (PropertyName = "l2BeliefPostScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2BeliefPostScore;
		[JsonProperty (PropertyName = "l2OverallBeliefChange", NullValueHandling = NullValueHandling.Ignore)]
		public string L2OverallBeliefChange;
		[JsonProperty (PropertyName = "l2BChangeOnPotential", NullValueHandling = NullValueHandling.Ignore)]
		public string L2BChangeOnPotential;
		[JsonProperty (PropertyName = "noBParicipants25", NullValueHandling = NullValueHandling.Ignore)]
		public string NoBParicipants25;
		[JsonProperty (PropertyName = "bSigImp", NullValueHandling = NullValueHandling.Ignore)]
		public string BSigImp;
		[JsonProperty (PropertyName = "l2SkillPreScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2SkillPreScore;
		[JsonProperty (PropertyName = "l2SkillPostScore", NullValueHandling = NullValueHandling.Ignore)]
		public string L2SkillPostScore;
		[JsonProperty (PropertyName = "l2OverallSkillChange", NullValueHandling = NullValueHandling.Ignore)]
		public string L2OverallSkillChange;
		[JsonProperty (PropertyName = "l2SChangeOnPotential", NullValueHandling = NullValueHandling.Ignore)]
		public string L2SChangeOnPotential;
		[JsonProperty (PropertyName = "noSParicipants25", NullValueHandling = NullValueHandling.Ignore)]
		public string NoSParicipants25;
		[JsonProperty (PropertyName = "sSigImp", NullValueHandling = NullValueHandling.Ignore)]
		public string SSigImp;
		[JsonProperty (PropertyName = "cpScore1", NullValueHandling = NullValueHandling.Ignore)]
		public string CpScore1;
		[JsonProperty (PropertyName = "cpScore2", NullValueHandling = NullValueHandling.Ignore)]
		public string CpScore2;
		[JsonProperty (PropertyName = "cpScore3", NullValueHandling = NullValueHandling.Ignore)]
		public string CpScore3;
		[JsonProperty (PropertyName = "actionPlan1", NullValueHandling = NullValueHandling.Ignore)]
		public string ActionPlan1;
		[JsonProperty (PropertyName = "actionPlan2", NullValueHandling = NullValueHandling.Ignore)]
		public string ActionPlan2;
		[JsonProperty (PropertyName = "actionPlan3", NullValueHandling = NullValueHandling.Ignore)]
		public string ActionPlan3;
		[JsonProperty (PropertyName = "lapAct1", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct1;
		[JsonProperty (PropertyName = "lapAct2", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct2;
		[JsonProperty (PropertyName = "lapAct3", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct3;
		[JsonProperty (PropertyName = "lapAct4", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct4;
		[JsonProperty (PropertyName = "lapAct5", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct5;
		[JsonProperty (PropertyName = "lapAct6", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct6;
		[JsonProperty (PropertyName = "lapAct7", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct7;
		[JsonProperty (PropertyName = "lapAct8", NullValueHandling = NullValueHandling.Ignore)]
		public string LapAct8;
		[JsonProperty (PropertyName = "externalScores", NullValueHandling = NullValueHandling.Ignore)]
		public string ExternalScores;
	}
}


