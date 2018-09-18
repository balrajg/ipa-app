using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Ipa;
using UIKit;

[assembly:ExportRenderer(typeof(SegmentedControl), typeof(Ipa.iOS.SegmentedControlRenderer))]
namespace Ipa.iOS
{
	public class SegmentedControlRenderer : ViewRenderer<SegmentedControl, UISegmentedControl>
	{
		public SegmentedControlRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<SegmentedControl> e)
		{
			base.OnElementChanged (e);

			if (null == e.NewElement)
				return;

			var segmentedControl = new UISegmentedControl ();

			for (var i = 0; i < e.NewElement.Children.Count; i++) {
				segmentedControl.InsertSegment (e.NewElement.Children [i].Text, i, false);
			}
			segmentedControl.TintColor = UIColor.FromRGB (22, 56, 102);
			segmentedControl.SelectedSegment = 0;

			segmentedControl.ValueChanged += (sender, eventArgs) => {
				e.NewElement.SelectedValue = segmentedControl.TitleAt(segmentedControl.SelectedSegment);
			};

			SetNativeControl (segmentedControl);
		}
	}
}