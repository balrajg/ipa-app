using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class ButtonItemView : Button
	{
		public ButtonItemView ()
		{
			InitializeComponent ();
		}



		public static readonly BindableProperty IsSelectedProperty = 
			BindableProperty.Create<ButtonItemView, bool> (
				(ctrl) => ctrl.IsSelected,			
				default(bool),
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					if(oldValue != newValue){
						((ButtonItemView) bindable).IsSelected = newValue;
						((ButtonItemView) bindable).UpdateButton();
					}

				}
			);

		public bool IsSelected {
			get { 
				return (bool)GetValue (IsSelectedProperty);
			}
			set { 
				SetValue (IsSelectedProperty, value);
			}
		}

		public void UpdateButton(){
			if (this.IsSelected)
			{
				this.BackgroundColor = Color.FromRgb(43,145,193);
				this.TextColor=Color.FromRgb (244,244,244);
			}
			else
			{
				this.BackgroundColor = Color.FromRgb(238,238,238);
				this.TextColor=Color.FromRgb (120,120,120);
			}
		}
	}
}

