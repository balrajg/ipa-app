using System;
using Xamarin.Forms.Platform.Android;
using Ipa.Droid;
using Ipa;
using Xamarin.Forms;
using System.ComponentModel;
using Android.Views;


[assembly: ExportRenderer (typeof (MyButton), typeof (CustomButtonRenderer))]

namespace Ipa.Droid
{
	public class CustomButtonRenderer:ButtonRenderer
	{
		public CustomButtonRenderer ()
		{
		}
//		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
//		{
//			base.OnElementPropertyChanged(sender, e);
//			var view = (MyButton)this.Element;
//			var nativeButton = (global::Android.Widget.Button)this.Control;
//			nativeButton.SetPadding((int)view.Padding.Left, (int)view.Padding.Top, (int)view.Padding.Right, (int)view.Padding.Bottom);
//		
//		}
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);
			var view = (MyButton)this.Element;
			var nativeButton = (global::Android.Widget.Button)this.Control;
			nativeButton.SetPadding((int)view.Padding.Left, (int)view.Padding.Top, (int)view.Padding.Right, (int)view.Padding.Bottom);
			Android.Widget.Button thisButton = Control as Android.Widget.Button;
			thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) =>
			{
				if (e2.Event.Action == MotionEventActions.Down)
					System.Diagnostics.Debug.WriteLine("TouchDownEvent");
				else if (e2.Event.Action == MotionEventActions.Up)
					System.Diagnostics.Debug.WriteLine("TouchUpEvent");
			};
		}
	}
}

