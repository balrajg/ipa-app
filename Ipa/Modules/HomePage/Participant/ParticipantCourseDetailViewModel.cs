using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace Ipa
{
	public class ParticipantCourseDetailViewModel : ViewModelBase
	{
		private CourseViewModel _SelectedCourse;

		private ObservableCollection<ActivityViewModel> _PendingActivity;
		public ObservableCollection<ActivityViewModel> PendingActivity{
			set{ 
				if(Set(()=> PendingActivity, ref _PendingActivity, value)){
					RaisePropertyChanged(()=> PendingActivity);
				}
			}
			get{ 
				return _PendingActivity ?? (_PendingActivity = new ObservableCollection<ActivityViewModel> ());
			}
		}

		private ObservableCollection<ActivityViewModel> _CompletedActivity;
		public ObservableCollection<ActivityViewModel> CompletedActivity{
			set{ 
				if(Set(()=> CompletedActivity, ref _CompletedActivity, value)){
					RaisePropertyChanged(()=> CompletedActivity);
				}
			}
			get{ 
				return _CompletedActivity ?? (_CompletedActivity = new ObservableCollection<ActivityViewModel> ());
			}
		}

		private ObservableCollection<ActivityViewModel> _OverDueActivity;
		public ObservableCollection<ActivityViewModel> OverDueActivity{
			set{ 
				if(Set(()=> OverDueActivity, ref _OverDueActivity, value)){
					RaisePropertyChanged(()=> OverDueActivity);
				}
			}
			get{ 
				return _OverDueActivity ?? (_OverDueActivity = new ObservableCollection<ActivityViewModel> ());
			}
		}

		public string CourseFullName {
			get {
				return _SelectedCourse.CourseFullName;
			}
		}

		public string CourseStatus{
			get{
				return _SelectedCourse.CourseStatus;
				}
		}

		public ImageSource CourseSource{
			get{
				return _SelectedCourse.TimeImage;
			}
		}

		public ParticipantCourseDetailViewModel (CourseViewModel selectedCourse)
		{
			
			this._SelectedCourse = selectedCourse;
			GetActivityViewModelList(this._SelectedCourse.ActivityList,selectedCourse.CourseId);

			MessagingCenter.Subscribe<AssessmentSubmitViewModel> (this, "ActivityCompleted", (sender) => {
				foreach ( var activity in PendingActivity){
					if(activity.ActivityId.Equals(sender.ActivityId) && activity.CourseId.Equals(sender.CourseId))
					{
						activity.Status = 3;
						PendingActivity.Remove(activity);
						CompletedActivity.Add(activity);
						break;
					}
				}
				RaisePropertyChanged("CanShowPending");
				RaisePropertyChanged("CanShowCompleted");
				RaisePropertyChanged(()=> CompletedActivity);
				RaisePropertyChanged(() => PendingActivity);
			});
		}

		private bool _IsBusy;
		public bool IsBusy{
			set{ 
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					_IsBusy = value;
				}
			}
			get{ 
				return _IsBusy;
			}
		}

		private bool _CanShowPending;
		public bool CanShowPending {
			set {
				if (Set (() => CanShowPending, ref _CanShowPending, value)) {
					_CanShowPending = value;
				}
			}
			get {
				return ((PendingActivity.Count == 0) ? false : true);
			}
		}

		private bool _CanShowCompleted;
		public bool CanShowCompleted {
			set {
				if (Set (() => CanShowCompleted, ref _CanShowCompleted, value)) {
					_CanShowCompleted = value;
				}
			}
			get {
				return ((CompletedActivity.Count == 0) ? false : true);

			}
		}

		private bool _CanShowOverDue;
		public bool CanShowOverDue {
			set {
				if (Set (() => CanShowOverDue, ref _CanShowOverDue, value)) {
					_CanShowOverDue = value;
				}
			}
			get {
				return ((OverDueActivity.Count == 0) ? false : true);
			}
		}

		private RelayCommand _BackBtnCmd;

		public RelayCommand BackBtnCmd {
			get { 
				return _BackBtnCmd ?? (_BackBtnCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync();
				}));
			}
		}
		private ActivityViewModel _SelectedCompletedActivity;
		public ActivityViewModel SelectedCompletedActivity {

			set{ 
				_SelectedCompletedActivity = value;
				RaisePropertyChanged (() => SelectedCompletedActivity);
				if (value != null)
					SelectedCompletedActivity = null;
			}
			get{ 
				return _SelectedCompletedActivity;
			}
		}

		private ActivityViewModel _SelectedActivity;
		public ActivityViewModel SelectedActivity {

			set{ 
				_SelectedActivity = value;
				RaisePropertyChanged (() => SelectedActivity);
				if (value != null)
					OnActivitySelected ();
			}
			get{ 
				return _SelectedActivity;
			}
		}

		public async void OnActivitySelected()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				if (SelectedActivity.ActivityName.Contains ("Training Feedback")) {
				await CourseHandler.GetAssessmentList (_SelectedCourse.CourseId,SelectedActivity.ActivityId, SelectedActivity.ActivityName,
					(responseAssessment) => {
						//Success callback
						Debug.WriteLine ("Success" + responseAssessment.QuestionList);
						AssessmentPage _AssessmentAttemptPage = new AssessmentPage ();
						NavigationHandler.GlobalNavigator.Navigation.PushModalAsync (_AssessmentAttemptPage);
						_AssessmentAttemptPage.BindingContext = new AssessmentAttemptViewModel (SelectedActivity, responseAssessment.QuestionList);
						SelectedActivity=null;
						IsBusy = false;
					},
					(errorResponseAssessment) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						SelectedActivity=null;
						IsBusy = false;
					});
				} else {
					SelectedActivity = null;
					IsBusy = false;
				}
			}
		}

		private void GetActivityViewModelList(List<Activity> activityList,string courseId){
			foreach (var activity in activityList) {
				ActivityViewModel activityViewModel = new ActivityViewModel (activity);
				activityViewModel.CourseId = courseId;
				if (activity.Status == 1) {
					PendingActivity.Add (activityViewModel);
				} else if (activity.Status == 2) {
					OverDueActivity.Add (activityViewModel);
				} else if (activity.Status == 3) {
					CompletedActivity.Add (activityViewModel);
				}
			}
		}
	}
}


