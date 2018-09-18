using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class HowthisAppWorksPage : ContentPage
	{
		public HowthisAppWorksPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			Browser.Navigated += (object sender, WebNavigatedEventArgs e) => {
				(BindingContext as BrowserViewModel).IsBusy = false;

			};
		}
	}
}

