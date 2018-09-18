using System;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Ipa
{
	public class CourseViewModel: ViewModelBase
	{

		private Course _Course;

		public string CourseFullName{
			get{ 
				return _Course.CourseFullName;
			}
		}
		public string CourseAttendanceName{
			get{ 
				return "Mark Attendance for " + CourseFullName;
			}
		}
		public string CourseShortName{
			get{ 
				return _Course.CourseShortName;
			}
		}

		public string CourseId{
			get{ 
				return _Course.CourseId;
			}
		}

		public string StartDate {
			get {
				return _Course.StartDate;
			}
		}
		public DateTime Startdate {
			get {
				return DateTime.Parse (StartDate);
			}
		}

		public DateTime Currentdate {
			get {
				return DateTime.Parse (App.CurrentDate);
			}
		}
		public DateTime EndDate {
			get {
				return _Course.EndDate;
			}
		}

		public int[] RoleId {
			get {
				return _Course.RoleId;
			}
		}

		public string TotalParticipant{
			get{ 
				if (_Course.ParticipantCount != null)
					return string.Format ("{0} Participants", _Course.ParticipantCount);
				else
					return "-- Participants";				
			}
		}

		public string TotalReportee{
			get{ 
				if (_Course.ReporteeCount != null)
					return string.Format ("{0} Reportees", _Course.ReporteeCount);
				else
					return "-- Reportees";
			}
		}
		public string ReporteeCount{
			get{ 
				return _Course.ReporteeCount;
			}
		}
		public string ParticipantCount {
			get {
				return _Course.ParticipantCount;
			}
		}

		public List<Activity> ActivityList{
			get{
				return _Course.ActivityList;
			}
		}
	
		public ImageSource TimeSource {
			get { 
				TimeSpan time =Date.Subtract (DateTime.Parse(App.CurrentDate));

				if (time.Days == 0 && time.Hours > 0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days > 0 && time.Hours > 0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days < 0) {
					return ImageSource.FromFile ("completed.png");
				} else if (time.Days == 0 && time.Hours == 0) {
					return ImageSource.FromFile ("completed.png");
				}else{
					return ImageSource.FromFile("ongoing.png");
				}	
			}
		}
	
		public string ClassDate {
			get {
				return  DateTime.Parse(App.CurrentDate).ToString ("dd MMM");
			}
		}
			
		public string Classday{
			get{
				TimeSpan time = DateTime.Parse(App.CurrentDate).Subtract (Startdate);
				return "day"+ (time.Days+1);
			}
		}

		public ImageSource TimeImage {
			get {
				TimeSpan time = Date.Subtract (DateTime.Parse(App.CurrentDate));

				if (time.Days == 0 && time.Hours > 0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days > 0 && time.Hours >0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days < 0) {
					return ImageSource.FromFile ("completed.png");
				} else if (time.Days == 0 && time.Hours == 0) {
					return ImageSource.FromFile ("completed.png");
				}else{
					return ImageSource.FromFile("ongoing.png");
				}	
			}
		}
		public DateTime Date
		{
			get{
				return EndDate.AddDays(120);
			}
		}

//		private List<Course> _CourseList;
//		public List<Course> CourseList{
//			set{ 
//				if(Set (() => CourseList, ref _CourseList, value))
//					RaisePropertyChanged(()=> CourseList);
//			}
//			get{ 
//				return _CourseList;
//			}
//		}
		public string CourseStatus {
			get { 
				TimeSpan time = Date.Subtract (DateTime.Parse(App.CurrentDate));

				if (time.Days == 0 && time.Hours < 0) {
					return "Ongoing";
				} else if (time.Days > 0) {
					return "Ongoing";
				} else if (time.Days < 0) {
					return "Completed";
				} else if (time.Days == 0 && time.Hours == 0) {
					return "Completed";
				}else{
					return "false";
				}	
			}
		}
			
		public CourseViewModel(Course course){
			this._Course = course;
		}
		public string Status{
			get{
				TimeSpan time = DateTime.Parse(App.CurrentDate).Subtract (EndDate);
				if (time.Days == 0 && time.Hours < 0) {
					return "Ongoing";
				} else if (time.Days < 0) {
					return "Ongoing";
				} else if (time.Days > 0) {
					return "Completed";
				} else if (time.Hours > 0) {
					return "Ongoing";
				} else if (time.Days == 0 && time.Hours == 0) {
					return "Completed";
				}else{
					return "false";
				}	
			}
		}
		public ImageSource TimeStatus {
			get { 
				TimeSpan time = DateTime.Parse(App.CurrentDate).Subtract (EndDate);

				if (time.Days == 0 && time.Hours < 0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days <0 && time.Hours < 0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days > 0) {
					return ImageSource.FromFile ("completed.png");
				} else if (time.Days == 0 && time.Hours == 0) {
					return ImageSource.FromFile ("completed.png");
				}else{
					return ImageSource.FromFile("ongoing.png");
				}	
			}
		}
		public ImageSource Time {
			get {
				TimeSpan time = DateTime.Parse(App.CurrentDate).Subtract (EndDate);

				if (time.Days == 0 && time.Hours < 0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days < 0 && time.Hours < 0) {
					return ImageSource.FromFile ("ongoing.png");
				} else if (time.Days >0) {
					return ImageSource.FromFile ("completed.png");
				} else if (time.Days == 0 && time.Hours == 0) {
					return ImageSource.FromFile ("completed.png");
				}else{
					return ImageSource.FromFile("ongoing.png");
				}	
			}
		}


		public bool IsInManagerRole(){
			for (int i = 0; i < this.RoleId.Length; i++) {
				if (RoleId [i] == 2)
					return true;
			}
			return false;
		}

		public bool IsInParticipantRole(){
			for (int i = 0; i < this.RoleId.Length; i++) {
				if (RoleId [i] == 1)
					return true;
			}
			return false;
		}
	}
}

