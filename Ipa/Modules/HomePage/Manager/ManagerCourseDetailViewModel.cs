using System;

using Xamarin.Forms;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Ipa
{
	public class ManagerCourseDetailViewModel : ViewModelBase
	{
		ManagerCourseDetailPage _managerCourseDetailPage;
		private CourseViewModel _SelectedCourse;

		public ManagerCourseDetailViewModel (CourseViewModel selectedCourse,List<Reportee> reporteeList, List<ParticipantDetail> activityList)
		{
			this._SelectedCourse = selectedCourse;
			FetchAttendanceReport (selectedCourse.CourseId);
			GetReporteeViewModelList (reporteeList);
			GetActivityViewModelList (activityList);

			IsOverView = true;
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

		private ObservableCollection<ActivityCompletionViewModel> _ActivityCompletionList;

		public ObservableCollection<ActivityCompletionViewModel> ActivityCompletionList {
			set { 
				if (Set (() => ActivityCompletionList, ref _ActivityCompletionList, value)) {
					RaisePropertyChanged (() => ActivityCompletionList);
				}
			}
			get { 
				return _ActivityCompletionList ?? (_ActivityCompletionList = new ObservableCollection<ActivityCompletionViewModel> ());
			}
		}

//		private ObservableCollection<AttendanceListItemViewModel> _AttendanceList;
//
//		public ObservableCollection<AttendanceListItemViewModel> AttendanceList {
//			set { 
//				if (Set (() => AttendanceList, ref _AttendanceList, value)) {
//					RaisePropertyChanged (() => AttendanceList);
//				}
//			}
//			get { 
//				return _AttendanceList ?? (_AttendanceList = new ObservableCollection<AttendanceListItemViewModel> ());
//			}
//		}

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

		public string CourseFullName {
			get { 
				return _SelectedCourse.CourseFullName;
			}
		}

		public string CourseID {
			get {
				return _SelectedCourse.CourseId;
			}
		}

		public string CourseStatus {
			get { 
				return _SelectedCourse.CourseStatus;
			}
		}

		public ImageSource CourseSource {
			get { 
				return _SelectedCourse.TimeImage;
			}
		}

		public string TotalReportee {
			get { 
				if (_SelectedCourse.ParticipantCount != null)
					return string.Format ("MY REPORTEES ({0})", _SelectedCourse.ReporteeCount);
				else
					return "--";
			}
		}

		private bool _IsOverView;

		public bool IsOverView {
			set { 
				if (Set (() => IsOverView, ref _IsOverView, value)) {
					RaisePropertyChanged (()=>IsOverView);
					if (IsAttendance == IsOverView)
						IsAttendance = !IsOverView;
				}
			}
			get { 
				return _IsOverView;
			}
		}

		private bool _IsAttendance;
		public bool IsAttendance{
			set{ 
				if (Set (()=> IsAttendance, ref _IsAttendance, value)) {
					RaisePropertyChanged (()=>IsAttendance);
					if (IsOverView == IsAttendance)
						IsOverView = !IsAttendance;
				}
			}
			get{ 
				return _IsAttendance;
			}
		}

		private ActivityCompletionViewModel _SelectedActivity;

		public ActivityCompletionViewModel SelectedActivity {

			set { 
				_SelectedActivity = value;
				RaisePropertyChanged (() => SelectedActivity);
				if (value != null)
					OnActivitySelected ();
			}
			get { 
				return _SelectedActivity;
			}
		}
		private ReporteeViewModel _SelectedReportee;

		public ReporteeViewModel SelectedReportee {

			set { 
				_SelectedReportee = value;
				RaisePropertyChanged (() => SelectedReportee);
				if (value != null)
					SelectedReportee = null;
			}
			get { 
				return _SelectedReportee;
			}
		}
		private RelayCommand _BackBtnCmd;

		public RelayCommand BackBtnCmd {
			get { 
				return _BackBtnCmd ?? (_BackBtnCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
				}));
			}
		}


		private ObservableCollection<AttendanceListItemViewModel> _AttendanceListItems;
		public ObservableCollection<AttendanceListItemViewModel> AttendanceListItems{
			set{ 
				if(Set(()=> AttendanceListItems, ref _AttendanceListItems, value)){
					RaisePropertyChanged(()=> AttendanceListItems);
				}
			}
			get{ 
				return _AttendanceListItems ?? (_AttendanceListItems = new ObservableCollection<AttendanceListItemViewModel> ());
			}
		}

		private AttendanceListItemViewModel _SelectedItem;
		public AttendanceListItemViewModel SelectedItem{
			set{ 
				_SelectedItem = value;
				RaisePropertyChanged (() => SelectedItem);
				if (value != null) {
					OnAttendanceListItemSelected ();
				}
			}
			get{
				return _SelectedItem;
			}
		}


		public void OnAttendanceListItemSelected()

		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				ReportHandler.GetReporteeList (App.UserName, SelectedItem.CourseId,
					(responseReporteeList) => {
						Debug.WriteLine ("Success" + responseReporteeList.Data);
						ManagerAttendanceLookupPage _ManagerAttendanceLookupPage = new ManagerAttendanceLookupPage ();

						_ManagerAttendanceLookupPage.BindingContext = new ManagerAttendanceLookupViewModel(SelectedItem,responseReporteeList.Data.ReportList);
						NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ManagerAttendanceLookupPage);
						SelectedItem = null;

						IsBusy = false;
					},
					(errorResponseReporteeList) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);

						SelectedItem = null;

						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
		private RelayCommand<string> _SegmentSelectionCmd;
		public RelayCommand<string> SegmentSelectionCmd{
			get{
				return _SegmentSelectionCmd ?? (_SegmentSelectionCmd = new RelayCommand<string> ((selection) => {
					if (selection.Equals ("ATTENDANCE")) {
						IsAttendance = true;
					} else {
						IsOverView = true;
					}
				}));
			}
		}

		private async void GetAttendanceViewModelList(List<AttendanceDetail> attendanceList,CourseViewModel selectedcourse){

			ObservableCollection<AttendanceListItemViewModel> attendanceListItem= new ObservableCollection<AttendanceListItemViewModel> ();
			foreach (var attendance in attendanceList) {
				AttendanceListItemViewModel attendanceViewModel = new AttendanceListItemViewModel (attendance);
//				attendanceViewModel.ParticipantList = participantList;
				attendanceViewModel.CourseId=selectedcourse.CourseId;
				attendanceViewModel.StartDate = selectedcourse.StartDate;
				attendanceListItem.Add (attendanceViewModel);
			}
			AttendanceListItems = attendanceListItem;
		}

		private async Task FetchAttendanceReport (string courseId){
			if (CrossConnectivity.Current.IsConnected) {
				IsBusy = true;
				await AttendanceHandler.GetAttendance (courseId,
					(response) => {
						this.GetAttendanceViewModelList (response.AttendanceData.AttendanceList,_SelectedCourse);
						IsBusy = false;
					},
					(errorRespnose) => {
						//Error callback
						//Debug.WriteLine ("Error:: /nCode: " + errorRespnose.ResponseCode + "/nMessage: " + errorRespnose.Status);
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private async void OnActivitySelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				await ReportHandler.GetReporteeList (App.UserName, SelectedActivity.CourseId,
					(responseReporteeList) => {
						Debug.WriteLine ("Success" + responseReporteeList.Data);
						ManagerCourseDetailActivityPage _ManagerCourseDetailActivityPage = new ManagerCourseDetailActivityPage ();
						_ManagerCourseDetailActivityPage.BindingContext = new ManagerCourseDetailActivityViewModel (SelectedActivity, responseReporteeList.Data.ReportList);
						NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ManagerCourseDetailActivityPage);
						SelectedActivity=null;
						IsBusy = false;
					},
					(errorResponseReporteeList) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						SelectedActivity=null;
						IsBusy = false;
					});
			} else {
			NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
		}
		}

		private void GetReporteeViewModelList (List<Reportee> reporteeList)
		{

			ObservableCollection<ReporteeViewModel> reporteeListItem = new ObservableCollection<ReporteeViewModel> ();
			foreach (var reportee in reporteeList) {
				ReporteeViewModel reporteeViewModel = new ReporteeViewModel (reportee);
				reporteeListItem.Add (reporteeViewModel);
			}
			ReporteeList = reporteeListItem;
		}

		private void GetActivityViewModelList (List<ParticipantDetail> activityList)
		{

			ObservableCollection<ActivityCompletionViewModel> activityListItem = new ObservableCollection<ActivityCompletionViewModel> ();
			foreach (var activity in activityList) {
				ActivityCompletionViewModel activityViewModel = new ActivityCompletionViewModel (activity);
				activityViewModel.CourseId = CourseID;
				activityViewModel.CourseName = CourseFullName;
				activityListItem.Add (activityViewModel);
			}
			ActivityCompletionList = activityListItem;
		}
	}
}


