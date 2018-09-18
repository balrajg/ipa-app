using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace Ipa
{
	public class ActivityCompletionViewModel : ViewModelBase
	{
		private ParticipantDetail _ActivityDetail;

		public ActivityCompletionViewModel (ParticipantDetail participantDetail)
		{
			this._ActivityDetail = participantDetail;
		}

		private string _CourseId;
		public string CourseId{
			set{ 
				if(Set (() => CourseId, ref _CourseId, value))
					RaisePropertyChanged(()=> CourseId);
			}
			get{ 
				return _CourseId;
			}
		}

		private string _CourseName;
		public string CourseName{
			set{ 
				if(Set (() => CourseName, ref _CourseName, value))
					RaisePropertyChanged(()=> CourseName);
			}
			get{ 
				return _CourseName;
			}
		}

		public string ActivityName {
			get { 
				return _ActivityDetail.ActivityName;
			}
		}

		public string ActivityID {
			get { 
				return _ActivityDetail.ActivityID;
			}
		}

		public List<string> Completed {
			get { 
				return _ActivityDetail.Completed;
			}
		}

		public List<string> Pending {
			get { 
				return _ActivityDetail.Pending;
			}
		}

		public List<string> OverDue {
			get { 
				return _ActivityDetail.Overdue;
			}
		}

		public string TotalOverDue {
			get { 
				if (_ActivityDetail.Overdue == null)
					return string.Empty;
				return string.Format ("{0} Overdue", _ActivityDetail.Overdue.Count);
			}
		}

		public string TotalCompleted {
			get { 
				if (_ActivityDetail.Completed == null)
					return string.Empty;
				
				return string.Format ("{0} Completed", _ActivityDetail.Completed.Count);
			}
		}

		public string TotalPending {
			get { 
				if (_ActivityDetail.Pending == null)
					return string.Empty;
				
				return string.Format ("{0} Pending", _ActivityDetail.Pending.Count);
			}
		}

		public bool CanShowCompleted {
			get { 
				return ( (_ActivityDetail.Completed == null) || (_ActivityDetail.Completed.Count == 0) ? false : true);
			}
		}

		public bool CanShowOverdue {
			get { 
				return ( (_ActivityDetail.Overdue == null) || (_ActivityDetail.Overdue.Count == 0) ? false : true);
			}
		}

		public bool CanShowPending {
			get { 
				return ( (_ActivityDetail.Pending == null) || (_ActivityDetail.Pending.Count == 0) ? false : true);
			}
		}

	}
}

