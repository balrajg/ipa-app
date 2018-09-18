using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ipa
{
	public class ManagerReportViewModel : ViewModelBase
	{
		private List<Course> _courseList;
		private static string _Default_Placeholder = "--";
		private ParticipantReportSummary _ParticipantReportSummary;

		public ManagerReportViewModel (List<Course> courseList)
		{
			GetDropDownList (courseList);
			_courseList = courseList;
			SelectedCourseItem = Color.White;
			GetDropList (courseList);
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
		public string CRScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					Score scoreObj = _ParticipantReportSummary.L1FeedbackScore.Find ((score) => score.Category.Equals (Constants.CRValue));
					if(scoreObj != null)
						return scoreObj.ToString ();
				}

				return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string DAScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					Score scoreObj =_ParticipantReportSummary.L1FeedbackScore.Find ((score) => score.Category.Equals (Constants.DAValue));
					if (scoreObj != null)
						return scoreObj.ToString ();
				}

				return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string EMPScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					Score scoreObj = _ParticipantReportSummary.L1FeedbackScore.Find ((score) => score.Category.Equals (Constants.EMPValue));
					if (scoreObj != null)
						return scoreObj.ToString ();
				}

				return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string FPScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					Score scoreObj = _ParticipantReportSummary.L1FeedbackScore.Find ((score) => score.Category.Equals (Constants.FPValue));
					if (scoreObj != null)
						return scoreObj.ToString ();
				}

				return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string OEScoreValue {
			get {
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L1FeedbackScore != null){
					Score scoreObj =_ParticipantReportSummary.L1FeedbackScore.Find ((score) => score.Category.Equals (Constants.OEValue));			
					if (scoreObj != null)
						return scoreObj.ToString ();
				}

				return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string TotalBeliefPreScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2BeliefPreScore!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2BeliefPreScore);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string TotalBeliefPostScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2BeliefPostScore!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2BeliefPostScore);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string L2OverallBeliefChange{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2OverallBeliefChange!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2OverallBeliefChange);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string L2BChangeOnPotential{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2BChangeOnPotential!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2BChangeOnPotential);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string L2TotalSkillPreScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2TotalSkillPreScore != null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2TotalSkillPreScore);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string L2TotalSkillPostScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2TotalSkillPostScore !=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2TotalSkillPostScore);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string L2OverallSkillChange{
			get{
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2OverallSkillChange !=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2OverallSkillChange);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string L2SChangeOnPotential{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.L2SChangeOnPotential!=null)
					return string.Format ("{0}%", _ParticipantReportSummary.L2SChangeOnPotential);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string LapScore{
			get{ 
				if (_ParticipantReportSummary != null && _ParticipantReportSummary.LapScore !=null)
					return string.Format ("{0}%", _ParticipantReportSummary.LapScore);
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}

		public string SelectCourseName{
			get{ 
				if (SelectCourse != null && SelectCourse.CourseShortName != null)
					return SelectCourse.CourseShortName;
				else
					return ManagerReportViewModel._Default_Placeholder;
			}
		}
		private CourseViewModel _SelectCourse;

		public CourseViewModel SelectCourse {

			set { 
				if (_SelectCourse != value) {
					_SelectCourse = value;
					if (value != null) {
						CourseNameSelected ();
						RaisePropertyChanged ("SelectedCourseItem");
						RaisePropertyChanged ("SelectCourseName");
					}
				}
			}
			get { 
				return _SelectedCourse;
			}
		}
		private ObservableCollection<CourseViewModel> _DropList;

		public ObservableCollection<CourseViewModel> DropList {
			set { 
				if (Set (() => DropList, ref _DropList, value)) {
					RaisePropertyChanged (() => DropList);
				}
			}
			get { 
				return _DropList ?? (_DropList = new ObservableCollection<CourseViewModel> ());
			}
		}

		public void GetDropList(List<Course> courseList){

			ObservableCollection<CourseViewModel> courseListItem= new ObservableCollection<CourseViewModel> ();
			bool IsDefaultCourseSelected = false;
			foreach (var course in courseList) {
				CourseViewModel courseViewModel = new CourseViewModel (course);
				courseListItem.Add (courseViewModel);
				if (!IsDefaultCourseSelected) {
					SelectCourse = courseViewModel;
					IsDefaultCourseSelected = true;
				}
			}
			DropList = courseListItem;
		}

		public async void CourseNameSelected()
		{
			if (SelectCourse != null && SelectCourse.CourseId != null) {
				SelectedCourseItem = Color.Blue;
				await FetchUserReportParticitant (SelectCourse.CourseId);
				SelectCourse = null;
			}
		}

		private async Task FetchUserReportParticitant(string courseId){

			if (CrossConnectivity.Current.IsConnected) {
				await ReportHandler.GetUserReport(App.UserName, courseId ,
					(response) => {
						this._ParticipantReportSummary = response.ParticipantReportData;
						RaisePropertyChanged();
					},
					(errorRespnose) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						RaisePropertyChanged();
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private void RaisePropertyChanged(){
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
		private ObservableCollection<BatchReportListItemViewModel> _BatchReportList;

		public ObservableCollection<BatchReportListItemViewModel> BatchReportList {
			set { 
				if (Set (() => BatchReportList, ref _BatchReportList, value)) {
					RaisePropertyChanged (() => BatchReportList);
				}
			}
			get { 
				return _BatchReportList ?? (_BatchReportList = new ObservableCollection<BatchReportListItemViewModel> ());
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

		private ObservableCollection<ReporteeViewModel> _ReporteeList;

		public ObservableCollection<ReporteeViewModel> ReporteeList {
			set { 
				if (Set (() => ReporteeList, ref _ReporteeList, value)) {
					RaisePropertyChanged (() => ReporteeList);
				}
			}
			get { 
				return _ReporteeList ?? (_ReporteeList = new ObservableCollection<ReporteeViewModel> ());
			}
		}
		private ObservableCollection<ReporteeViewModel> _FilterReporteeList;

		public ObservableCollection<ReporteeViewModel> FilterReporteeList {
			set { 
				if (Set (() => FilterReporteeList, ref _FilterReporteeList, value)) {
					RaisePropertyChanged (() => FilterReporteeList);
				}
			}
			get { 
				return _FilterReporteeList ?? (_FilterReporteeList = new ObservableCollection<ReporteeViewModel> ());
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

		public string SelectedCourseName {
			get { 
				if (SelectedCourse != null && SelectedCourse.CourseShortName != null)
					return SelectedCourse.CourseShortName;
				else
					return string.Empty;
			}
		}

		private CourseViewModel _SelectedCourse;

		public CourseViewModel SelectedCourse {

			set { 
				if (_SelectedCourse != value) {
					RaisePropertyChanged (() => SelectedCourse);
					_SelectedCourse = value;
					if (value != null) {
						OnCourseNameSelected ();
						RaisePropertyChanged ("SelectedCourseName");
					}
				}
			}
			get { 
				return _SelectedCourse;
			}
		}

		private ReporteeViewModel _SelectedReport;

		public ReporteeViewModel SelectedReport {

			set { 
				_SelectedReport = value;
				RaisePropertyChanged (() => SelectedReport);
				if (value != null)
					OnReportSelected ();
			}
			get { 
				return _SelectedReport;
			}
		}
		private ReporteeViewModel _SelectedReportee;

		public ReporteeViewModel SelectedReportee {

			set { 
				_SelectedReportee = value;
				RaisePropertyChanged (() => SelectedReportee);
				if (value != null)
					OnreporteeSelected ();
			}
			get { 
				return _SelectedReportee;
			}
		}
		public void OnreporteeSelected()
		{
			SelectedReportee = null;
		}

		private RelayCommand _FilterCmd;

		public RelayCommand FilterCmd {
			get { 
				return _FilterCmd ?? (_FilterCmd = new RelayCommand (() => {
					DoFilter ();
				}));
			}
		}

		private RelayCommand _DropDownCmd;

		public RelayCommand DropDownCmd {
			get { 
				return _DropDownCmd ?? (_DropDownCmd = new RelayCommand (() => {
				}));
			}
		}

		private bool _FilterName=true;

		public bool FilterName {
			set { 
				if (Set (() => FilterName, ref _FilterName, value)) {
					RaisePropertyChanged (() => FilterName);
//					if (IsMeSelected) {
//						FilterName = false;
//					} else {
//						FilterName = true;
//					}

				}
			}
			get { 
				return _FilterName;
			}
		}
		private bool _IsMeSelected;

		public bool IsMeSelected {
			set { 
				if (Set (() => IsMeSelected, ref _IsMeSelected, value)) {
					RaisePropertyChanged (() => IsMeSelected);
					if (IsMeSelected) {
						FilterName = false;
					}
					if (IsMeSelected == IsReporteeSelected)
						IsReporteeSelected = !IsMeSelected;
				}
			}
			get { 
				return _IsMeSelected;
			}
		}
		private bool _IsReporteeSelected=true;

		public bool IsReporteeSelected {
			set { 
				if (Set (() => IsReporteeSelected, ref _IsReporteeSelected, value)) {
					RaisePropertyChanged (() => IsReporteeSelected);
					if (IsReporteeSelected) {
						FilterName = true;
					}
					if (IsReporteeSelected == IsMeSelected)
						IsMeSelected = !IsReporteeSelected;
				}
			}
			get { 
				return _IsReporteeSelected;
			}
		}

		private RelayCommand _DoneCmd;

		public RelayCommand DoneCmd {
			get { 
				return _DoneCmd ?? (_DoneCmd = new RelayCommand (() => {
					DoDone ();
				}));
			}
		}

		private RelayCommand _CloseCmd;

		public RelayCommand CloseCmd {
			get { 
				return _CloseCmd ?? (_CloseCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
				}));
			}
		}

		private bool _IsDualRole;
		public bool IsDualRole{

			get{ 
				Role userRole = App.GetUserRole ();
				if (userRole == Role.Manager) {
					return false;
				} else if(userRole == Role.ManagerCumParticipant){
					return true;
				}
				return false;
			}
		}

		private bool _IsEnabled;

		public bool IsEnabled {
			set { 
				if (Set (() => IsEnabled, ref _IsEnabled, value)) {
					if (IsMeSelected) {
						IsEnabled = false;
					} else {
						IsEnabled = true;
					}
					_IsEnabled = value;
				}
			}
			get { 
				return _IsEnabled;
			}
		}

		private ObservableCollection<CourseListViewModel> _CourseList;

		public ObservableCollection<CourseListViewModel> CourseList {
			set { 
				if (Set (() => CourseList, ref _CourseList, value)) {
					RaisePropertyChanged (() => CourseList);
				}
			}
			get { 
				return _CourseList ?? (_CourseList = new ObservableCollection<CourseListViewModel> ());
			}
		}

		private string CourseID {
			get {
				return SelectedCourse.CourseId;
			}
		}

		private RelayCommand _ResetCmd;

		public RelayCommand ResetCmd {
			get { 
				return _ResetCmd ?? (_ResetCmd = new RelayCommand (() => {
					DoReset ();
				}));
			}
		}

		private RelayCommand _FilterReporteeNameCmd;

		public RelayCommand FilterReporteeNameCmd {
			get { 
				return _FilterReporteeNameCmd ?? (_FilterReporteeNameCmd = new RelayCommand (() => {
					DoFilterReporteeName ();
				}));
			}
		}

		private List<ReporteeViewModel> _RawReporteeList = new List<ReporteeViewModel> ();

		public List<ReporteeViewModel> RawReporteeList {
			set { 
				_RawReporteeList = value;
			}
			get {

				return _RawReporteeList;
			}
		}

		private string _SearchText;

		public string SearchText {
			set { 
				if (Set (() => SearchText, ref _SearchText, value)) {
					if (SearchText.Length >= 3) {
						DoSearch ();
					} else {
						if (ReporteeList.Count != RawReporteeList.Count)
							ReporteeList = new ObservableCollection<ReporteeViewModel> (RawReporteeList);
					}
				}
			}
			get { 
				return _SearchText;
			}
		}

		private bool _IsSelectAll;

		public bool IsSelectAll {
			set { 
				if (Set (() => IsSelectAll, ref _IsSelectAll, value)) {
					foreach (var reportee in FilterReporteeList) {
						if (IsSelectAll) {
							reportee.IsSelected = true;
						}else{
							reportee.IsSelected = false;
						}
					}
					_IsSelectAll = value;
				}
			}
			get { 
				return _IsSelectAll;
			}
		}

		public void DoSearch ()
		{
			ReporteeList = new ObservableCollection<ReporteeViewModel> (RawReporteeList.FindAll ((vm) => { 
				return vm.FullName.Contains (SearchText);
			}
			));
		}

		public async void DoDone ()
		{
//			ObservableCollection<ReporteeViewModel> List = ReporteList;
			ObservableCollection<ReporteeViewModel> tempList = new ObservableCollection<ReporteeViewModel> ();
				foreach (ReporteeViewModel vm in FilterReporteeList) {
				if (vm.IsSelected) {
					tempList.Add (vm);
				}
			}
	
			ReporteeList = tempList;

			await NavigationHandler.GlobalNavigator.Navigation.PopAsync (true);
			await NavigationHandler.GlobalNavigator.Navigation.PopAsync (false);
		}

		public async void DoFilterReporteeName ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
						FilterReporteePage _FilterReporteePage = new FilterReporteePage ();
						_FilterReporteePage.BindingContext = this;
						NavigationHandler.GlobalNavigator.Navigation.PushAsync (_FilterReporteePage);
				IsBusy = false;
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		public void DoReset ()
		{
			if (IsMeSelected) {

				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			} else {
				
				ObservableCollection<ReporteeViewModel> List1 = FilterReporteeList;
				ObservableCollection<ReporteeViewModel> tempList1 = new ObservableCollection<ReporteeViewModel> ();
				foreach (ReporteeViewModel vm in FilterReporteeList) {
					vm.IsSelected = false;
						tempList1.Add (vm);
				}
				ReporteeList = tempList1;
				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			}
		}

		public void DoFilter ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				ManagerFilterPage _ManagerFilterPage = new ManagerFilterPage ();
				_ManagerFilterPage.BindingContext = this;
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ManagerFilterPage);
				IsBusy = false;
			}

		}

		private async void OnReportSelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				ReportBatchwiseCompletionStatusPage _ReportBatchwiseCompletionStatusPage = new ReportBatchwiseCompletionStatusPage ();
				_ReportBatchwiseCompletionStatusPage.BindingContext = new ReportBatchwiseViewModel (SelectedReport);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ReportBatchwiseCompletionStatusPage);
				SelectedReport = null;
				IsBusy = false;
			}
		}

		public void GetDropDownList (List<Course> courseList)
		{

			ObservableCollection<CourseViewModel> courseListItem = new ObservableCollection<CourseViewModel> ();
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

		public async void GetBatchReportViewModel (List<ManagerReportSummary> batchReportList)
		{
			TempList2.Clear ();
			RawReporteeList.Clear ();
			ObservableCollection<BatchReportListItemViewModel> batchReporteeListItem = new ObservableCollection<BatchReportListItemViewModel> ();
			foreach (var batchReport in batchReportList) {
				BatchReportListItemViewModel batchReportListItemViewModel = new BatchReportListItemViewModel (batchReport);

				batchReporteeListItem.Add (batchReportListItemViewModel);
				GetReporteeViewModelList (batchReport.ParticipantList, batchReport.L2SChangeOnPotential, batchReport.L2BChangeOnPotential, batchReport.CpScore1, batchReport.LapAct1, batchReport.L1FeedbackScore, batchReport.L2BeliefPostScore);
			}
			BatchReportList = batchReporteeListItem;
			FilterReporteeList = new ObservableCollection<ReporteeViewModel> (RawReporteeList);
			ReporteeList = TempList2;
		}
		public ObservableCollection<ReporteeViewModel> TempList2=new ObservableCollection<ReporteeViewModel>();

		public async void GetReporteeViewModelList (List<Reportee> reporteeList, string L1beliefAssessment, string L1skillAssessment, string L1feedbackScore, string lapScore, string cpScore, string l2BeliefPostScore)
		{

			foreach (var reportee in reporteeList) {
				ReporteeViewModel reporteeViewModel = new ReporteeViewModel (reportee);
				IsSelectAll = true;
				reporteeViewModel.IsSelected = true;
				reporteeViewModel.L2BChangeOnPotential = L1beliefAssessment;
				reporteeViewModel.L2SChangeOnPotential = L1skillAssessment;
				reporteeViewModel.CpScore = cpScore;
				reporteeViewModel.LapScore = lapScore;
				reporteeViewModel.L1FeedBackScore = L1feedbackScore;
				reporteeViewModel.L2BeliefPostScore = l2BeliefPostScore;
				TempList2.Add (reporteeViewModel);
				RawReporteeList.Add (reporteeViewModel);

			}
		}

		public async void OnCourseNameSelected ()
		{
			if (SelectedCourse != null && SelectedCourse.CourseId != null) {
				await FetchBatchReport (SelectedCourse.CourseId);
			}
		}

		private async Task FetchBatchReport (string courseId)
		{
			if (CrossConnectivity.Current.IsConnected) {
				await ReportHandler.GetBatchReportManager (App.UserName, courseId,
					(response) => {
						this.GetBatchReportViewModel (response.ApiData.BatchreportList);
						RaisePropertiesChanged ();
					},
					(errorRespnose) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						RaisePropertiesChanged ();
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		public void RaisePropertiesChanged ()
		{
			RaisePropertyChanged (() => ReporteeList);
			RaisePropertyChanged (() => FilterReporteeList);
			RaisePropertyChanged (() => BatchReportList);
			RaisePropertyChanged (() => DropDownList);
			RaisePropertyChanged (() => SelectedReport);
			RaisePropertyChanged (() => SelectedCourseName);
		}

	}
}


