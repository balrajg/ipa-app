using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class CheckBoxView : ContentView
	{
		public CheckBoxView ()
		{
			InitializeComponent ();
		}

		public static readonly BindableProperty IsCheckedProperty = 
			BindableProperty.Create<CheckBoxView, bool> (
				(ctrl) => ctrl.IsChecked ,
				false,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanging:(bindable, oldValue, newValue) => {
					if(oldValue != newValue){
						var ctrl = bindable as CheckBoxView;
						if (newValue == true) {
							ctrl.ChangeImageSource (ctrl.CheckedImage);
						} else {
							ctrl.ChangeImageSource (ctrl.UncheckedImage);
						}
					}
				},
				propertyChanged: (bindable, oldValue, newValue) => {
					if(oldValue != newValue){
						var ctrl = bindable as CheckBoxView;
						ctrl.OnStateChanged?.Invoke(ctrl, EventArgs.Empty);
					}
				}
			);

		public bool IsChecked{
			get{ 
				return (bool)GetValue (IsCheckedProperty);
			}
			set{ 
				SetValue (IsCheckedProperty, value);
			}
		}

		public EventHandler OnStateChanged; 

		ImageSource _CheckedImage;

		public ImageSource CheckedImage{
			set{
				_CheckedImage = value;

			}
			private get{
				return _CheckedImage;
			}
		}

		ImageSource _UncheckedImage;

		public ImageSource UncheckedImage{
			set{
				if (_UncheckedImage == null)
					CheckImage.Source = value;
				_UncheckedImage = value;
			}
			private get{
				return _UncheckedImage;
			}
		}

		public string Text{
			set{
				this.CheckboxLabel.Text = value;
			}
			get{
				return this.CheckboxLabel.Text;
			}
		}

		public Color TextColor {
			set {
				this.CheckboxLabel.TextColor = value;
			}
			get {
				return this.CheckboxLabel.TextColor;
			}
		}

		public double FontSize{
			set{ 
				this.CheckboxLabel.FontSize = value;
			}
			get{
				return this.CheckboxLabel.FontSize;
			}
		}

		public string FontFamily{
			set{
				this.CheckboxLabel.FontFamily = value;
			}
			get{
				return this.CheckboxLabel.FontFamily;
			}
		}

		public FontAttributes FontAttributes{
			set{
				this.CheckboxLabel.FontAttributes = value;
			}
			get{
				return this.CheckboxLabel.FontAttributes;
			}
		}

		async void ChangeImageSource(ImageSource source){
			await CheckImage.ScaleTo (1.30d, 80, Easing.Linear);
			CheckImage.Source = source;
			await CheckImage.ScaleTo (1.0d, 80, Easing.Linear);
		}


		private void OnCheckboxTapped(Object sender, EventArgs e){
			this.IsChecked = (this.IsChecked) ? false : true;
		}
	}
}

