using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class OrgItemListView : ContentView
	{
		public OrgItemListView ()
		{
			InitializeComponent ();

			id.Completed += (sender, e) => 
			{
				OrgName.Focus();
			};
			OrgName.Completed += (sender, e) => 
			{
				Designation.Focus();
			};
			Designation.Completed += (sender, e) => 
			{
				City.Focus();
			};
		}
	}
}

