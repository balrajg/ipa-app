using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ipa
{
	public class ParticipantReportViewModel: ViewModelBase
	{
		private static string _Default_Placeholder = "--";

		private ParticipantReportSummary _ParticipantReportSummary;
		public ParticipantReportViewModel (List<Course> courseList)
		{
			GetDropDownList (courseList);
			//SelectedCourseItem = Color.White;
		}
		private Color _SelectedCourseItem;

		public Color SelectedCourseItem {
			set {
				if (Set (() => SelectedCourseItem, ref _SelectedCourseItem, value)) {
					RaisePropertyChanged (() => SelectedCourseItem);
				}
			}
			get { 
				return _SelectedCourseItem;
			}
		}

		private bool _IsBusy;

		public bool IsBusy {
			set { 
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					_IsBusy = value;
				}
			}
			get { 
				return _IsBusy;
			}
		}	

		public string CRScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					foreach (var score in _ParticipantReportSummary.L1FeedbackScore)
						if (score.Category.Contains (Constants.CRValue)) {
							return "CR" +" "+ score.EarnedScore;
						}
				}

				return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string DAScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					foreach (var score in _ParticipantReportSummary.L1FeedbackScore)
						if (score.Category.Contains (Constants.DAValue)) {
							return "DA" +" "+ score.EarnedScore;
						}
				}

				return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string EMPScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					foreach (var score in _ParticipantReportSummary.L1FeedbackScore)
						if (score.Category.Contains (Constants.EMPValue)) {
							return "EMP" +" "+ score.EarnedScore;
						}
				}

				return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string FPScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					foreach (var score in _ParticipantReportSummary.L1FeedbackScore)
						if (score.Category.Contains (Constants.FPValue)) {
							return "FP" +" "+ score.EarnedScore;
						}
				}

				return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string OEScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					foreach (var score in _ParticipantReportSummary.L1FeedbackScore)
						if (score.Category.Contains (Constants.OEValue)) {
							return "OE" +" "+ score.EarnedScore;
						}
				}

				return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string TotalBeliefPreScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2BeliefPreScore!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2BeliefPreScore);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string TotalBeliefPostScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2BeliefPostScore!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2BeliefPostScore);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string L2OverallBeliefChange{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2OverallBeliefChange!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2OverallBeliefChange);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string L2BChangeOnPotential{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2BChangeOnPotential!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2BChangeOnPotential);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string L2TotalSkillPreScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2TotalSkillPreScore != null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2TotalSkillPreScore);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string L2TotalSkillPostScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2TotalSkillPostScore !=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2TotalSkillPostScore);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string L2OverallSkillChange{
			get{
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2OverallSkillChange !=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2OverallSkillChange);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string L2SChangeOnPotential{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2SChangeOnPotential!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2SChangeOnPotential);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string LapScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.LapScore !=null)
					return string.Format ("{0}%", _ParticipantReportSummary.LapScore);
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		public string SelectedCourseName{
			get{ 
				if (SelectedCourse != null && SelectedCourse.CourseShortName != null)
					return SelectedCourse.CourseShortName;
				else
					return ParticipantReportViewModel._Default_Placeholder;
			}
		}

		private CourseViewModel _SelectedCourse;

		public CourseViewModel SelectedCourse {

			set { 
				if (_SelectedCourse != value) {
					_SelectedCourse = value;
					if (value != null) {
						OnCourseNameSelected ();
						RaisePropertyChanged ("SelectedCourseItem");
						RaisePropertyChanged ("SelectedCourseName");
					}
				}
			}
			get { 
				return _SelectedCourse;
			}
		}
		private ObservableCollection<CourseViewModel> _DropDownList;

		public ObservableCollection<CourseViewModel> DropDownList {
			set { 
				if (Set (() => DropDownList, ref _DropDownList, value)) {
					RaisePropertyChanged (() => DropDownList);
				}
			}
			get { 
				return _DropDownList ?? (_DropDownList = new ObservableCollection<CourseViewModel> ());
			}
		}
			
		public void GetDropDownList(List<Course> courseList){

			ObservableCollection<CourseViewModel> courseListItem= new ObservableCollection<CourseViewModel> ();
			bool IsDefaultCourseSelected = false;
			foreach (var course in courseList) {
				CourseViewModel courseViewModel = new CourseViewModel (course);
				courseListItem.Add (courseViewModel);
				if (!IsDefaultCourseSelected) {
					SelectedCourse = courseViewModel;
					IsDefaultCourseSelected = true;
				}
			}
			DropDownList = courseListItem;
		}

		public async void OnCourseNameSelected()
		{
			if (SelectedCourse != null && SelectedCourse.CourseId != null) {
				SelectedCourseItem = Color.Green;
				await FetchUserReport (SelectedCourse.CourseId);
				SelectedCourse = null;
			}
		}

		private async Task FetchUserReport(string courseId){

			if (CrossConnectivity.Current.IsConnected) {
				await ReportHandler.GetUserReport(App.UserName, courseId ,
					(response) => {
						this._ParticipantReportSummary = response.ParticipantReportData;
						RaisePropertiesChanged();
					},
					(errorRespnose) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						RaisePropertiesChanged();
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private void RaisePropertiesChanged(){
			RaisePropertyChanged (() => CRScoreValue);
			RaisePropertyChanged (() => DAScoreValue);
			RaisePropertyChanged (() => EMPScoreValue);
			RaisePropertyChanged (() => LapScore);
			RaisePropertyChanged (() => L2OverallSkillChange);
			RaisePropertyChanged (() => L2TotalSkillPostScore);
			RaisePropertyChanged (() => FPScoreValue);
			RaisePropertyChanged (() => OEScoreValue);
			RaisePropertyChanged (() => TotalBeliefPreScore);
			RaisePropertyChanged (() => TotalBeliefPostScore);
			RaisePropertyChanged (() => L2OverallBeliefChange);
			RaisePropertyChanged (() => L2BChangeOnPotential);
			RaisePropertyChanged (() => L2TotalSkillPreScore);
			RaisePropertyChanged (() => L2TotalSkillPostScore);
			RaisePropertyChanged (() => L2SChangeOnPotential);
		}
	}
}

