using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ChangePwdPage : ContentPage
	{
		public ChangePwdPage ()
		{
			InitializeComponent ();

			OldPwd.Focus();
			OldPwd.Completed += (sender, e) => 
			{
				NewPwd.Focus();
			};
			NewPwd.Completed += (sender, e) => 
			{
				ConfirmPwd.Focus();
			};
			NavigationPage.SetHasNavigationBar (this, false);
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			OldPwd.Focus();
		}
	}
}

