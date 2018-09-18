using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class AssessmentMultipleChoiceView : ContentView
	{
		public AssessmentMultipleChoiceView ()
		{
			InitializeComponent ();
		}

		public void AddButton(){
			OptionStackLayout.Children.Add (new ButtonItemView ());
		}

		public static readonly BindableProperty QuestionProperty = 
			BindableProperty.Create<AssessmentMultipleChoiceView, string> (
				(ctrl) => ctrl.Question,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AssessmentMultipleChoiceView) bindable).Questions.Text = newValue;
				}
			);

		public string Question {
			get { 
				return (string)GetValue (QuestionProperty);
			}
			set { 
				SetValue (QuestionProperty, value);
			}
		}

		public static readonly BindableProperty OptionsProperty = 
			BindableProperty.Create<AssessmentMultipleChoiceView, List<string>> (
				(ctrl) => ctrl.Options,			
				null,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, List<string> oldValue, List<string> newValue) => {
					((AssessmentMultipleChoiceView)bindable).UpdateOptions();
				}
			);

		public List<string> Options {
			get { 
				return (List<string>)GetValue (OptionsProperty);
			}
			set { 
				SetValue (OptionsProperty, value);
			}
		}

		public static readonly BindableProperty AnswerProperty = 
			BindableProperty.Create<AssessmentMultipleChoiceView, string> (
				(ctrl) => ctrl.Answer,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					if(!oldValue.Equals(newValue))
						((AssessmentMultipleChoiceView)bindable).SelectOption (newValue);
				}
			);

		public string Answer {
			get { 
				return (string)GetValue (AnswerProperty);
			}
			set { 
				SetValue (AnswerProperty, value);
			}
		}

		private void UpdateOptions(){

			if (Options != null) {
				foreach (string option in Options) {
					ButtonItemView btnItemView = new ButtonItemView ();
					btnItemView.Text = option;
					btnItemView.Command = new Command (()=> {
						SelectOption(btnItemView);
					});
					OptionStackLayout.Children.Add (btnItemView);
				}
			}
		}

		private void SelectOption(ButtonItemView button){
			if (button.Text.Equals (Answer)) {
				return;
			} else {
				SelectOption (button.Text);
			}
		}

		private void SelectOption(string option){
			
			foreach (ButtonItemView view in OptionStackLayout.Children) {
				view.IsSelected = false;
				if (view.Text.Equals (option)) {
					view.IsSelected = true;
					this.Answer = view.Text;
				}
			}
		}

	}
}

