using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class TermsAndConditionPage : ContentPage
	{
		public TermsAndConditionPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			Browser.Navigated += (object sender, WebNavigatedEventArgs e) => {
				(BindingContext as BrowserViewModel).IsBusy = false;

			};
		}
	}
}

