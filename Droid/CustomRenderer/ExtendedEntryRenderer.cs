using System;

using Xamarin.Forms;
using Ipa.Droid;
using Xamarin.Forms.Platform.Android;
using Ipa;


[assembly: ExportRenderer (typeof (MyEntry), typeof (ExtendedEntryRenderer))]

namespace Ipa.Droid
{
	public class ExtendedEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundColor (global::Android.Graphics.Color.White);
			}
		}

	}
}


