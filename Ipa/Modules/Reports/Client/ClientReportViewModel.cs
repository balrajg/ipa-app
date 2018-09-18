using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public class ClientReportViewModel : ViewModelBase
	{
		public ClientReportViewModel ()
		{
			Init ();
			SelectedCourseItem = Color.White;
		}
		private ObservableCollection<ProgramReportListViewModel> _ReportList;

		public ObservableCollection<ProgramReportListViewModel> ReportList {
			set { 
				if (Set (() => ReportList, ref _ReportList, value)) {
					RaisePropertyChanged (() => ReportList);
				}
			}
			get { 
				return _ReportList ?? (_ReportList = new ObservableCollection<ProgramReportListViewModel> ());
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
		private RelayCommand _DropDownCmd;

		public RelayCommand DropDownCmd {
			get { 
				return _DropDownCmd ?? (_DropDownCmd = new RelayCommand (() => {
				}));
			}
		}
		private Color _SelectedCourseItem;

		public Color SelectedCourseItem {
			set {
				if (Set (() => SelectedCourseItem, ref _SelectedCourseItem, value)) {
					RaisePropertyChanged (() => SelectedCourseItem);
				}
			}
			get { 
				return _SelectedCourseItem;
			}
		}

		public string SelectedProgramName{
			get{ 
				if (SelectedProgram != null && SelectedProgram.ProgramName != null)
					return SelectedProgram.ProgramName;
				else
					return string.Empty;
			}
		}

		private ProgramListViewModel _SelectedProgram;

		public ProgramListViewModel SelectedProgram {

			set { 
				if (_SelectedProgram != value) {
					_SelectedProgram = value;
					RaisePropertyChanged (() => SelectedProgram);
					if (value != null) {
						OnProgramNameSelected ();
						RaisePropertyChanged ("SelectedCourseItem");
						RaisePropertyChanged ("SelectedProgramName");
					}
				}
			}
			get { 
				return _SelectedProgram;
			}
		}
		private ProgramReportListViewModel _SelectedReport;

		public ProgramReportListViewModel SelectedReport {

			set { 
				_SelectedReport = value;
				RaisePropertyChanged (() => SelectedReport);
				if (value != null) {
					SelectedReport = null;
					}
			}
			get { 
				return _SelectedReport;
			}
		}
		private ObservableCollection<ProgramListViewModel> _ProgramList;

		public ObservableCollection<ProgramListViewModel> ProgramList {
			set { 
				if (Set (() => ProgramList, ref _ProgramList, value)) {
					RaisePropertyChanged (() => ProgramList);
				}
			}
			get { 
				return _ProgramList ?? (_ProgramList = new ObservableCollection<ProgramListViewModel> ());
			}
		}
	
		private async void GetProgramReportViewModelList (List<ProgramReport> programReportList)
		{
			ObservableCollection<ProgramReportListViewModel> programReportItemList = new ObservableCollection<ProgramReportListViewModel> ();
			foreach (var programReport in programReportList) {
				ProgramReportListViewModel programReportViewModel = new ProgramReportListViewModel (programReport);
				programReportItemList.Add (programReportViewModel);
			}
			ReportList = programReportItemList;
		}

		private async void GetProgramViewModelList (List<Program> programList)
		{
			ObservableCollection<ProgramListViewModel> programItemList = new ObservableCollection<ProgramListViewModel> ();
			bool IsDefaultProgramSelected = false;
			foreach (var program in programList) {
				ProgramListViewModel programViewModel = new ProgramListViewModel (program);
				programItemList.Add (programViewModel);
				if (!IsDefaultProgramSelected) {
					SelectedProgram = programViewModel;
					IsDefaultProgramSelected = true;
				}
			}
			ProgramList = programItemList;
		}

		public async void OnProgramNameSelected()
		{
			SelectedCourseItem = Color.Blue;
			FetchProgramReport (SelectedProgram.ProgramId);
		}

		public async Task Init(){

			if (CrossConnectivity.Current.IsConnected) {
				await ReportHandler.GetProgramList(App.UserName,
					(response) => {
						//Success callBack
						Debug.WriteLine ("success:" + response.ProgramReportReponseData.ProgramList);
						this.GetProgramViewModelList(response.ProgramReportReponseData.ProgramList);
						IsBusy = false;
					},
					(errorRespnose) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private async Task FetchProgramReport(string programId){

			if (CrossConnectivity.Current.IsConnected) {
				await ReportHandler.GetProgramReportList(App.UserName,programId,
					(response) => {
						//Success callback
						this.GetProgramReportViewModelList(response.ResponseData.ProgramReportList);
						RaisePropertiesChanged();
					},
					(errorRespnose) => {
						//Error callback
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
//						Debug.WriteLine ("Error:: /nCode: " + errorRespnose.ResponseCode + "/nMessage: " + errorRespnose.Status);
//						RaisePropertiesChanged();
						IsBusy = false;
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
		public void RaisePropertiesChanged(){
			RaisePropertyChanged (() => ReportList);
			RaisePropertyChanged (() => ProgramList);
			RaisePropertyChanged (() => SelectedProgram);
		}
	}
}


