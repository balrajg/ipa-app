using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ipa
{
	public class ManagerCourseDetailActivityViewModel : ViewModelBase
	{
		private ActivityCompletionViewModel _SelectedActivity;

		private ObservableCollection<ReporteeViewModel> _ReporteeCompleted;
		public ObservableCollection<ReporteeViewModel> ReporteeCompleted{
			set{ 
				if(Set(()=> ReporteeCompleted, ref _ReporteeCompleted, value)){
					RaisePropertyChanged(()=> ReporteeCompleted);
				}
			}
			get{ 
				return _ReporteeCompleted ?? (_ReporteeCompleted = new ObservableCollection<ReporteeViewModel> ());
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

		private ObservableCollection<ReporteeViewModel> _ReporteePending;
		public ObservableCollection<ReporteeViewModel> ReporteePending{
			set{ 
				if(Set(()=> ReporteePending, ref _ReporteePending, value)){
					RaisePropertyChanged(()=> ReporteePending);
				}
			}
			get{ 
				return _ReporteePending ?? (_ReporteePending = new ObservableCollection<ReporteeViewModel> ());
			}
		}

		private ObservableCollection<ReporteeViewModel> _ReporteeOverDue;
		public ObservableCollection<ReporteeViewModel> ReporteeOverDue{
			set{ 
				if(Set(()=> ReporteeOverDue, ref _ReporteeOverDue, value)){
					RaisePropertyChanged(()=> ReporteeOverDue);
				}
			}
			get{ 
				return _ReporteeOverDue ?? (_ReporteeOverDue = new ObservableCollection<ReporteeViewModel> ());
			}
		}

		public string ActivityName {
			get {
				return _SelectedActivity.ActivityName;
				}
		}

		public bool CanShowCompleted {
			get {
				return _SelectedActivity.CanShowCompleted;
			}
		}

		public bool CanShowOverdue {
			get {
				return _SelectedActivity.CanShowOverdue;
			}
		}

		public bool CanShowPending {
			get {
				return _SelectedActivity.CanShowPending;
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
		public ManagerCourseDetailActivityViewModel (ActivityCompletionViewModel selectedActivity,List<Reportee> reportee)
		{
			this._SelectedActivity = selectedActivity;
			GetReporteeViewModelList (reportee);
		}

		private RelayCommand _BackBtnCmd;

		public RelayCommand BackBtnCmd {
			get { 
				return _BackBtnCmd ?? (_BackBtnCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
				}));
			}
		}

		public void GetReporteeViewModelList (List<Reportee> reporteeList)
		{
			foreach (var reportee in reporteeList) {
				ReporteeViewModel reporteeViewModel = new ReporteeViewModel (reportee);
				if ((_SelectedActivity.Completed != null) && _SelectedActivity.Completed.Exists (s => s.Equals (reportee.UserName))) {
					ReporteeCompleted.Add (reporteeViewModel);
				} else if ((_SelectedActivity.Pending != null) && _SelectedActivity.Pending.Exists (s => s.Equals (reportee.UserName))) {
					ReporteePending.Add (reporteeViewModel);
				} else if ((_SelectedActivity.OverDue != null) && _SelectedActivity.OverDue.Exists (s => s.Equals (reportee.UserName))) {
					ReporteeOverDue.Add (reporteeViewModel);
				} 
			}
		}
	}
}


