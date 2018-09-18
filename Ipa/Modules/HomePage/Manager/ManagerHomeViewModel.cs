using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Connectivity;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public class ManagerHomeViewModel : ViewModelBase
	{
		

		private List<CourseViewModel> _RawManagerCourseList = new List<CourseViewModel> ();

		public List<CourseViewModel> RawManagerCourseList {
			set { 
				_RawManagerCourseList = value;
			}
			get {

				return _RawManagerCourseList;
			} 
		}


		private List<CourseViewModel> _RawParticipantCourseList = new List<CourseViewModel> ();

		public List<CourseViewModel> RawParticipantCourseList{
			set { 
				_RawParticipantCourseList = value;
			}
			get {

				return _RawParticipantCourseList;
			} 
		}

		private List<ActivityViewModel> _RawManagerActivityList = new List<ActivityViewModel> ();

		public List<ActivityViewModel> RawManagerActivityList {
			set { 
				_RawManagerActivityList = value;
			}
			get {

				return _RawManagerActivityList;
			}
		}

		private List<ActivityViewModel> _RawParticipantActivityList = new List<ActivityViewModel> ();

		public List<ActivityViewModel> RawParticipantActivityList {
			set { 
				_RawParticipantActivityList = value;
			}
			get {

				return _RawParticipantActivityList;
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
		private bool _IsManagerRole;
		public bool IsManagerRole{

			get{ 
				Role userRole = App.GetUserRole ();
				if (userRole == Role.Manager) {
					return true;
				} else if(userRole == Role.ManagerCumParticipant){
					return false;
				}

				return false;
			}
		}
		private bool _IsDual;
		public bool IsDual{

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
	
		private bool _IsMe;
		public bool IsMe {
			set { 
				if(Set(() => IsMe, ref _IsMe, value)){
					RaisePropertyChanged (()=> IsMe);
					if (IsMe == IsTeam) {
						IsTeam = !IsMe;
					}
				}
			}
			get{
				return _IsMe;
			}
		}

		private bool _IsTeam;
		public bool IsTeam {
			set { 
				if(Set(() => IsTeam, ref _IsTeam, value)){
					RaisePropertyChanged (()=> IsTeam);
					if (IsTeam == IsMe)
						IsMe = !IsTeam;
				}
			}
			get{
				return _IsTeam;
			}
		}

		private ObservableCollection<CourseViewModel> _ManagerCourseList;

		public ObservableCollection<CourseViewModel> ManagerCourseList {
			set { 
				if (Set (() => ManagerCourseList, ref _ManagerCourseList, value)) {
					RaisePropertyChanged (() => ManagerCourseList);
				}
			}
			get { 
				return _ManagerCourseList ?? (_ManagerCourseList = new ObservableCollection<CourseViewModel> ());
			}
		}

		private ObservableCollection<ActivityViewModel> _ManagerActivityList;

		public ObservableCollection<ActivityViewModel> ManagerActivityList {
			set { 
				if (Set (() => ManagerActivityList, ref _ManagerActivityList, value)) {
					RaisePropertyChanged (() => ManagerActivityList);
				}
			}
			get { 
				return _ManagerActivityList ?? (_ManagerActivityList = new ObservableCollection<ActivityViewModel> ());
			}
		}

		private ObservableCollection<CourseViewModel> _ParticipantCourseList;

		public ObservableCollection<CourseViewModel> ParticipantCourseList {
			set { 
				if (Set (() => ParticipantCourseList, ref _ParticipantCourseList, value)) {
					RaisePropertyChanged (() => ParticipantCourseList);
				}
			}
			get { 
				return _ParticipantCourseList ?? (_ParticipantCourseList = new ObservableCollection<CourseViewModel> ());
			}
		}

		private ObservableCollection<ActivityViewModel> _ParticipantActivityList;

		public ObservableCollection<ActivityViewModel> ParticipantActivityList {
			set { 
				if (Set (() => ParticipantActivityList, ref _ParticipantActivityList, value)) {
					RaisePropertyChanged (() => ParticipantActivityList);
				}
			}
			get { 
				return _ParticipantActivityList ?? (_ParticipantActivityList = new ObservableCollection<ActivityViewModel> ());
			}
		}

		//This same property used for both manager and participant role.
		private CourseViewModel _SelectedCourse;

		public CourseViewModel SelectedCourse {

			set { 
				if (_SelectedCourse != value) {
					_SelectedCourse = value;
					RaisePropertyChanged (() => SelectedCourse);
					if (value != null)
						OnManagerCourseSelected ();
				}
			}
			get { 
				return _SelectedCourse;
			}
		}



		private ActivityViewModel _SelectedActivity;

		public ActivityViewModel SelectedActivity {
			set { 
				_SelectedActivity = value;
				RaisePropertyChanged (() => SelectedActivity);
				if (value != null)
					SelectedActivity = null;
			}
			get { 
				return _SelectedActivity;
			}
		}

		private CourseViewModel _SelectedParticipantCourse;

		public CourseViewModel SelectedParticipantCourse {

			set { 
				if (_SelectedParticipantCourse != value) {
					_SelectedParticipantCourse = value;
					RaisePropertyChanged (() => SelectedParticipantCourse);
					if (value != null) {
						OnParticipantCourseSelected ();
					}
				}

			}
			get { 
				return _SelectedParticipantCourse;
			}
		}

		private ActivityViewModel _ParticipantSelectedActivity;

		public ActivityViewModel ParticipantSelectedActivity {

			set { 
				if (_ParticipantSelectedActivity != value) {
					_ParticipantSelectedActivity = value;
					RaisePropertyChanged (() => ParticipantSelectedActivity);
					if (value != null)
					if (ParticipantSelectedActivity.Status == 1) {
						OnParticipantActivitySelected ();
					} else {
						ParticipantSelectedActivity = null;
					}
				}
			}
			get { 
				return _ParticipantSelectedActivity;
			}
		}

		private string _SearchText;

		public string SearchText {
			set { 
				if (Set (() => SearchText, ref _SearchText, value)) {
					if (SearchText.Length >= 3) {
						DoSearch ();
					} else {
						if (ManagerCourseList.Count != RawManagerCourseList.Count)
							ManagerCourseList = new ObservableCollection<CourseViewModel> (RawManagerCourseList);
						if (ManagerActivityList.Count != RawManagerActivityList.Count)
							ManagerActivityList = new ObservableCollection<ActivityViewModel> (RawManagerActivityList);

						if (ParticipantCourseList.Count != RawParticipantCourseList.Count)
							ParticipantCourseList = new ObservableCollection<CourseViewModel> (RawParticipantCourseList);
						if (ParticipantActivityList.Count != RawParticipantActivityList.Count)
							ParticipantActivityList = new ObservableCollection<ActivityViewModel> (RawParticipantActivityList);
					}
				}
			}
			get { 
				return _SearchText;
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

		private RelayCommand<string> _SegmentSelectionCmd;
		public RelayCommand<string> SegmentSelectionCmd{
			get{
				return _SegmentSelectionCmd ?? (_SegmentSelectionCmd = new RelayCommand<string> ((selection) => {
					if (selection.Equals ("TEAM")) {
						IsTeam = true;
					} else {
						IsMe = true;
					}
				}));
			}
		}

		public ManagerHomeViewModel (List<Course> courseList)
		{
			GetCourseViewModelList (courseList);
			IsTeam = true;
		}


		public void LaunchActivity(string courseId, string activityId)
		{
			foreach (var activity in ParticipantActivityList)
			{
				if (activity.ActivityId.Equals(activityId) && activity.CourseId.Equals(courseId))
				{
					ParticipantSelectedActivity = activity;
				}
			}
		}

		public void OnManagerActivitySelected ()
		{
			SelectedActivity = null;
		}

		private async void OnParticipantActivitySelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				if (ParticipantSelectedActivity.ActivityName.Contains ("Training Feedback")) {
				await CourseHandler.GetAssessmentList (ParticipantSelectedActivity.CourseId, ParticipantSelectedActivity.ActivityId, ParticipantSelectedActivity.ActivityName,
					(responseAssessment) => {
						//Success callback
						Debug.WriteLine ("Success" + responseAssessment.QuestionList);
						AssessmentPage _AssessmentAttemptPage = new AssessmentPage ();
						_AssessmentAttemptPage.BindingContext = new AssessmentAttemptViewModel (ParticipantSelectedActivity, responseAssessment.QuestionList);
						NavigationHandler.GlobalNavigator.Navigation.PushModalAsync(_AssessmentAttemptPage);
							ParticipantSelectedActivity=null;
						IsBusy = false;
					},
					(errorResponseAssessment) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
							ParticipantSelectedActivity = null;
						IsBusy = false;
					}
				);
				} else {
					ParticipantSelectedActivity = null;
					IsBusy = false;
				}
			}
		}

		private List<string> ReporteeList = new List<string> ();

		private async void OnManagerCourseSelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				await ReportHandler.GetReporteeList (App.UserName, SelectedCourse.CourseId,
					async (responseReporteeList) => {
						Debug.WriteLine ("Success" + responseReporteeList.Data);

						foreach (Reportee reportee in responseReporteeList.Data.ReportList) {
							ReporteeList.Add (reportee.UserName);
						}

						await CourseHandler.GetActivityCompletedReport (App.UserName, SelectedCourse.CourseId, ReporteeList,
							(responseActivityCompleted) => {
								Debug.WriteLine ("Success" + responseActivityCompleted.ParticipantInfo);
								if(SelectedCourse !=null){
								ManagerCourseDetailPage _managerCourseDetail = new ManagerCourseDetailPage ();
								_managerCourseDetail.BindingContext = new ManagerCourseDetailViewModel (SelectedCourse, responseReporteeList.Data.ReportList, responseActivityCompleted.ParticipantInfo.ActivityData [0].ActivityList);
								NavigationHandler.GlobalNavigator.Navigation.PushAsync (_managerCourseDetail);
								}
								SelectedCourse = null;
								IsBusy = false;
							},
							(errorActivityCompleted) => {
								NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
								SelectedCourse = null;
								IsBusy = false;
							});
					},
					(errorResponseReporteeList) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					}
				);
			}
		}

		private async void OnParticipantCourseSelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				ParticipantCourseDetailPage _ParticipantCourseDetailPage = new ParticipantCourseDetailPage ();
				_ParticipantCourseDetailPage.BindingContext = new ParticipantCourseDetailViewModel (SelectedParticipantCourse);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ParticipantCourseDetailPage);
				SelectedCourse = null;
				IsBusy = false;
			} else {
				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}


