using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class SetupUpdatePwdPage : ContentPage
	{
		public SetupUpdatePwdPage ()
		{
			InitializeComponent ();
			NewPwd.Focus();

			NewPwd.Completed += (sender, e) => 
			{
				Confirmpwd.Focus();
			};
			NavigationPage.SetHasNavigationBar (this, false);
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			NewPwd.Focus();
		}
       
    }
}

