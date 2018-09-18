using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ForumPage : ContentPage
	{
		public ForumPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			ListView list = new ListView();

		}
		protected override bool OnBackButtonPressed(){
			this.IsEnabled = false;
			MessagingCenter.Unsubscribe<ForumPage> (this, "LastMessage");
			return true;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			ForumListPageViewModel vm = (ForumListPageViewModel)this.BindingContext;
			this.BindingContext = vm;
			vm.RaiseProperty ();
		}

	}
}

