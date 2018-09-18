using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class AssessmentAttemptPage : ContentPage
	{

		public AssessmentAttemptPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);

//			AssessmentViewer.ItemTemplate = new DataTemplate (typeof(QuestionView));
//			AssessmentViewer.SetBinding (CarouselView.ItemsSourceProperty, "AssessmentList");
//			AssessmentViewer.SetBinding (CarouselView.SelectedItemProperty, "SelectedItem");
		}
	}
}

