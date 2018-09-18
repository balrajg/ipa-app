using System;

using Xamarin.Forms;

namespace Ipa
{
	public class MyButton : Button
	{
		public static BindableProperty PaddingProperty = BindableProperty.Create<MyButton, Thickness>(d => d.Padding, default(Thickness));

		public Thickness Padding
		{
			get { return (Thickness) GetValue(PaddingProperty); }
			set { SetValue(PaddingProperty, value); }
		}

			
	}
}


