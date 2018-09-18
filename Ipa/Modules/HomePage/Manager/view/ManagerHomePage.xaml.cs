using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ManagerHomePage : ContentPage
	{
		public ManagerHomePage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			HomeDetail.SelectValue = "TEAM";
			HomeDetail.SelectedValue = "TEAM";
			HomeDetail.ValueChanged += (object sender, EventArgs e) => {
				((ManagerHomeViewModel)this.BindingContext).SegmentSelectionCmd.Execute (HomeDetail.SelectedValue);
			};
		}

	}
}

