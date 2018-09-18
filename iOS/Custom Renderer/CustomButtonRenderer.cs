using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Ipa;
using Ipa.iOS;
using UIKit;


[assembly: ExportRenderer (typeof (MyButton), typeof (CustomButtonRenderer))]

namespace Ipa.iOS
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			UIButton thisButton = Control as UIButton;
			thisButton.TouchDown += delegate
			{
				System.Diagnostics.Debug.WriteLine("TouchDownEvent");
			};
			thisButton.TouchUpInside += delegate
			{
				System.Diagnostics.Debug.WriteLine("TouchUpEvent");
			};
		}
	}
}


