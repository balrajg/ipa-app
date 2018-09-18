using System;

using Xamarin.Forms;
using Ipa.iOS;
using Ipa;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;


[assembly: ExportRenderer (typeof (MyTabbedPage), typeof (TabbedPageCustom))]

namespace Ipa.iOS
{
	public class TabbedPageCustom : TabbedRenderer
	{
		readonly nfloat imageYOffset = 7.0f;

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			TabBar.TintColor = UIColor.Orange;
			TabBar.BarTintColor = UIColor.FromRGB(23, 56,102);
			TabBar.BackgroundColor = UIColor.White;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			if (TabBar.Items != null)
			{
				foreach (var item in TabBar.Items)
				{
					item.Title = null;
					item.ImageInsets = new UIEdgeInsets(imageYOffset, 0, -imageYOffset, 0);
				}
			}
		}
	}
}


