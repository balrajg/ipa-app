using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class ProfileItemListView : ContentView
	{
		public ProfileItemListView ()
		{
			InitializeComponent ();

			Fname.Completed += (sender, e) => {
				SName.Focus ();
			};
			SName.Completed += (sender, e) => {
				MobNumber.Focus ();
			};
			MobNumber.Completed += (sender, e) => {
				Email.Focus ();
			};
		}
	}
}

