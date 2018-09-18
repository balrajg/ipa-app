using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ClientCourseDetailPage : ContentPage
	{
		public ClientCourseDetailPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			SegmentCtrl.SelectedValue = "OVERVIEW";
			SegmentCtrl.SelectValue = "OVERVIEW";

			SegmentCtrl.ValueChanged += (object sender, EventArgs e) => {
				((ClientCourseDetailViewModel)this.BindingContext).SegmentSelectionCmd.Execute (SegmentCtrl.SelectedValue);
			};

		}
	}
}

