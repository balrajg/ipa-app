using System;

using Xamarin.Forms;

namespace Ipa
{
	public class TempPage : ContentPage
	{
		public TempPage ()
		{
			NavigationPage.SetHasNavigationBar (this, false);

            BackgroundImage = "Ipa.png";
           
			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.End,
 				Children = {
					new ActivityIndicator () { 
						IsRunning = true,
						WidthRequest = 60,
						HeightRequest = 60,
						VerticalOptions = LayoutOptions.End,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Color = Color.FromHex("#485faa")
					}
				}
			};
		}
	}
}


