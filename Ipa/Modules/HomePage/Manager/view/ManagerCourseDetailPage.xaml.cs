using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ManagerCourseDetailPage : ContentPage
	{
		public ManagerCourseDetailPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			SegmentCtrl.SelectedValue = "OVERVIEW";
			SegmentCtrl.SelectValue = "OVERVIEW";

			SegmentCtrl.ValueChanged += (object sender, EventArgs e) => {
				((ManagerCourseDetailViewModel)this.BindingContext).SegmentSelectionCmd.Execute (SegmentCtrl.SelectedValue);
			};
		}
	}
}

