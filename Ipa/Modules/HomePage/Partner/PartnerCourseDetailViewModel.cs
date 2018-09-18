using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Plugin.Connectivity;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;

namespace Ipa
{
	public class PartnerCourseDetailViewModel : ViewModelBase
	{
		private CourseViewModel _SelectedCourse;
		private Attendance _AttendanceData;
		private List<AttendanceDetail> _attendanceList;
		private List<Course> _courseList;

		public PartnerCourseDetailViewModel (CourseViewModel selectedCourse, List<Reportee> participantList, List<AttendanceDetail> attendanceList, Attendance AttendanceData)
		{
			this._AttendanceData = AttendanceData;
			this._SelectedCourse = selectedCourse;
			GetParticipantViewModelList (participantList);
			GetAttendanceViewModelList (attendanceList, selectedCourse, participantList, AttendanceData);
			this._attendanceList = attendanceList;
			IsOverView = true;
		}

		private ObservableCollection<ReporteeViewModel> _ParticipantList;
		public ObservableCollection<ReporteeViewModel> ParticipantList{
			set{ 
				if(Set(()=> ParticipantList, ref _ParticipantList, value)){
					RaisePropertyChanged(()=> ParticipantList);
				}
			}
			get{ 
				return _ParticipantList ?? (_ParticipantList = new ObservableCollection<ReporteeViewModel> ());
			}
		}

		public string CourseFullName {
			get {
				return _SelectedCourse.CourseFullName;
			}
		}

		public string CourseStatus {
			get {
				return _SelectedCourse.Status;
			}
		}

		public ImageSource TimeSource {
			get {
				return _SelectedCourse.Time;
			}
		}

		private bool _IsBusy;

		public bool IsBusy {
			set { 
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					RaisePropertyChanged (() => IsBusy);
				}
			}
			get { 
				return _IsBusy;
			}
		}


		private bool _IsOverView;

		public bool IsOverView {
			set { 
				if (Set (() => IsOverView, ref _IsOverView, value)) {
					RaisePropertyChanged (() => IsOverView);
					if (IsAttendance == IsOverView)
						IsAttendance = !IsOverView;
				}
			}
			get { 
				return _IsOverView;
			}
		}

		private bool _IsAttendance;

		public bool IsAttendance {
			set { 
				if (Set (() => IsAttendance, ref _IsAttendance, value)) {
					RaisePropertyChanged (() => IsAttendance);
					if (IsOverView == IsAttendance)
						IsOverView = !IsAttendance;
				}
			}
			get { 
				return _IsAttendance;
			}
		}

		public string TotalParticipant {
			get { 
				if (_SelectedCourse.ParticipantCount != null)
					return string.Format ("PARTICIPANTS ({0})", _SelectedCourse.ParticipantCount);
				else
					return "--";
			}
		}


		private ObservableCollection<AttendanceListItemViewModel> _AttendanceList;

		public ObservableCollection<AttendanceListItemViewModel> AttendanceList {
			set { 
				if (Set (() => AttendanceList, ref _AttendanceList, value)) {
					RaisePropertyChanged (() => AttendanceList);
				}
			}
			get { 
				return _AttendanceList ?? (_AttendanceList = new ObservableCollection<AttendanceListItemViewModel> ());
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
		private RelayCommand _BackCmd;

		public RelayCommand BackCmd {
			get { 
				return _BackCmd ?? (_BackCmd = new RelayCommand (() => {
					DoBack();
				}));
			}
		}
		private RelayCommand _AddUserCmd;

		public RelayCommand AddUserCmd {
			get { 
				return _AddUserCmd ?? (_AddUserCmd = new RelayCommand (() => {
					DoAddUser ();
				}));
			}
		}

		private RelayCommand _MarkItNowCmd;

		public RelayCommand MarkItNowCmd {
			get { 
				return _MarkItNowCmd ?? (_MarkItNowCmd = new RelayCommand (() => {
					MarkAttendanceNow ();
				}));
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
		private AttendanceListItemViewModel _SelectedItem;

		public AttendanceListItemViewModel SelectedItem {
			set { 
				_SelectedItem = value;
				RaisePropertyChanged (() => SelectedItem);
				if (value != null) {
					OnAttendanceListItemSelected ();
				}
			}
			get { 
				return _SelectedItem;
			}
		}

		private RelayCommand<string> _SegmentSelectionCmd;

		public RelayCommand<string> SegmentSelectionCmd {
			get {
				return _SegmentSelectionCmd ?? (_SegmentSelectionCmd = new RelayCommand<string> ((selection) => {
					if (selection.Equals ("ATTENDANCE")) {
						IsAttendance = true;
					} else {
						IsOverView = true;
					}
				}));
			}
		}
		public void DoBack()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				NavigationHandler.GlobalNavigator.PopAsync ();
				IsBusy = false;
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
		public async void MarkAttendanceNow ()
		{
			
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;

				MarkAttendancePage _MarkAttendancePage = new MarkAttendancePage ();
				_MarkAttendancePage.BindingContext = new MarkAttendanceItemViewModel (_SelectedCourse, SelectedItem.ParticipantList);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_MarkAttendancePage);
						IsBusy = false;

					
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		public async void OnAttendanceListItemSelected ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				PartnerAttendanceLookupPage _PartnerAttendanceLookupPage = new PartnerAttendanceLookupPage ();
				_PartnerAttendanceLookupPage.BindingContext = new PartnerAttendanceLookupViewModel (_SelectedCourse, SelectedItem);						
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_PartnerAttendanceLookupPage);
				SelectedItem = null;
				IsBusy = false;
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private void GetAttendanceViewModelList (List<AttendanceDetail> attendanceList, CourseViewModel SelectedCourse, List<Reportee> participantList, Attendance attendanceData)
		{

			ObservableCollection<AttendanceListItemViewModel> attendanceListItem = new ObservableCollection<AttendanceListItemViewModel> ();
			foreach (var attendance in attendanceList) {
				AttendanceListItemViewModel attendanceViewModel = new AttendanceListItemViewModel (attendance);
				attendanceViewModel.ParticipantList = participantList;
				attendanceViewModel.StartDate = SelectedCourse.StartDate;
				attendanceViewModel.CourseId = SelectedCourse.CourseId;
				attendanceViewModel.CanEdit = attendanceData.CanEdit;
				if (attendanceViewModel.CanEdit == true) {
					attendanceList.Last ();
					attendanceViewModel.MarkItNowCmd = new RelayCommand (() => {
						MarkAttendanceNow ();
					});
				} else {
					attendanceViewModel.CanEdit = false;
				}

				attendanceListItem.Add (attendanceViewModel);
			}
			AttendanceList = attendanceListItem;
		}

		public void DoAddUser ()
		{
			AddUserPage _AddUser = new AddUserPage ();
			_AddUser.BindingContext = new AddUserViewModel (this._SelectedCourse.CourseId);
			NavigationHandler.GlobalNavigator.Navigation.PushAsync (_AddUser);
		}

		private void GetParticipantViewModelList(List<Reportee> participantList)
		{
			ObservableCollection<ReporteeViewModel> participantListItem = new ObservableCollection<ReporteeViewModel> ();
			foreach (var participant in participantList) {
				ReporteeViewModel participantViewModel = new ReporteeViewModel (participant);
				participantListItem.Add (participantViewModel);
			}
			ParticipantList = participantListItem;
		}
	}
}


