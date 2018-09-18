using System;

using Xamarin.Forms;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Ipa
{
	public interface IAssessmentItemData 
	{
		string QuestionText{ get; }
		List<string> Options{ get; }
		string Answer{ get; set; }
		int QuestionType{ get;}
		RelayCommand AnsweredCmd{ set; get; }
	}
}


