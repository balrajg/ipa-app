using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class ParticipantCourseItemView : ContentView
	{
		public ParticipantCourseItemView ()
		{
			InitializeComponent ();

		}

		public static readonly BindableProperty CourseNameProperty = 
			BindableProperty.Create<ParticipantCourseItemView, string> (
				(ctrl) => ctrl.CourseName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ParticipantCourseItemView) bindable).Name.Text = newValue;
				}
			);

		public string CourseName {
			get { 
				return (string)GetValue (CourseNameProperty);
			}
			set { 
				SetValue (CourseNameProperty, value);
			}
		}

		public static readonly BindableProperty StatusSourceProperty = 
			BindableProperty.Create<ParticipantCourseItemView, string> (
				(ctrl) => ctrl.StatusSource,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay, 
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ParticipantCourseItemView) bindable).Source.Source = newValue;
				}
			);

		public string StatusSource {
			get { 
				return (string)GetValue (StatusSourceProperty);
			}
			set { 
				SetValue (StatusSourceProperty, value);
			}
		}

		public static readonly BindableProperty IndicatorTextProperty = 
			BindableProperty.Create<ParticipantCourseItemView, string> (
				(ctrl) => ctrl.IndicatorText,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ParticipantCourseItemView) bindable).Status.Text = newValue;
				}
			);

		public string IndicatorText {
			get { 
				return (string)GetValue (IndicatorTextProperty);
			}
			set { 
				SetValue (IndicatorTextProperty, value);
			}
		}
	}
}

