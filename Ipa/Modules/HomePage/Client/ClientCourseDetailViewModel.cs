using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Plugin.Connectivity;
using System.Diagnostics;

namespace Ipa
{
	public class ClientCourseDetailViewModel : ViewModelBase
	{
		CourseViewModel _SelectedCourse;

		ClientCourseDetailPage _clientCourseDetailPage = new ClientCourseDetailPage();

		public ClientCourseDetailViewModel (CourseViewModel selectedCourse,List<Reportee> participantList,List<AttendanceDetail> attendanceList)
		{
			this._SelectedCourse = selectedCourse;
			GetParticipantViewModelList (participantList);
			GetAttendanceViewModelList (attendanceList, selectedCourse, participantList);
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
		private ObservableCollection<AttendanceListItemViewModel> _AttendanceList;
		public ObservableCollection<AttendanceListItemViewModel> AttendanceList{
			set{ 
				if(Set(()=> AttendanceList, ref _AttendanceList, value)){
					RaisePropertyChanged(()=> AttendanceList);
				}
			}
			get{ 
				return _AttendanceList ?? (_AttendanceList = new ObservableCollection<AttendanceListItemViewModel> ());
			}
		}
		private ParticipantData _ParticipantData;

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
	
		public string CourseFullName{
			get{ 
				return _SelectedCourse.CourseFullName;
			}
		}

		public string CourseID {
			get {
				return _SelectedCourse.CourseId;
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

		public string TotalParticipant{
			get{ 
				if (_SelectedCourse.ParticipantCount != null)
					return string.Format ("PARTICIPANTS ({0})",_SelectedCourse.ParticipantCount);
				else
					return "--";
			}
		}

		private bool _IsOverView;

		public bool IsOverView {
			set { 
				if (Set (() => IsOverView, ref _IsOverView, value)) {
					RaisePropertyChanged (()=>IsOverView);
					if (IsAttendance == IsOverView)
						IsAttendance = !IsOverView;
				}
			}
			get { 
				return _IsOverView;
			}
		}

		private bool _IsAttendance;
		public bool IsAttendance{
			set{ 
				if (Set (()=> IsAttendance, ref _IsAttendance, value)) {
					RaisePropertyChanged (()=>IsAttendance);
					if (IsOverView == IsAttendance)
						IsOverView = !IsAttendance;
				}
			}
			get{ 
				return _IsAttendance;
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
		private AttendanceListItemViewModel _selectedItem;
		public AttendanceListItemViewModel SelectedItem{
			set{ 
				_selectedItem = value;
				RaisePropertyChanged (() => SelectedItem);
				if (value != null) {
					OnAttendanceListItemSelected ();
				}
			}
			get { 
				return _selectedItem;
			}
		}

		public void OnAttendanceListItemSelected()
		{
			ClientCourseDetailAttendanceLookupPage _AttendanceLookupPage = new ClientCourseDetailAttendanceLookupPage ();
			_AttendanceLookupPage.BindingContext = new ClientAttendanceLookupViewModel (SelectedItem);
			NavigationHandler.GlobalNavigator.Navigation.PushAsync (_AttendanceLookupPage);
		}

		private RelayCommand<string> _SegmentSelectionCmd;
		public RelayCommand<string> SegmentSelectionCmd{
			get{
				return _SegmentSelectionCmd ?? (_SegmentSelectionCmd = new RelayCommand<string> ((selection) => {
					if (selection.Equals ("ATTENDANCE")) {
						IsAttendance = true;
					} else {
						IsOverView = true;
					}
				}));
			}
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
		private async void GetAttendanceViewModelList(List<AttendanceDetail> attendanceList,CourseViewModel selectedcourse,List<Reportee> participantList){

			ObservableCollection<AttendanceListItemViewModel> attendanceListItem= new ObservableCollection<AttendanceListItemViewModel> ();
			foreach (var attendance in attendanceList) {
				AttendanceListItemViewModel attendanceViewModel = new AttendanceListItemViewModel (attendance);
				attendanceViewModel.ParticipantList = participantList;
				attendanceViewModel.CourseId=selectedcourse.CourseId;
				attendanceViewModel.StartDate = selectedcourse.StartDate;
				attendanceListItem.Add (attendanceViewModel);
			}
			AttendanceList = attendanceListItem;
		}
	}
}

