using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class ActivityItemView : ContentView
	{
		public ActivityItemView ()
		{
			InitializeComponent ();
		}

		public static readonly BindableProperty ActivityNameProperty = 
			BindableProperty.Create<ActivityItemView, string> (
				(ctrl) => ctrl.ActivityName,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ActivityItemView) bindable).activityName.Text = newValue;
				}
			);

		public string ActivityName {
			get { 
				return (string)GetValue (ActivityNameProperty);
			}
			set { 
				SetValue (ActivityNameProperty, value);
			}
		}

		public static readonly BindableProperty CourseNameProperty = 
			BindableProperty.Create<ActivityItemView, string> (
				(ctrl) => ctrl.CourseName,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ActivityItemView) bindable).courseName.Text = newValue;
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
			BindableProperty.Create<ActivityItemView, string> (
				(ctrl) => ctrl.StatusSource,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ActivityItemView) bindable).statusImage.Source = newValue;
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
			BindableProperty.Create<ActivityItemView, string> (
				(ctrl) => ctrl.IndicatorText,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ActivityItemView) bindable).timeDescription.Text = newValue;
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

