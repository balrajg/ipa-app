using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Ipa.DependancyServices;

namespace Ipa
{
	public partial class MotherPage : MyTabbedPage
	{
		public MotherPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
		}
		protected override bool OnBackButtonPressed()
		{
			CanExitApp();
			return true;
		}
		private async void CanExitApp() {
			if (Device.OS == TargetPlatform.Android) {
				DependencyService.Get<IAndroidMethods>().CloseApp();

			}
				
		}
	}
}

