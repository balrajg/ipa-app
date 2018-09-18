using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System.Diagnostics;

namespace Ipa
{
	public class PartnerAttendanceLookupViewModel : ViewModelBase
	{
		private AttendanceDetail _AttendanceDetail;
		private AttendanceListItemViewModel _SelectedItem;
		private CourseViewModel _SelectedCourse;

		public PartnerAttendanceLookupViewModel (CourseViewModel selectedCourse, AttendanceListItemViewModel selectedItem)
		{
			this._SelectedCourse = selectedCourse;
			this._SelectedItem = selectedItem;
			this._AttendanceDetail = selectedItem._AttendanceDetail;
			GetReporteeAttendanceItemList (selectedItem.ParticipantList);
		}

		private ObservableCollection<ReporteeViewModel> _ReporteePresent;

		public ObservableCollection<ReporteeViewModel> ReporteePresent {
			set { 
				if (Set (() => ReporteePresent, ref _ReporteePresent, value)) {
					RaisePropertyChanged (() => ReporteePresent);
				}
			}
			get { 
				return _ReporteePresent ?? (ReporteePresent = new ObservableCollection<ReporteeViewModel> ());
			}
		}

		private ObservableCollection<ReporteeViewModel> _ReporteeAbsent;

		public ObservableCollection<ReporteeViewModel> ReporteeAbsent {
			set { 
				if (Set (() => ReporteeAbsent, ref _ReporteeAbsent, value)) {
					RaisePropertyChanged (() => ReporteeAbsent);
				}
			}
			get { 
				return _ReporteeAbsent ?? (_ReporteeAbsent = new ObservableCollection<ReporteeViewModel> ());
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

		public string CourseID {
			get {
				return _SelectedItem.CourseId;
			}
		}

		public string CourseDay {
			get {
				return _SelectedItem.ClassDay;
			}
		}

		public string CourseDate {
			get {
				return _SelectedItem.ClassDate;
			}
		}

		public string TotalPresent {
			get {
				return string.Format ("PRESENT ({0})", _SelectedItem.PresentList.Count);
			}
		}

		public string TotalAbsent {
			get {
				return string.Format ("ABSENT ({0})", _SelectedItem.AbsentList.Count);
			}
		}

		public bool CanShowPresent {
			get {
				return _SelectedItem.CanShowPresent;
			}
		}

		public bool CanShowAbsent {
			get { 
				return _SelectedItem.CanShowAbsent;
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

//		private RelayCommand _EditCmd;
//
//		public RelayCommand EditCmd {
//			get { 
//				return _EditCmd ?? (_EditCmd = new RelayCommand (() => {
//					DoEdit ();
//				}));
//			}
//		}
//
//		public void DoEdit ()
//		{
//			if (CrossConnectivity.Current.IsConnected) { 
//				IsBusy = true;
//				AttendanceHandler.GetAttendance (_SelectedCourse.CourseId,
//					(responseAttendance) => {
//						Debug.WriteLine ("Success" + responseAttendance.AttendanceData);
//						MarkAttendancePage _MarkAttendancePage = new MarkAttendancePage ();
//						_MarkAttendancePage.BindingContext = new MarkAttendanceItemViewModel (_SelectedCourse, _SelectedItem.ParticipantList);
//						NavigationHandler.GlobalNavigator.Navigation.PushAsync (_MarkAttendancePage);
//						IsBusy = false;
//
//					},
//					(errorAttendance) => {
//						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
//						IsBusy = false;
//					});
//			
//			} else {
//				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
//			}
//		}

		public void GetReporteeAttendanceItemList (List<Reportee> reporteeList)
		{
			foreach (var reportee in reporteeList) {
				ReporteeViewModel reporteeViewModel = new ReporteeViewModel (reportee);
				if ((_SelectedItem.AbsentList != null) && _SelectedItem.AbsentList.Exists (s => s.Equals (reportee.UserName))) {
					ReporteeAbsent.Add (reporteeViewModel);
				} else if ((_SelectedItem.PresentList != null) && _SelectedItem.PresentList.Exists (s => s.Equals (reportee.UserName))) {
					ReporteePresent.Add (reporteeViewModel);
				}
			}
		}
	}
}


