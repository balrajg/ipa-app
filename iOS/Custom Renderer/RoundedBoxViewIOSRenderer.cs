using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using System.Drawing;
using Ipa.iOS.Renderers;
using Ipa;


[assembly:ExportRenderer(typeof(RoundedBoxView),typeof(RoundedBoxViewIOSRenderer))]

namespace Ipa.iOS.Renderers
{
	public class RoundedBoxViewIOSRenderer:BoxRenderer
	{
		public override void Draw (CGRect rect)
		{
			RoundedBoxView rbv = (RoundedBoxView)this.Element;

			using (var context = UIGraphics.GetCurrentContext ()) {
				
				context.SetFillColor(rbv.BackgroundColor.ToCGColor());
				context.SetStrokeColor (rbv.BorderColor.ToCGColor ());
				context.SetLineWidth ((float)rbv.BorderSize);
				var rc = this.Bounds.Inset ((int)rbv.BorderSize, (int)rbv.BorderSize);
				nfloat radius = (nfloat)rbv.CornerRadius;
				radius = (nfloat)Math.Max (0, Math.Min (radius, Math.Max (rc.Height / 2, rc.Width / 2)));
				var path = CGPath.FromRoundedRect (rc, radius, radius);
				context.AddPath (path);
				context.DrawPath (CGPathDrawingMode.EOFillStroke);
			}
		}

		protected override void OnElementChanged (ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged (e);
		}

	}
}

