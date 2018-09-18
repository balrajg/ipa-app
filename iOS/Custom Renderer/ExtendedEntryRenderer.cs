using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using System.ComponentModel;
using Ipa;
using Ipa.iOS;


[assembly: ExportRenderer (typeof (MyEntry), typeof (ExtendedEntryRenderer))]

namespace Ipa.iOS
{
	public class ExtendedEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged(e);

			if (this.Control == null) return;

			this.Control.BorderStyle = UITextBorderStyle.None;
		}

	}
}


