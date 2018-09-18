using System;

using Xamarin.Forms;

namespace Ipa
{
	public class QuestionView : ContentView
	{
		StackLayout _Parent;
		public QuestionView ()
		{
			_Parent = new StackLayout (){
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};
			Content = _Parent;
		}

		public static readonly BindableProperty TypeProperty = 
			BindableProperty.Create<QuestionView, int> (
				(ctrl) => ctrl.Type,			
				1000,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanging:(BindableObject bindable, int oldValue, int newValue) => {
					((QuestionView)bindable).Draw (newValue);
				}
			);

		public int Type {
			get { 
				return (int)GetValue (TypeProperty);
			}
			set { 
				SetValue (TypeProperty, value);
			}
		}

		public void Draw (int type)
		{
			if (type == 1) {
				AssessmentMultipleChoiceView mChoice = new AssessmentMultipleChoiceView ();
				mChoice.SetBinding (AssessmentMultipleChoiceView.QuestionProperty, "QuestionText", BindingMode.OneWay);
				mChoice.SetBinding (AssessmentMultipleChoiceView.OptionsProperty, "Options", BindingMode.OneWay);
				mChoice.SetBinding (AssessmentMultipleChoiceView.AnswerProperty, "Answer", BindingMode.TwoWay);
				_Parent.Children.Add (mChoice);
			}
			if(type == 0){
				AssessmentFillUpsView FillUp = new AssessmentFillUpsView ();
				FillUp.SetBinding (AssessmentFillUpsView.QuestionProperty, "QuestionText" ,BindingMode.OneWay);
				FillUp.SetBinding (AssessmentFillUpsView.AnswerProperty,"Answer", BindingMode.TwoWay);
				_Parent.Children.Add (FillUp);
			}

			this.InvalidateLayout ();
		}

	}
}


