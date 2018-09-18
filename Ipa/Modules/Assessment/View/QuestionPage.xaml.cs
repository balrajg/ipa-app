using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class QuestionPage : ContentPage
	{
		public QuestionPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
		}
//
//		protected override void OnBindingContextChanged ()
//		{
//			base.OnBindingContextChanged ();
//
//			this.Question.BindingContext = this.BindingContext as AssessmentViewModel;
//		}
	}
}

