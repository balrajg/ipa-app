using System;

using Xamarin.Forms;

namespace Ipa
{
	public class MyEditor : Editor
	{
		public static readonly BindableProperty BorderColorProperty = 
			BindableProperty.Create<MyEditor, Color> (p => p.BorderColor, Color.Transparent);

		public Color BorderColor {
			get { return (Color)GetValue (BorderColorProperty); }
			set { SetValue (BorderColorProperty, value); }
		}
	}
}