//		public void OnSegmentSelected ()
//		{
//			if (IsHome) {
//				_managerHomePage.ShowMe ();
//			} else {
//			}
//		}

		private async void GetCourseViewModelList (List<Course> courseList)
		{
			foreach (var course in courseList) {
				CourseViewModel courseViewModel = new CourseViewModel (course);
				if (courseViewModel.IsInManagerRole ()) {
					RawManagerCourseList.Add (courseViewModel);
					GetActivityViewModelList (course.ActivityList, course.CourseId, course.CourseFullName, true);
				}

				if (courseViewModel.IsInParticipantRole ()) {
					RawParticipantCourseList.Add (courseViewModel);
					GetActivityViewModelList (course.ActivityList, course.CourseId, course.CourseFullName, false);
				}
			}

			ParticipantCourseList = new ObservableCollection<CourseViewModel>(RawParticipantCourseList);
			ManagerCourseList = new ObservableCollection<CourseViewModel> (RawManagerCourseList);
			ParticipantActivityList = new ObservableCollection<ActivityViewModel> (RawParticipantActivityList);
			ManagerActivityList = new ObservableCollection<ActivityViewModel> (RawManagerActivityList);

		}

		private void GetActivityViewModelList (List<Activity> activityList, string courseId, string courseName, bool isManagerRole)
		{
			foreach (var activity in activityList) {
				ActivityViewModel activityViewModel = new ActivityViewModel (activity);
				activityViewModel.CourseId = courseId;
				activityViewModel.CourseName = courseName;
				if (isManagerRole)
					RawManagerActivityList.Add (activityViewModel);
				else
					RawParticipantActivityList.Add (activityViewModel);
			}
		}


		public void DoSearch ()
		{
			ManagerCourseList = new ObservableCollection<CourseViewModel> (RawManagerCourseList.FindAll ((vm) => { 
				return vm.CourseFullName.Contains (SearchText);
			}
			));
			ManagerActivityList = new ObservableCollection<ActivityViewModel> (RawManagerActivityList.FindAll ((obj) => { 
				return obj.ActivityName.Contains (SearchText);
			}							
			));
			ParticipantCourseList = new ObservableCollection<CourseViewModel> (RawParticipantCourseList.FindAll ((vm) => { 
				return vm.CourseFullName.Contains (SearchText);
			}
			));
			ParticipantActivityList = new ObservableCollection<ActivityViewModel> (RawParticipantActivityList.FindAll ((obj) => { 
				return obj.ActivityName.Contains (SearchText);
			}							
			));
		}
	}
}

