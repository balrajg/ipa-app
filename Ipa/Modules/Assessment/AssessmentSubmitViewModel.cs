using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ipa
{
	public class AssessmentSubmitViewModel : ViewModelBase
	{
		private AssessmentData _AssessmentData;
		private ActivityViewModel _SelectedActivity;
		public AssessmentSubmitViewModel (ActivityViewModel selectedActivity,ObservableCollection<AssessmentViewModel> QuestionList)
		{
			this._SelectedActivity = selectedActivity;
			AssessmentQuestionList = QuestionList;
		}
		private ObservableCollection<AssessmentViewModel> _AssessmentQuestionList;

		public ObservableCollection<AssessmentViewModel> AssessmentQuestionList {
			set { 
				if (Set (() => AssessmentQuestionList, ref _AssessmentQuestionList, value)) {
					RaisePropertyChanged (() => AssessmentQuestionList);
				}
			}
			get { 
				return _AssessmentQuestionList ?? (_AssessmentQuestionList = new ObservableCollection<AssessmentViewModel> ());
			}
		}
		public string ActivityName {
			get {
				return _SelectedActivity.ActivityName;
			}
		}

		public string ActivityId {
			get {
				return _SelectedActivity.ActivityId;
			}
		}
		public string CourseId {
			get {
				return _SelectedActivity.CourseId;
			}
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

		private RelayCommand _SubmitCmd;

		public RelayCommand SubmitCmd {
			get { 
				return _SubmitCmd ?? (_SubmitCmd = new RelayCommand (() => {
					DoSubmit();
				}));
			}
		}
		private RelayCommand _ReviewCmd;

		public RelayCommand ReviewCmd {
			get { 
				return _ReviewCmd ?? (_ReviewCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopModalAsync();
				}));
			}
		}
		private RelayCommand _CloseBtnCmd;

		public RelayCommand CloseBtnCmd {
			get { 
				return _CloseBtnCmd ?? (_CloseBtnCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopModalAsync();
				}));
			}
		}
		public async void DoSubmit()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				_AssessmentData = new AssessmentData ();
				_AssessmentData.CourseId = _SelectedActivity.CourseId;
				_AssessmentData.UserName = App.UserName;
				_AssessmentData.ActivityID = _SelectedActivity.ActivityId;
				_AssessmentData.ActivityName = _SelectedActivity.ActivityName;
				_AssessmentData.AnswerList=new List<Result> ();
				foreach (AssessmentViewModel vm in AssessmentQuestionList) {
					_AssessmentData.AnswerList.Add (new Result (){ 
						Answer =vm.Answer ,
						QuestionID = vm.Id
					});
				}

				CourseHandler.GetSubmitAssessment (_AssessmentData,
					(responseSubmitAssessment) => {
						Debug.WriteLine ("Success" + responseSubmitAssessment.ResponseCode + "/nMessage:" +responseSubmitAssessment.Status);
				        MessagingCenter.Send<AssessmentSubmitViewModel>(this, "AssessmentCompleted");
						MessagingCenter.Send<AssessmentSubmitViewModel>(this, "ActivityCompleted");
						NavigationHandler.GlobalNavigator.Navigation.PopModalAsync (true);
						NavigationHandler.GlobalNavigator.Navigation.PopModalAsync (true);
						NavigationHandler.GlobalNavigator.Navigation.PopModalAsync (false);
						IsBusy = false;
					},
					(errorSubmitAssessment) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					});
			}
		}
	}
}


