using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace Ipa
{
	public class QuestionListViewModel : ViewModelBase
	{
		private RateQuestion _Question;

		public QuestionListViewModel (RateQuestion question)
		{
			this._Question = question;
		}

		public  List<string> OptionList {
			get {
				return _Question.OptionList;
			}
		}

		public  string QuestionID {
			get {
				return _Question.QuestionID;
			}
		}

		public  string QuestionText {
			get {
				return _Question.QuestionText;
			}
		}

		public  string QuestionType {
			get {
				return _Question.QuestionType;
			}
		}
		private bool _IsGoodSelected;

		public bool IsGoodSelected
		{
			set { 
				if (Set (() => IsGoodSelected, ref _IsGoodSelected, value)) {
					RaisePropertyChanged (() => IsGoodSelected);
					if (IsGoodSelected) {
						IsPoorSelected = false;
						IsAverageSelected = false;
					}
				}
			}
			get { 
				return _IsGoodSelected;
			}
		}

		private bool _IsPoorSelected;

		public bool IsPoorSelected
		{
			set { 
				if (Set (() => IsPoorSelected, ref _IsPoorSelected, value)) {
					RaisePropertyChanged (() => IsPoorSelected);
					if (IsPoorSelected) {
						IsGoodSelected = false;
						IsAverageSelected = false;
					}
				}
			}
			get { 
				return _IsPoorSelected;
			}
		}
		private bool _IsAverageSelected;

		public bool IsAverageSelected
		{
			set { 
				if (Set (() => IsAverageSelected, ref _IsAverageSelected, value)) {
					RaisePropertyChanged (() => IsAverageSelected);
					if (IsAverageSelected) {
						IsGoodSelected = false;
						IsPoorSelected = false;
					}
				}
			}
			get { 
				return _IsAverageSelected;
			}
		}


		public string Answer {
			get { 
					if (IsPoorSelected) {
						return "4";
					} else if (IsAverageSelected) {
						return "8";
					} else if (IsGoodSelected) {
						return "10";
				}else{
					return string.Empty;
				}
			}
		}
	}
}

