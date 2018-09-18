using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class AttendanceItemView : ContentView
	{
		public AttendanceItemView ()
		{
			InitializeComponent ();
		}

		public static readonly BindableProperty ShowDayProperty = 
			BindableProperty.Create<AttendanceItemView, string> (
				(ctrl) => ctrl.ShowDay,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AttendanceItemView) bindable).Day.Text = newValue;
				}
			);

		public string ShowDay {
			get { 
				return (string)GetValue (ShowDayProperty);
			}
			set { 
				SetValue (ShowDayProperty, value);
			}
		}

		public static readonly BindableProperty ShowDateProperty = 
			BindableProperty.Create<AttendanceItemView, string> (
				(ctrl) => ctrl.ShowDate,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AttendanceItemView) bindable).Date.Text = newValue;
				}
			);

		public string ShowDate {
			get { 
				return (string)GetValue (ShowDateProperty);
			}
			set { 
				SetValue (ShowDateProperty, value);
			}
		}

		public static readonly BindableProperty AbsentStatusProperty = 
			BindableProperty.Create<AttendanceItemView, string> (
				(ctrl) => ctrl.AbsentStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AttendanceItemView) bindable).Absent.Text = newValue;
				}
			);

		public string AbsentStatus {
			get { 
				return (string)GetValue (AbsentStatusProperty);
			}
			set { 
				SetValue (AbsentStatusProperty, value);
			}
		}
		public static readonly BindableProperty PresentStatusProperty = 
			BindableProperty.Create<AttendanceItemView, string> (
				(ctrl) => ctrl.PresentStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AttendanceItemView) bindable).Present.Text = newValue;
				}
			);

		public string PresentStatus {
			get { 
				return (string)GetValue (PresentStatusProperty);
			}
			set { 
				SetValue (PresentStatusProperty, value);
			}
		}
	}
}

