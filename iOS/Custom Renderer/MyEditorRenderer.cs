using System;

using Xamarin.Forms;
using Ipa.iOS;
using Ipa;
using Xamarin.Forms.Platform.iOS;
using UIKit;


[assembly: ExportRenderer (typeof (MyEditor), typeof (MyEditorRenderer))]

namespace Ipa.iOS
{
	public class MyEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{

			base.OnElementChanged (e);


			if (Control != null) {
				Control.Layer.BorderColor = UIColor.Gray.CGColor;
				Control.Layer.BorderWidth = 0;

			}

		}
	}
}


