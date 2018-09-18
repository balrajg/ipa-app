using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using Plugin.Connectivity;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Ipa
{
	public class MarkAttendanceItemViewModel: ViewModelBase
	{
		private MarkAttendance _MarkAttendance;
		private CourseViewModel _SelectedActivity;
		private List<Reportee> _reporteeList;

		public MarkAttendanceItemViewModel (CourseViewModel selectedActivity, List<Reportee> reporteeList)
		{
			this._SelectedActivity = selectedActivity;
			GetReporteeViewModelList (reporteeList,selectedActivity.CourseId);
			this._reporteeList = reporteeList;
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

		private string CourseID {
			get {
				return _SelectedActivity.CourseId;
			}
		}

		public string ClassDate {
			get {
				return _SelectedActivity.ClassDate;
			}
		}
		public string ClassDay {
			get {
				return _SelectedActivity.Classday;
			}
		}

		private ReporteeViewModel _SelectedMarkAttendanceItem;

		public ReporteeViewModel SelectedMarkAttendanceItem {
			set {
				if (null == value)
				{
					_SelectedMarkAttendanceItem = null;
					RaisePropertyChanged("SelectedMarkAttendanceItem");
					return;
				}

				if (_SelectedActivity.EndDate.ToString("d").Equals( DateTime.Parse(App.CurrentDate).ToString("d"))) {
					_SelectedMarkAttendanceItem = value;
					RaisePropertyChanged (() => SelectedMarkAttendanceItem);
					if (value != null) {
						OnSelectedMarkAttendanceItem ();
					}
				}else{
					SelectedMarkAttendanceItem = null;
				}
			}
			get {
				return _SelectedMarkAttendanceItem;
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

		private RelayCommand _BackCmd;

		public RelayCommand BackCmd {
			get { 
				return _BackCmd ?? (_BackCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
				}));
			}
		}

		private RelayCommand _DoneCmd;

		public RelayCommand DoneCmd {
			get { 
				return _DoneCmd ?? (_DoneCmd = new RelayCommand (() => {
					UpdateAttendance ();
				}));
			}
		}

		public async void OnSelectedMarkAttendanceItem ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
					ReportHandler.GetParticipantRatingQuestion (
					(response) => {
						Debug.WriteLine ("Success" + response.QuestionInfo.QuestionData);
//					App.RatingQuesion = response.QuestionInfo.QuestionData;
						RateParticipantPage _RateParticipantPage=new RateParticipantPage();
						_RateParticipantPage.BindingContext = new RateParticipantViewModel (SelectedMarkAttendanceItem, response.QuestionInfo.QuestionData);//App.RatingQuesion);
						NavigationHandler.GlobalNavigator.Navigation.PushAsync (_RateParticipantPage);
						SelectedMarkAttendanceItem=null;
						IsBusy = false;
					},
					(errorResponse) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						SelectedMarkAttendanceItem=null;
						IsBusy = false;
					});
			}	
		}

		public async void UpdateAttendance ()
		{
			if (this.IsAttendanceFinished ()) {
				if (CrossConnectivity.Current.IsConnected) { 
					IsBusy = true;

					_MarkAttendance = new MarkAttendance ();
					_MarkAttendance.CourseId = _SelectedActivity.CourseId;
					_MarkAttendance.AttendanceList = new List<AttendanceDetail> ();

					List<string> presentList = new List<string> ();
					List<string> absentList = new List<string> ();
					foreach (ReporteeViewModel vm in ReporteeList) {
						if (vm.IsPresent)
							presentList.Add (vm.UserName);
						else
							absentList.Add (vm.UserName);
					}
					AttendanceDetail attDetails = new AttendanceDetail () {
						Date = ClassDay,
						PresentList = presentList,
						AbsentList = absentList
					};

					_MarkAttendance.AttendanceList.Add (attDetails);
					await AttendanceHandler.GetMarkAttendance (_MarkAttendance,
						(responseMarkAttendance) => {
							Debug.WriteLine ("Success" + responseMarkAttendance.ResponseCode);
							AttendanceHandler.GetAttendance (_SelectedActivity.CourseId,
								(responseAttendance) => {
									Debug.WriteLine ("Success" + responseAttendance.AttendanceData);
									PartnerCourseDetailPage _CourseDetailPage=new PartnerCourseDetailPage();
											_CourseDetailPage.BindingContext=new PartnerCourseDetailViewModel(_SelectedActivity,_reporteeList,responseAttendance.AttendanceData.AttendanceList,responseAttendance.AttendanceData);
									NavigationHandler.GlobalNavigator.Navigation.PushAsync(_CourseDetailPage);
									IsBusy = false;
								},
								(errorAttendance) => {
									NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
									IsBusy = false;
								});
					
						},
						(errorResponseMarkAttendance) => {
							NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
							IsBusy = false;
						});
				} else {
					NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
				}
			}
		}

		private bool IsAttendanceFinished(){
			if (ReporteeList == null) 
				return false;

				foreach (ReporteeViewModel vm in ReporteeList) {
					if (!vm.IsAbsent && !vm.IsPresent)
					return false;
				}

			return true;
		}

		private void GetReporteeViewModelList (List<Reportee> reporteeList,string courseID)
		{
			ObservableCollection<ReporteeViewModel> reporteeListItem = new ObservableCollection<ReporteeViewModel> ();
			foreach (var report in reporteeList) {
				ReporteeViewModel reporteeViewModel = new ReporteeViewModel (report);
				reporteeViewModel.CourseID = courseID;
				reporteeListItem.Add (reporteeViewModel);
			}
			ReporteeList = reporteeListItem;
		}
	}
}

