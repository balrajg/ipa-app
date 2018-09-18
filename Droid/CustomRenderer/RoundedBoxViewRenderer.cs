using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Ipa.Droid;
using Ipa;
using Android.Graphics;


[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]

namespace Ipa.Droid
{
	public class RoundedBoxViewRenderer : BoxRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged(e);

			SetWillNotDraw(false);
			Invalidate();

		}

		public override void Draw(Android.Graphics.Canvas canvas)
		{

			var box = Element as RoundedBoxView;
			var rect = new Rect();
			var paint = new Paint()
			{
				Color = box.BorderColor.ToAndroid(),
				AntiAlias = true,
			};

			paint.SetStyle(Paint.Style.Fill);
			GetDrawingRect(rect);
			var radius = (float)(rect.Width() / box.Width * box.CornerRadius);
			canvas.DrawRoundRect(new RectF(rect), radius, radius, paint);

			rect.Top = rect.Top + Convert.ToInt32 (box.BorderSize) ;
			rect.Bottom = rect.Bottom - Convert.ToInt32 (box.BorderSize);
			rect.Left = rect.Left + Convert.ToInt32 (box.BorderSize);
			rect.Right = rect.Right - Convert.ToInt32 (box.BorderSize);
			paint.Color = box.BackgroundColor.ToAndroid();
			canvas.DrawRoundRect(new RectF(rect), radius, radius, paint);
		}
	}
}


