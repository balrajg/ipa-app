using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Connectivity;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public class ClientHomeViewModel : ViewModelBase
	{
		public ClientHomeViewModel (List<Course> courseList)
		{
			GetCourseViewModelList (courseList);

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

		private List<ActivityViewModel> _RawActivityList = new List<ActivityViewModel> ();

		public List<ActivityViewModel> RawActivityList {
			set { 
				_RawActivityList = value;
			}
			get {

				return _RawActivityList;
			}
		}

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

		private ObservableCollection<ActivityViewModel> _ActivityList;

		public ObservableCollection<ActivityViewModel> ActivityList {
			set { 
				if (Set (() => ActivityList, ref _ActivityList, value)) {
					RaisePropertyChanged (() => ActivityList);
				}
			}
			get { 
				return _ActivityList ?? (_ActivityList = new ObservableCollection<ActivityViewModel> ());
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
							ActivityList = new ObservableCollection<ActivityViewModel> (RawActivityList);
					}
				}
			}
			get { 
				return _SearchText;
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

		private CourseViewModel _SelectedCourse;

		public CourseViewModel SelectedCourse {
			set { 
				if (SelectedCourse != value) {
					RaisePropertyChanged (() => SelectedCourse);
					_SelectedCourse = value;
					if (value != null)
					if (SelectedCourse.CourseStatus.Contains ("Ongoing")) {
						OnCourseSelected ();
					} else {
						this.SelectedCourse = null;
					}
				}
			}
			get { 
				return _SelectedCourse;
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

		private void OnCourseSelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				ReportHandler.GetParticipantList (App.UserName, SelectedCourse.CourseId,
					(responseParticipantList) => {
						// Success CallBack
						Debug.WriteLine ("Success" + responseParticipantList.Data);
						AttendanceHandler.GetAttendance (SelectedCourse.CourseId,
							(responseAttendance) => {
								// Success CallBack
								Debug.WriteLine ("Success" + responseAttendance.AttendanceData);
								ClientCourseDetailPage _clientCourseDetail = new ClientCourseDetailPage ();
								_clientCourseDetail.BindingContext=new ClientCourseDetailViewModel(SelectedCourse,responseParticipantList.Data.ReportList,responseAttendance.AttendanceData.AttendanceList);
								NavigationHandler.GlobalNavigator.Navigation.PushAsync (_clientCourseDetail);	
								SelectedCourse = null;
								IsBusy = false;
							},
							(errorAttendance) => {
								NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
								IsBusy = false;
							}
						);
					},
					(errorResponseParticipantList) => {
						//Error CallBack
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						SelectedCourse = null;
						IsBusy = false;
					}
				);
			}
		}

		private async void GetCourseViewModelList (List<Course> courseList)
		{
			foreach (var course in courseList) {
				CourseViewModel courseViewModel = new CourseViewModel (course);
				RawCourseList.Add (courseViewModel);
				GetActivityViewModelList (course.ActivityList);
			}
			CourseList = new ObservableCollection<CourseViewModel> (RawCourseList);
			ActivityList = new ObservableCollection<ActivityViewModel> (RawActivityList);
		}

		private void GetActivityViewModelList (List<Activity> activityList)
		{

			foreach (var activity in activityList) {
				ActivityViewModel activityViewModel = new ActivityViewModel (activity);
				RawActivityList.Add (activityViewModel);
			}
		}

		public void DoFilter ()
		{
			FilterPage _ClientFilterPage = new FilterPage ();
			_ClientFilterPage.BindingContext = this;
			NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ClientFilterPage);
		}

		public void DoSearch ()
		{
			CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
				return vm.CourseFullName.Contains (SearchText);
			}
			));
		}

		public void DoApply ()
		{
			if (IsAllSelected) {
				CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
					return vm.CourseFullName.Contains (vm.CourseFullName);
				}
				));
//				CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
//					return vm.CourseStatus.Contains ("Completed");
//				}
//				));
				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			}else if (IsOngoingSelected) {
				CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
					return vm.CourseStatus.Contains ("Ongoing");
				}
				));
				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			} else if (IsCompletedSelected) {
				CourseList = new ObservableCollection<CourseViewModel> (RawCourseList.FindAll ((vm) => { 
					return vm.CourseStatus.Contains ("Completed");
				}
				));
				NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
			} 
		}
	}
}

