using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class CourseActivityViewItem : ContentView
	{
		public CourseActivityViewItem ()
		{
			InitializeComponent ();
		}
		public static readonly BindableProperty ActivityNameProperty = 
			BindableProperty.Create<CourseDetailActivityItemView, string> (
				(ctrl) => ctrl.ActivityName,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((CourseActivityViewItem) bindable).Activityname.Text = newValue;
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

		public static readonly BindableProperty StatusSourceProperty = 
			BindableProperty.Create<CourseDetailActivityItemView, string> (
				(ctrl) => ctrl.StatusSource,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((CourseActivityViewItem) bindable).Status.Source = newValue;
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
			BindableProperty.Create<CourseDetailActivityItemView, string> (
				(ctrl) => ctrl.IndicatorText,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((CourseActivityViewItem) bindable).Statusdescription.Text = newValue;
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

