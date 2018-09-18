using System;

using Xamarin.Forms;

namespace Ipa
{
	public class MyEntry : Entry
	{
		public static readonly BindableProperty BorderColorProperty = 	BindableProperty.Create<MyEntry, Color> (p => p.BorderColor, Color.Black);

		public Color BorderColor {
			get { return (Color)GetValue (BorderColorProperty); }
			set { SetValue (BorderColorProperty, Color.Black); }
		} 
	}
}


