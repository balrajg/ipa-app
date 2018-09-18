using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace Ipa
{
	public partial class PartnerCourseDetailPage : ContentPage
	{
		public PartnerCourseDetailPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			SegmentCtrl.SelectedValue = "OVERVIEW";
			SegmentCtrl.SelectValue = "OVERVIEW";

			SegmentCtrl.ValueChanged += (object sender, EventArgs e) => {
				((PartnerCourseDetailViewModel)this.BindingContext).SegmentSelectionCmd.Execute (SegmentCtrl.SelectedValue);
			};

		}
	}
}

