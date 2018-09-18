using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class ClientReportPage : ContentPage
	{
		public ClientReportPage ()
		{
			InitializeComponent ();
			ProgramNameLabel.LineBreakMode = LineBreakMode.TailTruncation;
			CourseMenu.GestureRecognizers.Add (new TapGestureRecognizer ((v)=>{
				if(ProgramNameList.IsVisible){
					ProgramNameList.HeightRequest = 0;
					ProgramNameList.IsVisible = false;
				}else{
					ProgramNameList.HeightRequest=90;
					ProgramNameList.IsVisible=true;
				}
					this.InvalidateMeasure();
			}));
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			ClientReportViewModel vm = (ClientReportViewModel)this.BindingContext;
			this.BindingContext = vm;
		}
	}
}

