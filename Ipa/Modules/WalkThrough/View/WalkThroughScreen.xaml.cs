using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class WalkThroughScreen : ContentPage
	{
		public WalkThroughScreen (WalkThroughViewModel viewModel)
		{
			InitializeComponent ();
			this.BindingContext = viewModel;


			//WalkThroughViewer.ItemTemplate = new DataTemplate (typeof(WalkthroughView));
			//WalkThroughViewer.SetBinding (GalleryCarouselView.ItemsSourceProperty, "WalkThroughs");
			//WalkThroughViewer.SetBinding (GalleryCarouselView.SelectedItemProperty, "SelectedItem");

			DotIndicator.SetBinding (PagerIndicatorDots.ItemsSourceProperty, "WalkThroughs");
			DotIndicator.SetBinding (PagerIndicatorDots.SelectedItemProperty, "SelectedItem");

		}
		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}

