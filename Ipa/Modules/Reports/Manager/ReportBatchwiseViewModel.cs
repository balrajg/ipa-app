using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public class ReportBatchwiseViewModel : ViewModelBase
	{
		private ReporteeViewModel SelectedReport;
		private static string _Default_Placeholder = "--";

		public ReportBatchwiseViewModel (ReporteeViewModel selectedReport)
		{
			this.SelectedReport = selectedReport;
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

		private RelayCommand _BackBtnCmd;

		public RelayCommand BackBtnCmd {
			get { 
				return _BackBtnCmd ?? (_BackBtnCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
				}));
			}
		}

		public string ParticipantName {
			get {
				return SelectedReport.FullName;
			}
		}

		public string L1FeedbackScore {
			get {
				if (SelectedReport.L1FeedBackScore!=null)
					return string.Format ("{0}%", SelectedReport.L1FeedBackScore);
				else
					return ReportBatchwiseViewModel._Default_Placeholder;
			}
		}

		public string ClassParticipationScore {
			get {
				if (SelectedReport.CpScore!=null)
					return string.Format ("{0}%", SelectedReport.L1FeedBackScore);
				else
					return ReportBatchwiseViewModel._Default_Placeholder;
			}
		}

		public string L2SkillAssessment {
			get {
				if (SelectedReport.L2SChangeOnPotential!=null)
					return string.Format ("{0}%", SelectedReport.L2SChangeOnPotential);
				else
					return ReportBatchwiseViewModel._Default_Placeholder;
			}
		}

		public string LapScore {
			get {
				if (SelectedReport.LapScore!=null)
					return string.Format ("{0}%", SelectedReport.LapScore);
				else
					return ReportBatchwiseViewModel._Default_Placeholder;
			}
		}

		public string L2BeliefPostScore {
			get {
				if (SelectedReport.L2BeliefPostScore!=null)
					return string.Format ("{0}%", SelectedReport.L2BeliefPostScore);
				else
					return ReportBatchwiseViewModel._Default_Placeholder;
			}
		}
	}
}


