using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public class AttendanceViewModel : ViewModelBase
	{
		private Attendance _Attendance;
		public AttendanceViewModel (Attendance attendance)
		{
			this._Attendance = attendance;
		}
		public bool CanEdit {
			get {
				return _Attendance.CanEdit;
			}
		}
		public string CurrentTime {
			get {
				return _Attendance.CurrentTime;
			}
		}

//		public List<AttendanceDetail> AttendanceList {
//			get {
//				_Attendance.AttendanceList;
//			}
//		}
	}
}


