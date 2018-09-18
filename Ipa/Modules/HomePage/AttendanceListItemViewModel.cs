using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public class AttendanceListItemViewModel : ViewModelBase
	{
		public AttendanceDetail _AttendanceDetail
		{private set; get; }
		public AttendanceListItemViewModel(AttendanceDetail attendanceDetail){
			_AttendanceDetail = attendanceDetail;
		}

		private List<Reportee> _ParticipantList;
		public List<Reportee> ParticipantList{
			set{ 
				if(Set (() => ParticipantList, ref _ParticipantList, value))
					RaisePropertyChanged(()=> ParticipantList);
			}
			get{ 
				return _ParticipantList;
			}
		}
			
		private string _CourseId;
		public string CourseId {
			set { 
				if (Set (() => CourseId, ref _CourseId, value))
					RaisePropertyChanged (() => CourseId);
			}
			get { 
				return _CourseId;
			}
		}

		private string _StartDate;
		public string StartDate{
			set{ 
				if(Set (() => StartDate, ref _StartDate, value))
					RaisePropertyChanged(()=> StartDate);
			}
			get{ 
				return _StartDate;
			}
		}

		private bool _CanEdit;
		public bool CanEdit{
			set{ 
				if(Set (() => CanEdit, ref _CanEdit, value))
					RaisePropertyChanged(()=> CanEdit);
			}
			get{ 
				return _CanEdit;
			}
		}

		public string TotalPresent{
			get{ 
					return string.Format ("{0} Present", _AttendanceDetail.PresentList.Count);
			}
		}

		public bool CanShowPresent{
			get{
					return ((_AttendanceDetail.PresentList.Count == 0) ? false : true);
			}
		}

		public string TotalAbsent{
			get{ 
					return string.Format ("{0} Absent", _AttendanceDetail.AbsentList.Count);
			}
		}

		public bool CanShowAbsent{
			get{ 
					return ((_AttendanceDetail.AbsentList.Count == 0) ? false : true);
			}
		}

		public List<string> AbsentList{
			get{
				return _AttendanceDetail.AbsentList;
				}
		}

		public List<string> PresentList {
			get {
				return _AttendanceDetail.PresentList;
			}
		}

	
		public string ClassDate {
			get {
				int dayToAdd = 0;
				int.TryParse (ClassDay.Substring (ClassDay.Length - 1), out dayToAdd);
				DateTime attendanceDate;
				DateTime.TryParse (StartDate, out attendanceDate);

				if (attendanceDate != null && dayToAdd > 0) {
					return attendanceDate.AddDays (dayToAdd - 1).ToString ("dd MMM");
				} else {
					return string.Empty;
				}
			}
		}
		private RelayCommand _MarkItNowCmd;
		public RelayCommand MarkItNowCmd{
			get{
				return _MarkItNowCmd;
			}
			set{
				_MarkItNowCmd = value;
			}
		}
		public string ClassDay {
			get {
				return _AttendanceDetail.Date;
			}
		}
	}
}


