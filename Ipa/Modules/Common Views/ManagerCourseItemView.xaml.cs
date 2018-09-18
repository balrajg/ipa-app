using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class ManagerCourseItemView : ContentView
	{
		public ManagerCourseItemView ()
		{
			InitializeComponent ();
		}

		public static readonly BindableProperty CourseFullNameProperty = 
			BindableProperty.Create<ManagerCourseItemView, string> (
				(ctrl) => ctrl.CourseFullName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ManagerCourseItemView) bindable).Coursefullname.Text = newValue;
				}
			);

		public string CourseFullName {
			get { 
				return (string)GetValue (CourseFullNameProperty);
			}
			set { 
				SetValue (CourseFullNameProperty, value);
			}
		}

		public static readonly BindableProperty TimeSourceProperty = 
			BindableProperty.Create<ManagerCourseItemView, string> (
				(ctrl) => ctrl.TimeSource,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ManagerCourseItemView) bindable).StatusSource.Source = newValue;
				}
			);

		public string TimeSource {
			get { 
				return (string)GetValue (TimeSourceProperty);
			}
			set { 
				SetValue (TimeSourceProperty, value);
			}
		}

		public static readonly BindableProperty TimeDescriptionProperty = 
			BindableProperty.Create<ManagerCourseItemView, string> (
				(ctrl) => ctrl.TimeDescription,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ManagerCourseItemView) bindable).Status.Text = newValue;
				}
			);

		public string TimeDescription {
			get { 
				return (string)GetValue (TimeDescriptionProperty);
			}
			set { 
				SetValue (TimeDescriptionProperty, value);
			}
		}

		public static readonly BindableProperty ReporteeStatusProperty = 
			BindableProperty.Create<ManagerCourseItemView, string> (
				(ctrl) => ctrl.ReporteeStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ManagerCourseItemView) bindable).ReporteeText.Text = newValue;
				}
			);

		public string ReporteeStatus {
			get { 
				return (string)GetValue (ReporteeStatusProperty);
			}
			set { 
				SetValue (ReporteeStatusProperty, value);
			}
		}
	}
}

