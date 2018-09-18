using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class AssessmentPage : CarouselPage
	{
		public AssessmentPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			this.ItemTemplate = new DataTemplate (typeof(QuestionPage));
		}
		protected override bool OnBackButtonPressed()
		{
			return true;
		}

	}
}

