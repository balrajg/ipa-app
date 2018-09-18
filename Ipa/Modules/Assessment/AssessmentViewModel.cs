using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public class AssessmentViewModel :ViewModelBase, IAssessmentItemData
	{
		private ReviewQuestion _Question;
		private int TotalQuestion;
		public AssessmentViewModel (ReviewQuestion question, int questionIndex, int totalCount, string activityName)
		{
			this._Question = question;
			this.TotalQuestionCount = totalCount;
			this.QuestionIndex = questionIndex;
			this.TotalQuestion = totalCount;
			this.ActivityName = activityName;
			Options.Reverse ();

		}
		public string ActivityName{ get; set; }

		public string Id {
			get {
				return _Question.Id;
			}
		}
		private bool _IsDone=false;
		public bool IsDone{
			set{ 
				if(Set (() => IsDone, ref _IsDone, value))
					RaisePropertyChanged(()=> IsDone);
			}
			get{ 
				return _IsDone;
			}
		}

		public string QuestionText {
			get {
				return _Question.QuestionText;
			}
		}

		public string Category {
			get {
				return _Question.Category;
			}
		}

		public int QuestionType {
			get {
				return _Question.Type;
			}
		}

		private List<string> _Options;

		public List<string> Options {
			set { 
				if (Set (() => Options, ref _Options, value)) {
					RaisePropertyChanged (() => Options);
				}
			}
			get {
				return _Question.Options;
			}
		}
	
		private string _Answer = string.Empty;

		public string Answer {
			get { 
					return _Answer; 
			}
			set { 
				
				if (Set (() => Answer, ref _Answer, value)) {
					RaisePropertyChanged (()=> Answer);
					AnsweredCmd?.Execute (null);
				}
			}
		}

		private RelayCommand _AnswerCmd;
		public RelayCommand AnsweredCmd{
			get{ 
				return _AnswerCmd;
			}
			set{ 
				_AnswerCmd = value;
			}
		}

		//trying
		private RelayCommand _CloseCmd;
		public RelayCommand CloseCmd{
			get{
				return _CloseCmd;
			}
			set{
				_CloseCmd = value;
			}
		}
		private RelayCommand _DoneCmd;
		public RelayCommand DoneCmd{
			get{
				return _DoneCmd;
			}
			set{
				_DoneCmd = value;
			}
		}

		private int _TotalQuestionCount;

		public int TotalQuestionCount {
			get { 
				return _TotalQuestionCount; 
			}
			set { 
				_TotalQuestionCount = value;
			}
		}

		private int _QuestionIndex;

		public int QuestionIndex {
			get { 
				return _QuestionIndex; 
			}
			set { 
				_QuestionIndex = value;
			}
		}

		public string QuestionIndicator {
			get { 
				return string.Format ("{0}/{1}", QuestionIndex, TotalQuestionCount);
			}
		}
	}
}


