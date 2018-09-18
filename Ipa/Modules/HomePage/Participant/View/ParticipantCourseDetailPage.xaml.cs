using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ParticipantCourseDetailPage : ContentPage
	{
		public ParticipantCourseDetailPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
		}
		protected override void OnDisappearing (){
			base.OnDisappearing ();
			MessagingCenter.Unsubscribe<ParticipantCourseDetailPage,string> (this, "PendingList");
		}
	}
}

