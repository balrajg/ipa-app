using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace Ipa
{
	public partial class ParticipantReportPage : ContentPage
	{
		public ParticipantReportPage ()
		{
			InitializeComponent ();
			CourseNameList.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				Debug.WriteLine(e.SelectedItem is ViewCell);
			
			};

			CourseNameList.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				Debug.WriteLine(e.Item is ViewCell);	
			};
			NavigationPage.SetHasNavigationBar (this, false);
			CourseMenu.GestureRecognizers.Add (new TapGestureRecognizer ((v)=>{
				if(CourseNameList.IsVisible){
					CourseNameList.HeightRequest = 0;
					CourseNameList.IsVisible = false;
				}else{
					CourseNameList.HeightRequest=130;
					CourseNameList.IsVisible=true;
				}
				this.InvalidateMeasure();
			}));
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			ParticipantReportViewModel vm = (ParticipantReportViewModel)this.BindingContext;
			this.BindingContext = vm;
		}
	}
}

