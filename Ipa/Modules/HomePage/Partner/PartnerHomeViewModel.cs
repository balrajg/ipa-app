using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Plugin.Connectivity;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Ipa
{
	public class PartnerHomeViewModel : ViewModelBase
	{
		private ObservableCollection<CourseViewModel> _CourseList;

		public ObservableCollection<CourseViewModel> CourseList {
			set { 
				if (Set (() => CourseList, ref _CourseList, value)) {
					RaisePropertyChanged (() => CourseList);
				}
			}
			get { 
				return _CourseList ?? (_CourseList = new ObservableCollection<CourseViewModel> ());
			}
		}

		private ObservableCollection<CourseViewModel> _TodayCourseList;

		public ObservableCollection<CourseViewModel> TodayCourseList {
			set { 
				if (Set (() => TodayCourseList, ref _TodayCourseList, value)) {
					RaisePropertyChanged (() => TodayCourseList);
				}
			}
			get { 
				return _TodayCourseList ?? (_TodayCourseList = new ObservableCollection<CourseViewModel> ());
			}
		}

		private ObservableCollection<CourseViewModel> _ActivityList;

		public ObservableCollection<CourseViewModel> ActivityList {
			set { 
				if (Set (() => ActivityList, ref _ActivityList, value)) {
					RaisePropertyChanged (() => ActivityList);
				}
			}
			get { 
				return _ActivityList ?? (_ActivityList = new ObservableCollection<CourseViewModel> ());
			}
		}

		private List<CourseViewModel> _RawCourseList = new List<CourseViewModel> ();

		public List<CourseViewModel> RawCourseList {
			set { 
				_RawCourseList = value;
			}
			get {

				return _RawCourseList;
			}
		}

		private List<CourseViewModel> _RawTodayCourseList = new List<CourseViewModel> ();

		public List<CourseViewModel> RawTodayCourseList {
			set { 
				_RawTodayCourseList = value;
			}
			get {

				return _RawTodayCourseList;
			}
		}

		private List<CourseViewModel> _RawActivityList = new List<CourseViewModel> ();

		public List<CourseViewModel> RawActivityList {
			set { 
				_RawActivityList = value;
			}
			get {

				return _RawActivityList;
			}
		}

		private CourseViewModel _SelectedCourse;

		public CourseViewModel SelectedCourse {

			set { 
				if (_SelectedCourse != value) {
					_SelectedCourse = value;
					RaisePropertyChanged (() => SelectedCourse);
					if (value != null)
					if (SelectedCourse.Status == "Ongoing") {
						OnCourseSelected ();
					} else {
						SelectedCourse = null;
					}
				}
			}
			get { 
				return _SelectedCourse;
			}
		}

		private CourseViewModel _SelectedActivity;

		public CourseViewModel SelectedActivity {

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

		private bool _IsAllSelected=true;

		public bool IsAllSelected {
			set {
				if (Set (() => IsAllSelected, ref _IsAllSelected, value)) {
					if (IsAllSelected) {
						IsOngoingSelected = true;
						IsCompletedSelected = true;

					} else {
						IsOngoingSelected = false;
						IsCompletedSelected = false;
					}
					RaisePropertyChanged (() => IsAllSelected);
				}
			}
			get { 
				return _IsAllSelected;
			}
		}

		private bool _IsOngoingSelected=true;

		public bool IsOngoingSelected {
			set {
				if (Set (() => IsOngoingSelected, ref _IsOngoingSelected, value)) {
					if (IsOngoingSelected) {
						IsOngoingSelected = true;
						if (IsCompletedSelected) {
							IsAllSelected = true;
						}
					} else {
						IsAllSelected = false;
					}
					RaisePropertyChanged (() => IsOngoingSelected);
				}
			}
			get { 
				return _IsOngoingSelected;
			}
		}

		private bool _IsCompletedSelected=true;

		public bool IsCompletedSelected {
			set {
				if (Set (() => IsCompletedSelected, ref _IsCompletedSelected, value)) {
					if(IsCompletedSelected){
						IsCompletedSelected = true;
						if (IsOngoingSelected) {
							IsAllSelected = true;
						}
					}else{
						IsAllSelected=false;
					}
					RaisePropertyChanged (() => IsCompletedSelected);
				}
			}
			get { 
				return _IsCompletedSelected;
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

		private RelayCommand _ApplyCmd;

		public RelayCommand ApplyCmd {
			get { 
				return _ApplyCmd ?? (_ApplyCmd = new RelayCommand (() => {
					DoApply ();
				}));
			}
		}

		private string _SearchText;

		public string SearchText {
			set { 
				if (Set (() => SearchText, ref _SearchText, value)) {
					if (SearchText.Length >= 3) {
						DoSearch ();
					} else {
						if (CourseList.Count != RawCourseList.Count)
							CourseList = new ObservableCollection<CourseViewModel> (RawCourseList);
						if (ActivityList.Count != RawActivityList.Count)
							ActivityList = new ObservableCollection<CourseViewModel> (RawActivityList);
						if (TodayCourseList.Count != RawTodayCourseList.Count)
							TodayCourseList = new ObservableCollection<CourseViewModel> (RawTodayCourseList);
					}
				}
			}
			get { 
				return _SearchText;
			}
		}

		private bool _CanShowTodayCourseList;

		public bool CanShowTodayCourseList {
			set {
				if (Set (() => CanShowTodayCourseList, ref _CanShowTodayCourseList, value)) {
					_CanShowTodayCourseList = value;
				}
			}
			get {
				return ((TodayCourseList.Count == 0) ? false : true);
			}
		}

		private bool _CanShowActivityList;

		public bool CanShowActivityList {
			set {
				if (Set (() => CanShowTodayCourseList, ref _CanShowActivityList, value)) {
					_CanShowActivityList = value;
				}
			}
			get {
				return ((ActivityList.Count == 0) ? false : true);
			}
		}

		private bool _CanShowMyClassList;

		public bool CanShowMyClassList {
			set {
				if (Set (() => CanShowMyClassList, ref _CanShowMyClassList, value)) {
					_CanShowMyClassList = value;
				}
			}
			get {
				return ((CourseList.Count == 0) ? false : true);
			}
		}

		private RelayCommand _FilterCmd;

		public RelayCommand FilterCmd {
			get { 
				return _FilterCmd ?? (_FilterCmd = new RelayCommand (() => {
					DoFilter ();
				}));
			}
		}

		public PartnerHomeViewModel (List<Course> courseList, string courseIdToSelect= null)
		{
			GetCourseViewModelList (courseList);
			//LaunchActivity(courseIdToSelect);
		}


		public void LaunchActivity(string courseId) 
		{
			
			if (!string.IsNullOrEmpty(courseId))
			{
				
				foreach (var activity in ActivityList)
				{
					if (activity.CourseId.Equals(courseId))
					{
						//Device.BeginInvokeOnMainThread(() => 
						//{ 
							SelectedActivity = activity;
						//});
						break;
					}
				}
			}

		}

		private async void OnCourseSelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				await ReportHandler.GetParticipantList (App.UserName, SelectedCourse.CourseId,
					(responseParticipantList) => {
						//Success callback
						Debug.WriteLine ("Success" + responseParticipantList.ResponseCode);
						AttendanceHandler.GetAttendance (SelectedCourse.CourseId,
							(responseAttendance) => {
								Debug.WriteLine ("Success" + responseAttendance.AttendanceData);
								PartnerCourseDetailPage _PartnerCourseDetailPage = new PartnerCourseDetailPage ();
								_PartnerCourseDetailPage.BindingContext = new PartnerCourseDetailViewModel (SelectedCourse, responseParticipantList.Data.ReportList, responseAttendance.AttendanceData.AttendanceList,responseAttendance.AttendanceData);
								NavigationHandler.GlobalNavigator.Navigation.PushAsync (_PartnerCourseDetailPage);	
								SelectedCourse = null;
								IsBusy = false;
							},
							(errorAttendance) => {
								NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
								IsBusy = false;
							});
					},
					(errorResponseParticipantList) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						SelectedCourse = null;
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}	
		}

		public async void OnActivitySelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;

				await ReportHandler.GetParticipantList (App.UserName, SelectedActivity.CourseId,
					(responseParticipantList) => {
						if (SelectedActivity != null)
						{
							Debug.WriteLine("Success" + responseParticipantList.Data);

							MarkAttendancePage _MarkAttendancePage = new MarkAttendancePage();
							_MarkAttendancePage.BindingContext = new MarkAttendanceItemViewModel(SelectedActivity, responseParticipantList.Data.ReportList);
							NavigationHandler.GlobalNavigator.Navigation.PushAsync(_MarkAttendancePage);
							SelectedActivity = null;
							IsBusy = false;
						}
					},
					(errorResponseParticipantList) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						SelectedActivity = null;
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}	
		}

		private void GetCourseViewModelList (List<Course> courseList)
		{
			foreach (var course in courseList) {
				CourseViewModel courseViewModel = new CourseViewModel (course);
				if (courseViewModel.Status.Contains ("Ongoing")) {

					RawTodayCourseList.Add (courseViewModel);
					RawActivityList.Add (courseViewModel);
				} else {
					RawCourseList.Add (courseViewModel);
				}
			}
			CourseList = new ObservableCollection<CourseViewModel> (RawCourseList);
			ActivityList = new ObservableCollection<CourseViewModel> (RawActivityList);
			TodayCourseList = new ObservableCollection<CourseViewModel> (RawTodayCourseList);

		}

		public void DoSearch ()
		{
			CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
				return vm.CourseFullName.Contains (SearchText);
			}
			));

			TodayCourseList = new ObservableCollection<CourseViewModel> (RawTodayCourseList.FindAll ((o) => { 
				return o.CourseFullName.Contains (SearchText);
			}							
			));
		}

		public void DoFilter ()
		{
			FilterPage _ParterFilterPage = new FilterPage ();
			_ParterFilterPage.BindingContext = this;
			NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ParterFilterPage);
		}

		public void DoApply ()
		{
			if (IsAllSelected) {
				CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
					return vm.CourseFullName.Contains (vm.CourseFullName);
				}
				));
				TodayCourseList = new ObservableCollection<CourseViewModel> (RawTodayCourseList.FindAll ((o) => { 
					return o.CourseFullName.Contains (o.CourseFullName);
				}							
				));
				ActivityList = new ObservableCollection<CourseViewModel> (RawActivityList.FindAll ((v) => {
					return v.CourseAttendanceName.Contains (v.CourseAttendanceName);
				}
				));
				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			}else if (IsOngoingSelected) {
				CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
					return vm.Status.Contains ("Ongoing");
				}
				));

				TodayCourseList = new ObservableCollection<CourseViewModel> (RawTodayCourseList.FindAll ((o) => { 
					return o.Status.Contains ("Ongoing");
				}							
				));
				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			} else if (IsCompletedSelected) {
				CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
					return vm.Status.Contains ("Completed");
				}
				));
				TodayCourseList = new ObservableCollection<CourseViewModel> (RawTodayCourseList.FindAll ((o) => { 
					return o.Status.Contains ("Completed");
				}							
				));
				ActivityList = new ObservableCollection<CourseViewModel> (RawActivityList.FindAll ((v) => {
					return v.Status.Contains ("Completed");
				}
				));
				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			} 
		}
	}
}

