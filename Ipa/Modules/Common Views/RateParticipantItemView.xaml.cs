using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class RateParticipantItemView : ContentView
	{
		public RateParticipantItemView ()
		{
			InitializeComponent ();
			GoodButton.Command = new Command (() => {
				if (IsGoodButton) {
					IsGoodButton = false;
				} else {
					IsGoodButton = true;
				}
			});

			AverageButton.Command = new Command (() => {
				if (IsAverageButton) {
					IsAverageButton = false;
				} else {
					IsAverageButton = true;
				}
			});
			PoorButton.Command = new Command (() => {
				if (IsPoorButton) {
					IsPoorButton = false;
				} else {
					IsPoorButton = true;
				}
			});
		}

		public static readonly BindableProperty QuestionTextProperty = 
			BindableProperty.Create<RateParticipantItemView, string> (
				(ctrl) => ctrl.QuestionText,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((RateParticipantItemView)bindable).Question.Text = newValue;
				}
			);

		public string QuestionText {
			get { 
				return (string)GetValue (QuestionTextProperty);
			}
			set { 
				SetValue (QuestionTextProperty, value);
			}
		}

		public static readonly BindableProperty IsGoodButtonProperty = 
			BindableProperty.Create<RateParticipantItemView, bool> (
				(ctrl) => ctrl.IsGoodButton,			
				false,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					if (newValue) {
						((RateParticipantItemView)bindable).GoodSelected ();
					} else {
						((RateParticipantItemView)bindable).GoodUnselected ();
					}
				}
			);

		public bool IsGoodButton {
			get { 
				return (bool)GetValue (IsGoodButtonProperty);
			}
			set { 
				SetValue (IsGoodButtonProperty, value);
			}
		}

		public void GoodSelected ()
		{
			GoodButton.BackgroundColor = Color.FromRgb (43, 145, 193);
			GoodButton.TextColor = Color.FromRgb (255, 255, 255);
		}

		public void GoodUnselected ()
		{
			GoodButton.BackgroundColor = Color.FromRgb (238, 238, 238);
			GoodButton.TextColor = Color.FromRgb (120, 120, 120);
		}

		public static readonly BindableProperty IsPoorButtonProperty = 
			BindableProperty.Create<RateParticipantItemView, bool> (
				(ctrl) => ctrl.IsPoorButton,			
				false,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					if (newValue) {
						((RateParticipantItemView)bindable).PoorSelected ();
					} else {
						((RateParticipantItemView)bindable).PoorUnselected ();
					}
				}
			);

		public bool IsPoorButton {
			get { 
				return (bool)GetValue (IsPoorButtonProperty);
			}
			set { 
				SetValue (IsPoorButtonProperty, value);
			}
		}

		public void PoorSelected ()
		{
			PoorButton.BackgroundColor = Color.FromRgb (43, 145, 193);
			PoorButton.TextColor = Color.FromRgb (255, 255, 255);
		}

		public void PoorUnselected ()
		{
			PoorButton.BackgroundColor = Color.FromRgb (238, 238, 238);
			PoorButton.TextColor = Color.FromRgb (120, 120, 120);
		}

		public static readonly BindableProperty IsAverageButtonProperty = 
			BindableProperty.Create<RateParticipantItemView, bool> (
				(ctrl) => ctrl.IsAverageButton,			
				false,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					if (newValue) {
						((RateParticipantItemView)bindable).AverageSelected ();
					} else {
						((RateParticipantItemView)bindable).AverageUnselected ();
					}
				}
			);

		public bool IsAverageButton {
			get { 
				return (bool)GetValue (IsAverageButtonProperty);
			}
			set { 
				SetValue (IsAverageButtonProperty, value);
			}
		}

		public void AverageSelected ()
		{
			AverageButton.BackgroundColor = Color.FromRgb (43, 145, 193);
			AverageButton.TextColor = Color.FromRgb (255, 255, 255);
		}

		public void AverageUnselected ()
		{
			AverageButton.BackgroundColor = Color.FromRgb (238, 238, 238);
			AverageButton.TextColor = Color.FromRgb (120, 120, 120);
		}


		public static readonly BindableProperty AnswerProperty = 
			BindableProperty.Create<RateParticipantItemView, string> (
				(ctrl) => ctrl.Answer,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay
			);

		public string Answer {
			get { 
				return (string)GetValue (AnswerProperty);
			}
			set { 
				SetValue (AnswerProperty, value);
			}
		}
	}
}

