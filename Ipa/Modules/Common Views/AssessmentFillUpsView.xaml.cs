using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ipa
{
	public partial class AssessmentFillUpsView : ContentView
	{
		public AssessmentFillUpsView ()
		{
			InitializeComponent ();

			Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
				Task.Delay (1000);

			});


			AnswerBox.Completed += (object sender, EventArgs e) => {
				
				if(!string.IsNullOrEmpty(AnswerBox.Text) && !string.IsNullOrWhiteSpace(AnswerBox.Text)){
					
					this.Answer = AnswerBox.Text;
					AnswerBox.Focus ();
					AnswerBox.Unfocus();
				}

			};
		}

		public static readonly BindableProperty QuestionProperty = 
			BindableProperty.Create<AssessmentFillUpsView, string> (
				(ctrl) => ctrl.Question,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AssessmentFillUpsView) bindable).Questions.Text = newValue;
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

		public static readonly BindableProperty AnswerProperty = 
			BindableProperty.Create<AssessmentFillUpsView, string> (
				(ctrl) => ctrl.Answer,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					if(newValue != null){
						((AssessmentFillUpsView) bindable).AnswerBox.Text = newValue;
					}else{
						((AssessmentFillUpsView) bindable).AnswerBox.Text = string.Empty;
					}
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
	}
}

