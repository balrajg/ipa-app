using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ParticipantHomePage : ContentPage
	{
		public ParticipantHomePage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
//			CourseList.SeparatorVisibility = SeparatorVisibility.Default
		}
//		protected override void OnDisappearing (){
//			base.OnDisappearing ();
//			MessagingCenter.Unsubscribe<ParticipantHomePage,string> (this, "Message");
//		}
	}
}

