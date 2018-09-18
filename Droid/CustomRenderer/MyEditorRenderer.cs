using System;
using Xamarin.Forms;
using Ipa.Droid;
using Ipa;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using System.ComponentModel;
using System.Threading;

[assembly: ExportRenderer (typeof (MyEditor), typeof (MyEditorRenderer))]

namespace Ipa.Droid
{
	public class MyEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (Control == null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.Transparent);
			}
		}
		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			MyEditor obj = (MyEditor)sender;
			if (e.PropertyName == "IsFocused") {
				if (obj.IsFocused) {

						ThreadPool.QueueUserWorkItem(s =>
							{
								Thread.Sleep(100); // For some reason, a short delay is required here. ((Android.Views.InputMethods.InputMethodManager)Context.GetSystemService((Android.Content.Context.InputMethodService))).ShowSoftInput(this.Control,Android.Views.InputMethods.ShowFlags.Implicit);
							});
				}
			}
			base.OnElementPropertyChanged(sender, e);
		}
	}
}


