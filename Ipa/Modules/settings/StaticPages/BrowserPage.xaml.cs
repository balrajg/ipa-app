using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class BrowserPage : ContentPage
	{
		public BrowserPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			Browser.Navigated += (object sender, WebNavigatedEventArgs e) => {
				(BindingContext as BrowserViewModel).IsBusy = false;

			};
//			BrowserViewModel vm = (BrowserViewModel)this.BindingContext;
//			this.BindingContext = vm;
//			vm.IsBusy = true;
//			Browser.Source = "http://www.Ipa.in/index.php/we-are/";
//			vm.IsBusy = false;
		}
	}
}

