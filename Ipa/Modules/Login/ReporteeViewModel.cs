using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Diagnostics;

namespace Ipa
{
	public class ReporteeViewModel : ViewModelBase
	{
		private Reportee _Reportee;
		private static string _Default_Placeholder = "--";

		public ReporteeViewModel (Reportee reportee){
			this._Reportee = reportee;
		}

		private string _L2BChangeOnPotential;
		public string L2BChangeOnPotential{
			set{ 
				if(Set (() => L2BChangeOnPotential, ref _L2BChangeOnPotential, value))
					RaisePropertyChanged(()=> L2BChangeOnPotential);
			}
			get{ 
				return _L2BChangeOnPotential;
			}
		}
		public string L2SkillAssessment {
			get {
				if (L2SChangeOnPotential!=null)
					return string.Format ("{0}%", L2SChangeOnPotential);
				else
					return ReporteeViewModel._Default_Placeholder;
			}
		}

		private string _L1FeedBackScore;
		public string L1FeedBackScore{
			set{ 
				if(Set (() => L1FeedBackScore, ref _L1FeedBackScore, value))
					RaisePropertyChanged(()=> L1FeedBackScore);
			}
			get{ 
				return _L1FeedBackScore;
			}
		}
		public string FeedBackScore {
			get {
				if (L1FeedBackScore!=null)
					return string.Format ("{0}%", L1FeedBackScore);
				else
					return ReporteeViewModel._Default_Placeholder;
			}
		}

		private string _LapScore;
		public string LapScore{
			set{ 
				if(Set (() => LapScore, ref _LapScore, value))
					RaisePropertyChanged(()=> LapScore);
			}
			get{ 
				return _LapScore;
			}
		}
		private string _CpScore;
		public string CpScore{
			set{ 
				if(Set (() => CpScore, ref _CpScore, value))
					RaisePropertyChanged(()=> CpScore);
			}
			get{ 
				return _CpScore;
			}
		}
		private string _L2SChangeOnPotential;
		public string L2SChangeOnPotential{
			set{ 
				if(Set (() => L2SChangeOnPotential, ref _L2SChangeOnPotential, value))
					RaisePropertyChanged(()=> L2SChangeOnPotential);
			}
			get{ 
				return _L2SChangeOnPotential;
			}
		}
		private string _CourseID;
		public string CourseID{
			set{ 
				if(Set (() => CourseID, ref _CourseID, value))
					RaisePropertyChanged(()=> CourseID);
			}
			get{ 
				return _CourseID;
			}
		}
		public string EmpId{
			get{ 
				return _Reportee.EmpId;
			}
		}

		private string _L2BeliefPostScore;
		public string L2BeliefPostScore{
			set{ 
				if(Set (() => L2BeliefPostScore, ref _L2BeliefPostScore, value))
					RaisePropertyChanged(()=> L2BeliefPostScore);
			}
			get{ 
				return _L2BeliefPostScore;
			}
		}
		public string FullName{
			get{ 
				return _Reportee.FullName;
			}
		}

		private ImageSource _ProfileImage;

		public ImageSource ProfileImage {
			set { 
				if (Set (() => ProfileImage, ref _ProfileImage, value)) {
					RaisePropertyChanged (() => ProfileImage);
				}
			}
			get {
				if (_ProfileImage == null) {
					if ((_Reportee != null && _Reportee.ProfileImage == null)) {
						return (_ProfileImage = ImageSource.FromFile ("user_pic.png"));
					} else {

						try {
							return (_ProfileImage = ImageSource.FromUri (new Uri (_Reportee.ProfileImage)));
						} catch (Exception e) {
							Debug.WriteLine ("Can't form profile pic uri:>>" + _Reportee.ProfileImage);
						}

						return (_ProfileImage = ImageSource.FromFile ("user_pic.png")); 

					}
				} else {
					return _ProfileImage;
				}
			}
		}


		public string SurName{
			get{ 
				return _Reportee.SurName;
			}
		}

		public string UserName{
			get{ 
				return _Reportee.UserName;
			}
		}
		private bool _IsPresent;

		public bool IsPresent {
			set { 
				if (Set (() => IsPresent, ref _IsPresent, value)) {
					RaisePropertyChanged (()=> IsPresent);
					if (IsPresent == IsAbsent)
						IsAbsent = !IsPresent;
				}
			}
			get { 
				return _IsPresent;
			}
		}

		private bool _IsAbsent;

		public bool IsAbsent
		{
			set { 
				if (Set (() => IsAbsent, ref _IsAbsent, value)) {
					RaisePropertyChanged (() => IsAbsent);
					if (IsAbsent == IsPresent)
						IsPresent = !IsAbsent;
				}
			}
			get { 
				return _IsAbsent;
			}
		}
		//For  Manager report filter
		private bool _IsSelected;

		public bool IsSelected {
			set { 
				if (Set (() => IsSelected, ref _IsSelected, value)) {
					RaisePropertyChanged (() => IsSelected);
				}
			}
			get { 
				return _IsSelected;
			}
		}
	}
}


