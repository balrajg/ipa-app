using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FFImageLoading.Work;

namespace Ipa
{
	public partial class ParticipantItemView : ContentView
	{
		public ParticipantItemView ()
		{
			InitializeComponent ();
			List<ITransformation> circleEffect= new List<ITransformation>();
			circleEffect.Add ( new FFImageLoading.Transformations.CircleTransformation());
			ProfileImage.Transformations = circleEffect;
			Name.LineBreakMode = LineBreakMode.TailTruncation;
		}
		public static readonly BindableProperty ParticipantNameProperty = 
			BindableProperty.Create<ParticipantItemView, string> (
				(ctrl) => ctrl.ParticipantName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ParticipantItemView) bindable).Name.Text = newValue;
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

		public static readonly BindableProperty ParticipantSourceProperty = 
			BindableProperty.Create<ParticipantItemView, Xamarin.Forms.ImageSource> (
				(ctrl) => ctrl.ParticipantSource,			
				null,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, Xamarin.Forms.ImageSource oldValue, Xamarin.Forms.ImageSource newValue) => {
					((ParticipantItemView) bindable).ProfileImage.Source = newValue;
				}
			);

		public Xamarin.Forms.ImageSource ParticipantSource {
			get { 
				return (Xamarin.Forms.ImageSource)GetValue (ParticipantSourceProperty);
			}
			set { 
				SetValue (ParticipantSourceProperty, value);
			}
		}

		public static readonly BindableProperty ParticipantIdProperty = 
			BindableProperty.Create<ParticipantItemView, string> (
				(ctrl) => ctrl.ParticipantId,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ParticipantItemView) bindable).EmpId.Text = newValue;
				}
			);

		public string ParticipantId {
			get { 
				return (string)GetValue (ParticipantIdProperty);
			}
			set { 
				SetValue (ParticipantIdProperty, value);
			}
		}
	}
}

