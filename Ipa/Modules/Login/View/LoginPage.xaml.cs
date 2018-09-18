using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Ipa.DependancyServices;

namespace Ipa
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
			BindingContext = new LoginViewModel ();

			user.Focus();

			user.Completed += (sender, e) => {
				Pwd.Focus ();
			};
			NavigationPage.SetHasNavigationBar (this, false);
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			user.Focus();
		}
		
        protected override bool OnBackButtonPressed()
        {
            CanExitApp();
            return true;
        }
        private void CanExitApp()
        {
            if (Device.OS == TargetPlatform.Android)
            {
                DependencyService.Get<IAndroidMethods>().CloseApp();

            }

        }
    }
}

