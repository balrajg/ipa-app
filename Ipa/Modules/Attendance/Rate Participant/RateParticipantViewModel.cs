using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ipa
{
	public class RateParticipantViewModel : ViewModelBase
	{
		private ParticipantRating _ParticipantRating;
		ReporteeViewModel _SelectedReportee;

		public RateParticipantViewModel (ReporteeViewModel selectedReportee,List<RateQuestion> questionList)
		{
			this._SelectedReportee = selectedReportee;
			GetQuestionListViewModel (questionList);
		}
			
		private ObservableCollection<QuestionListViewModel> _RatingQuestionList;

		public ObservableCollection<QuestionListViewModel> RatingQuestionList {
			set { 
				if (Set (() => RatingQuestionList, ref _RatingQuestionList, value)) {
					RaisePropertyChanged (() => RatingQuestionList);
				}
			}
			get { 
				return _RatingQuestionList ?? (_RatingQuestionList = new ObservableCollection<QuestionListViewModel> ());
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

		public string FullName {
			get {
				return _SelectedReportee.FullName;
			}
		}
			
		private QuestionListViewModel _SelectedRateReportee;

		public QuestionListViewModel SelectedRateReportee {

			set { 
				_SelectedRateReportee = value;
				RaisePropertyChanged (() => SelectedRateReportee);
				if (value != null)
					SelectedRateReportee = null;
			}
			get { 
				return _SelectedRateReportee;
			}
		}

		private RelayCommand _BackCmd;

		public RelayCommand BackCmd {
			get { 
				return _BackCmd ?? (_BackCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync();
				}));
			}
		}

		private RelayCommand _DoneCmd;

		public RelayCommand DoneCmd {
			get { 
				return _DoneCmd ?? (_DoneCmd = new RelayCommand (() => {
					UpdateRateParticipant();
				}));
			}
		}
		public void UpdateRateParticipant()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				_ParticipantRating = new ParticipantRating ();
				_ParticipantRating.CourseId = _SelectedReportee.CourseID;
				_ParticipantRating.Rating = new List<RatingAnswer> ();
				_ParticipantRating.UserName = App.UserName;

				foreach (QuestionListViewModel vm in RatingQuestionList) {
					_ParticipantRating.Rating.Add (new RatingAnswer (){ 
						AnswerText = vm.Answer,
						QuestionID = vm.QuestionID
					});
				}

				ReportHandler.GetRateParticipant(_ParticipantRating,
					(responseParticipantRate) => {
						Debug.WriteLine ("Success" + responseParticipantRate.ResponseCode);
						NavigationHandler.GlobalNavigator.Navigation.PopAsync();
						IsBusy = false;
					},
					(errorResponseParticipantRate) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					});
			}	
		}
		private async void GetQuestionListViewModel (List<RateQuestion> rateQuestionList)
		{
			ObservableCollection<QuestionListViewModel> rateQuestionListItem= new ObservableCollection<QuestionListViewModel> ();
			foreach (var question in rateQuestionList) {
				QuestionListViewModel questionViewModel = new QuestionListViewModel (question);
				rateQuestionListItem.Add (questionViewModel);
			}
			RatingQuestionList = rateQuestionListItem;
		}
	}
}


