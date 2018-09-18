using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FFImageLoading.Work;

namespace Ipa
{
	public partial class ParticipantFilterListItemView : ContentView
	{
		public ParticipantFilterListItemView ()
		{
			InitializeComponent ();
			List<ITransformation> circleEffect= new List<ITransformation>();
			circleEffect.Add ( new FFImageLoading.Transformations.CircleTransformation());
			ProfileImage.Transformations = circleEffect;
			CheckBoxValue.OnStateChanged += (object sender, EventArgs e) => {
				this.IsPresent = ((CheckBoxView)sender).IsChecked;
			};
		}

		public static readonly BindableProperty ParticipantNameProperty = 
			BindableProperty.Create<ParticipantFilterListItemView, string> (
				(ctrl) => ctrl.ParticipantName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ParticipantFilterListItemView) bindable).Name.Text = newValue;
				}
			);

		public string ParticipantName {
			get { 
				return (string)GetValue (ParticipantNameProperty);
			}
			set { 
				SetValue (ParticipantNameProperty, value);
			}
		}

		public static readonly BindableProperty PofileImageProperty = 
			BindableProperty.Create<ParticipantFilterListItemView, Xamarin.Forms.ImageSource> (
				(ctrl) => ctrl.PofileImage,			
				null,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, Xamarin.Forms.ImageSource oldValue, Xamarin.Forms.ImageSource newValue) => {
					((ParticipantFilterListItemView) bindable).ProfileImage.Source = newValue;
				}
			);

		public Xamarin.Forms.ImageSource PofileImage {
			get { 
				return (string)GetValue (PofileImageProperty);
			}
			set { 
				SetValue (PofileImageProperty, value);
			}
		}

		public static readonly BindableProperty IsPresentProperty = 
			BindableProperty.Create<ParticipantFilterListItemView, bool> (
				(ctrl) => ctrl.IsPresent,			
				default(bool),
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					if(oldValue != newValue){
						((ParticipantFilterListItemView) bindable).CheckBoxValue.IsChecked = newValue;
					}
				}
			);

		public bool IsPresent {
			get { 
				return (bool)GetValue (IsPresentProperty);
			}
			set { 
				SetValue (IsPresentProperty, value);
			}
		}
	}
}

