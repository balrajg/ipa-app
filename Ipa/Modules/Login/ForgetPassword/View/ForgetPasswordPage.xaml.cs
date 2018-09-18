using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ForgetPasswordPage : ContentPage
	{
		public ForgetPasswordPage ()
		{
			InitializeComponent ();
			BindingContext = new ForgetPasswordViewModel ();
			NavigationPage.SetHasNavigationBar (this, false);
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			user.Focus();
		}
	}
}

