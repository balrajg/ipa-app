using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;

namespace Ipa
{
	public class ProgramReportListViewModel : ViewModelBase
	{
		private ProgramReport _ProgramReport;

		public ProgramReportListViewModel (ProgramReport programReport)
		{
			this._ProgramReport = programReport;
		}
			
		public string AttendancePercent {
			get { 
				return (string.IsNullOrEmpty (_ProgramReport.Attendance)) ? "--" :string.Format ("{0}%", _ProgramReport.Attendance);
			}
		}
			
		public string CourseName {
			get { 
				return _ProgramReport.CourseName;
			}
		}
		public string L1score {
			get { 
				return (string.IsNullOrEmpty (_ProgramReport.L1score))? null: _ProgramReport.L1score;
			}
		}
			
		public string Lapscore {
			get { 
				return (string.IsNullOrEmpty (_ProgramReport.Lapscore))? null: _ProgramReport.Lapscore;
			}
		}
			
		public string Postscore {
			get { 
				return (string.IsNullOrEmpty (_ProgramReport.Postscore))? null: _ProgramReport.Postscore;
			}
		}

		public string PrescoreValue {
			get { 
				return (string.IsNullOrEmpty (_ProgramReport.Prescore))? null: _ProgramReport.Prescore;
			}
		}

	}
}


