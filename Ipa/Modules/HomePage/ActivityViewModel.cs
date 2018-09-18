using System;
using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace Ipa
{
	public class ActivityViewModel : ViewModelBase
	{
		private Activity _Activity;

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

		public string ActivityName {
			get { 
				return _Activity.ActivityName;
			}
		}

		public int ActionId {
			get { 
				return _Activity.ActionId;
			}
		}

		public string ActivityId {
			get { 
				return _Activity.ActivityId;
			}
		}

		public DateTime ExpectedDate {
			get { 
				return _Activity.ExpectedDate;
			}
		}

		public DateTime CompletedDate {
			get { 
				return _Activity.CompletedDate;
			}
		}


		public ImageSource TimeSource {
			get { 
				TimeSpan time1 = (CurrentDate).Subtract (ExpectedDate);
				if (Status == 1) {
					return ImageSource.FromFile ("pending.png");
				} else if (Status == 2) {
					if (time1.Days == 0) {
						return ImageSource.FromFile ("pending.png");
					}else {
					return ImageSource.FromFile ("over_due.png");
					}
				} else if (Status == 3) {
					return  ImageSource.FromFile ("completed.png");
				} else {
					return ImageSource.FromFile ("ongoing.png");
				}
			}

		}

		public DateTime CurrentDate {
			get {
				return DateTime.Parse (App.CurrentDate);
			}
		}

		public string TimeDescription {
			get {


				if (3 == Status)
				{
					return string.Format("Submitted on " + CompletedDate.ToString("MMM dd")); //"Submitted on " + CompletedDate.ToString("MMM dd");
					//} else if (time.Days > 0) {
					//	return time.Days.ToString () + " " + "Days left";
				}
				else if (2 == Status)
				{
					TimeSpan time1 = (CurrentDate).Subtract(ExpectedDate);
					if (time1.Days >= 7)
					{
						return string.Format("Overdue on {0}", ExpectedDate.ToString("MMM dd")); //"Overdue on " + ExpectedDate.ToString("MMM dd");
					}
					else 
					{
						return string.Format( "Overdue by {0} {1}" , time1.Days+1, (time1.Days == 0)? "Day": "Days") ;
					}

				}
				else if (1 == Status)
				{
					TimeSpan time = (ExpectedDate).Subtract(CurrentDate);
					if (0 < time.Days)
					{
						return string.Format("{0} {1} left", time.Days, (1 == time.Days) ? "Day" : "Days");//time.Days.ToString() + " Days left";
					}
					else if (0 == time.Days && 0 != time.Hours)
					{
						return string.Format("{0} {1} left",time.Hours, (1== time.Hours)? "Hour": "Hours");// time.Hours + " Hours left";
					}
					else
					{
						return string.Format("{0} {1} left", time.Minutes, (1 == time.Minutes) ? "Minute" : "Minutes");//time.Minutes + " Minutes left";
					}
				}
				else {
					return "--";
				}

				//else if (time.Days == 0 && time.Hours < 24 ) {
				//	return time.ToString (@"h\:mm\:ss");
				//} else {
				//	return " -- ";
				//}
			}
		}
		public bool ActivityNameEnabled {
			get {
				if (ActivityName.Contains("Training Feedback")) {
					return false;
				} else {
					return true;
				}
			}
		}
		public int Status {
			get { 
				return _Activity.Status;
			}
			set{
				_Activity.Status = value;
			}
		}

		public bool PendingStatus {
			get {
				if (Status != 1) {
					return true;
				} else {
					return false;
				}
			}
		}
		public bool OverDueStatus {
			get {
				if (Status == 2) {
					return true;
				} else {
					return false;
				}
			}
		}
		public bool CompletedStatus {
			get {
				if (Status == 3) {
					return true;
				} else {
					return false;
				}
			}
		}
		public ActivityViewModel (Activity activity)
		{
			this._Activity = activity;
		}
	}
}


