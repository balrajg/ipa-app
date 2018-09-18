using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Ipa
{
	public class ParticipantHomeViewModel : ViewModelBase
	{
		private List<CourseViewModel> _RawCourseList = new List<CourseViewModel>();
		public List<CourseViewModel> RawCourseList{
			set { 
				_RawCourseList = value;
			}
			get{
				return _RawCourseList;
			}
		}

		private List<ActivityViewModel> _RawActivityList = new List<ActivityViewModel>();
		public List<ActivityViewModel> RawActivityList{
			set{ 
				_RawActivityList = value;
			}
			get{
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
						if(CourseList.Count != RawCourseList.Count)
							CourseList=new ObservableCollection<CourseViewModel>(RawCourseList);
						if (ActivityList.Count != RawActivityList.Count)
							ActivityList = new ObservableCollection<ActivityViewModel> (RawActivityList);
					}
				}
			}
			get { 
				return _SearchText;
			}
		}

		private CourseViewModel _SelectedCourse;
		public CourseViewModel SelectedCourse {
			set { 
				_SelectedCourse = value;
				RaisePropertyChanged (() => SelectedCourse);
				if (value != null)
					OnCourseSelected ();
			}
			get { 
				return _SelectedCourse;
			}
		}

		private ActivityViewModel _SelectedActivity;
		public ActivityViewModel SelectedActivity {
			set {
				if (_SelectedActivity == value)
				{
					return;
				}

				_SelectedActivity = value;
				RaisePropertyChanged ("SelectedActivity");
				if (value != null)
				{
					if (SelectedActivity.Status == 1)
					{
						OnActivitySelected();
					}
					else {
						_SelectedActivity = null;
					}
				}
			}
			get { 
				return _SelectedActivity;
			}
		}

		public ParticipantHomeViewModel (List<Course> courseList, string courseId = null, string activityId = null)
		{
			GetCourseViewModelList (courseList);
			MessagingCenter.Subscribe<AssessmentSubmitViewModel> (this, "AssessmentCompleted", (sender) => {

				Debug.WriteLine("Status changed");
				foreach ( var activity in RawActivityList){
					if(activity.ActivityId.Equals(sender.ActivityId) && activity.CourseId.Equals(sender.CourseId))
					{
						activity.Status = 3;
						break;
					}
				}
				ActivityList = new ObservableCollection<ActivityViewModel>(RawActivityList);
			});

			if (!string.IsNullOrEmpty(courseId) && !string.IsNullOrEmpty(activityId))
			{
				//Lunch assessment from notification. 
				LaunchActivity(courseId, activityId);
			}

		}

		public void LaunchActivity(string courseId, string activityId)
		{
			foreach (var activity in ActivityList)
			{
				if (activity.ActivityId.Equals(activityId) && activity.CourseId.Equals(courseId))
				{
					SelectedActivity = activity;
					break;
				}
			}
		}

		private async void OnActivitySelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				if (SelectedActivity.ActivityName.Contains ("Training Feedback")) {
					await CourseHandler.GetAssessmentList (SelectedActivity.CourseId, SelectedActivity.ActivityId, SelectedActivity.ActivityName,
						(responseAssessment) => {
							//Success callback
							Debug.WriteLine ("Success" + responseAssessment.QuestionList);
							var selActivity = SelectedActivity;
							AssessmentPage _AssessmentAttemptPage = new AssessmentPage ();
							Device.BeginInvokeOnMainThread(() => 
							{
								NavigationHandler.GlobalNavigator.Navigation.PushModalAsync (_AssessmentAttemptPage);
								_AssessmentAttemptPage.BindingContext = new AssessmentAttemptViewModel (selActivity, responseAssessment.QuestionList);
							});
							SelectedActivity = null;
							IsBusy = false;
						},
						(errorResponseAssessment) => {
							//Error callback
							NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
							SelectedActivity = null;
							IsBusy = false;
						});
				} else {
					SelectedActivity = null;
					IsBusy = false;
				}
			}
		}

		private async void OnCourseSelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				ParticipantCourseDetailPage _ParticipantCourseDetailPage = new ParticipantCourseDetailPage ();
				_ParticipantCourseDetailPage.BindingContext = new ParticipantCourseDetailViewModel (SelectedCourse);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ParticipantCourseDetailPage);
				SelectedCourse = null;
				IsBusy = false;
			} else {
				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private async void GetCourseViewModelList (List<Course> courseList)
		{
			foreach (var course in courseList) {
				CourseViewModel courseViewModel = new CourseViewModel (course);
				RawCourseList.Add (courseViewModel);
				GetActivityViewModelList (course.ActivityList, course.CourseId, course.CourseFullName);
			}
			CourseList = new ObservableCollection<CourseViewModel>(RawCourseList);
			ActivityList =  new ObservableCollection<ActivityViewModel>(RawActivityList);
		}
	
		private void GetActivityViewModelList (List<Activity> activityList, string courseId, string courseName)
		{
			foreach (var activity in activityList) {
				ActivityViewModel activityViewModel = new ActivityViewModel (activity);
				activityViewModel.CourseId = courseId;
				activityViewModel.CourseName = courseName;
				RawActivityList.Add (activityViewModel);
			}
		}

		public void DoSearch ()
		{
			CourseList = new ObservableCollection<CourseViewModel>( RawCourseList.FindAll ((vm)=>{ 
				return vm.CourseFullName.Contains(SearchText);
			}
			));
			ActivityList = new ObservableCollection<ActivityViewModel>( RawActivityList.FindAll ((obj)=>{ 
				return obj.ActivityName.Contains(SearchText);
			}							
			));
		}
	}
}

