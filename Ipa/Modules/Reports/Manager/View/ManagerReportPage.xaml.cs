using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace Ipa
{
	public partial class ManagerReportPage : ContentPage
	{
		public ManagerReportPage ()
		{
			InitializeComponent ();

			NavigationPage.SetHasNavigationBar (this, false);

			CourseNameList.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				Debug.WriteLine(e.SelectedItem is View);
			};
			CourseNameLabel.LineBreakMode = LineBreakMode.TailTruncation;
			CourseMenu.GestureRecognizers.Add (new TapGestureRecognizer ((v)=>{
				if(CourseNameList.IsVisible){
					CourseNameList.HeightRequest = 0;
					CourseNameList.IsVisible = false;
				}else{
					CourseNameList.HeightRequest=90;
					CourseNameList.IsVisible=true;
				}
				this.InvalidateMeasure();
			}));

			CourseNameMenu.GestureRecognizers.Add (new TapGestureRecognizer ((v)=>{
				if(CourseList.IsVisible){
					CourseList.HeightRequest = 0;
					CourseList.IsVisible = false;
				}else{
					CourseList.HeightRequest=130;
					CourseList.IsVisible=true;
				}
				this.InvalidateMeasure();
			}));

		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			ManagerReportViewModel vm = (ManagerReportViewModel)this.BindingContext;
			this.BindingContext = vm;
		}
	}
}

