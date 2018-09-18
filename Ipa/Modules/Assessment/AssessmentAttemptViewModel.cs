using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Plugin.Connectivity;
using Acr.Settings;

namespace Ipa
{
	public class AssessmentAttemptViewModel : ViewModelBase
	{
		private ActivityViewModel _SelectedActivity;
		private List<AssessmentViewModel> _RawAssessmentList = new List<AssessmentViewModel>();
		public AssessmentAttemptViewModel (ActivityViewModel selectedActivity, List<ReviewQuestion> questionList)
		{			
			this._SelectedActivity = selectedActivity;
			GetQuestionViewModelList (questionList);
		}

		private ObservableCollection<AssessmentViewModel> _QuestionList;

		public ObservableCollection<AssessmentViewModel> QuestionList {
			set { 
				if (Set (() => QuestionList, ref _QuestionList, value)) {
					RaisePropertyChanged (() => QuestionList);
				}
			}
			get { 
				return _QuestionList ?? (_QuestionList = new ObservableCollection<AssessmentViewModel> ());
			}
		}

		public int QuestionCount {
			get {
				return QuestionList.Count;
			}
		}

		private AssessmentViewModel _SelectedItem ;

		public AssessmentViewModel SelectedItem {
			set { 
				_SelectedItem = value;
				if (value != null)
					RaisePropertyChanged (() => SelectedItem);
			}
			get {
				if (QuestionList.Count > 0)
					return _SelectedItem;
				else
					return null;
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
		private bool _IsClose;

		public bool IsClose {
			set { 
				if (Set (() => IsClose, ref _IsClose, value)) {
					_IsClose = value;
				}
			}
			get { 
				return _IsClose;
			}
		}
			
		public string ActivityName {
			get {
				return _SelectedActivity.ActivityName;
			}
		}


		private async void GetQuestionViewModelList (List<ReviewQuestion> questionList)
		{
			Dictionary<string, string> CacheData = CrossSettings.Current.Get<Dictionary<string,string>> (this._SelectedActivity.ActivityId, null);
			int index = 1;
			int totalCount = questionList.Count; 
			foreach (var question in questionList) {
				
				AssessmentViewModel assessmentViewModel = new AssessmentViewModel (question, index, totalCount, this.ActivityName);
				assessmentViewModel.CloseCmd = new RelayCommand (()=>{
					ExitAssessment();
				});
				assessmentViewModel.DoneCmd = new RelayCommand (()=>{
					DoAnswer();
				});
				if (CacheData != null && CacheData.ContainsKey (assessmentViewModel.Id)) {
					string answer;
					if (CacheData.TryGetValue (assessmentViewModel.Id, out answer))
						assessmentViewModel.Answer = answer;
					
				}
				_RawAssessmentList.Add (assessmentViewModel);
				index++;
			}
			QuestionList = new ObservableCollection<AssessmentViewModel>(_RawAssessmentList.FindAll (data => !string.IsNullOrEmpty (data.Answer)));
			GoNext ();
		}

		private void GoNext(){
			if(QuestionList.Count > 0)
				QuestionList [QuestionList.Count - 1].AnsweredCmd = null;
			if (QuestionList.Count == _RawAssessmentList.Count) {
				DoAnswer ();
				foreach (IAssessmentItemData data in QuestionList) {

					((AssessmentViewModel)data).IsDone = true;
				}

			} else {
				AssessmentViewModel nextQuestion = _RawAssessmentList [QuestionList.Count];
				if (nextQuestion.QuestionType == 0) {// fill in the blanks

					foreach (var ques in _RawAssessmentList) {
						if (ques.QuestionType == 0) {
							ques.IsDone = true;
							if (string.IsNullOrEmpty (ques.Answer)) {
								QuestionList.Add (ques);
							}
						}
					}
					SelectedItem = QuestionList [QuestionList.Count - 1];
					RaisePropertyChanged (() => QuestionList);
				} else {
					nextQuestion.AnsweredCmd = new RelayCommand (() => {// multichoice question
						GoNext ();
					});
					QuestionList.Add (nextQuestion);
					RaisePropertyChanged (() => QuestionList);
					SelectedItem = QuestionList [QuestionList.Count - 1];
				}
			}
		}

		public void ExitAssessment(){
//			CrossSettings.Current.Set("IsClose",true);
			MoveToCache();
            //NavigationHandler.GlobalNavigator.Navigation.PopModalAsync (false);
           // NavigationHandler.GlobalNavigator.Navigation.PopAsync();
            NavigationHandler.GlobalNavigator.Navigation.PopModalAsync (false);
		}

		public void MoveToCache(){
			Dictionary <string,string> assessmentData = new Dictionary<string, string> ();
			foreach(IAssessmentItemData data in QuestionList){
				if (!string.IsNullOrEmpty (data.Answer)) {
					assessmentData.Add (((AssessmentViewModel)data).Id, data.Answer);
				} else {
					break;
				}
			}

			if (assessmentData.Count > 0) {
				CrossSettings.Current.Set<Dictionary <string,string>> (this._SelectedActivity.ActivityId, assessmentData);
			}

		}

		public void DoAnswer ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				AssessmentAttemptSummaryPage _AssessmentAttemptSummaryPage = new AssessmentAttemptSummaryPage ();
				_AssessmentAttemptSummaryPage.BindingContext = new AssessmentSubmitViewModel (_SelectedActivity,QuestionList);
				NavigationHandler.GlobalNavigator.Navigation.PushModalAsync (_AssessmentAttemptSummaryPage);
				IsBusy = false;
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
	}
}


