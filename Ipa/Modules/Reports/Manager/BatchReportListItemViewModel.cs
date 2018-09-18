using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace Ipa
{
	public class BatchReportListItemViewModel : ViewModelBase
	{
		public BatchReportListItemViewModel (ManagerReportSummary managerReportSummary)
		{
			this._ManagerReportSummary = managerReportSummary;
		}

		private ManagerReportSummary _ManagerReportSummary;

		public string L1FeedbackScore
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L1FeedbackScore);
			}
		}

		public string L2BeliefPreScore
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L2BeliefPostScore);
			}
		}

		public string L2BeliefPostScore
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L2BeliefPostScore);
			}
		}

		public string L2BChangeOnPotential
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L2BChangeOnPotential);
			}
		}

		public string L2OverallBeliefChange
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L2OverallBeliefChange);
			}
		}

		public string L2SChangeOnPotential
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L2SChangeOnPotential);
			}
		}

		public string L2SkillPostScore
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L2SkillPostScore);
			}
		}

		public string L2SkillPreScore
		{
			get{
				return string.Format ("{0}%",_ManagerReportSummary.L2SkillPreScore);
			}
		}

		public List<Reportee> ReporteeList {
			get {
				return _ManagerReportSummary.ParticipantList;
			}
		}

		public string CpScore1 {
			get {
				return _ManagerReportSummary.CpScore1;
			}
		}

		public string CpScore2 {
			get {
				return _ManagerReportSummary.CpScore2;
			}
		}

		public string CpScore3 {
			get {
				return _ManagerReportSummary.CpScore3;
			}
		}

		public string LapAct1 {
			get {
				return _ManagerReportSummary.LapAct1;
			}
		}

		public string LapAct2 {
			get {
				return _ManagerReportSummary.LapAct2;
			}
		}

		public string LapAct3 {
			get {
				return _ManagerReportSummary.LapAct3;
			}
		}

		public string LapAct4 {
			get {
				return _ManagerReportSummary.LapAct4;
			}
		}

		public string LapAct5 {
			get {
				return _ManagerReportSummary.LapAct5;
			}
		}

		public string LapAct6 {
			get {
				return _ManagerReportSummary.LapAct6;
			}
		}

		public string LapAct7 {
			get {
				return _ManagerReportSummary.LapAct7;
			}
		}

		public string LapAct8 {
			get {
				return _ManagerReportSummary.LapAct8;
			}
		}
	}
}


