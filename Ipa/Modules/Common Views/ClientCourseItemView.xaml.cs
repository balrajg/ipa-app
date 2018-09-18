using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class ClientCourseItemView : ContentView
	{
		public ClientCourseItemView ()
		{
			InitializeComponent ();
		}
		public static readonly BindableProperty CourseFullNameProperty = 
			BindableProperty.Create<ClientCourseItemView, string> (
				(ctrl) => ctrl.CourseFullName,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ClientCourseItemView) bindable).Coursename.Text = newValue;
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
			BindableProperty.Create<ClientCourseItemView, string> (
				(ctrl) => ctrl.TimeSource,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ClientCourseItemView) bindable).StatusSource.Source = newValue;
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
			BindableProperty.Create<ClientCourseItemView, string> (
				(ctrl) => ctrl.TimeDescription,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ClientCourseItemView) bindable).Status.Text = newValue;
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


		public static readonly BindableProperty ParticipantStatusProperty = 
			BindableProperty.Create<ClientCourseItemView, string> (
				(ctrl) => ctrl.ParticipantStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((ClientCourseItemView) bindable).ParticipantText.Text = newValue;
				}
			);

		public string ParticipantStatus {
			get { 
				return (string)GetValue (ParticipantStatusProperty);
			}
			set { 
				SetValue (ParticipantStatusProperty, value);
			}
		}
	}
}

