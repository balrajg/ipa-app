using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class PartnerAttendanceItemView : ContentView
	{
		private PartnerCourseDetailViewModel _ViewModel;

		public PartnerAttendanceItemView ()
		{
			InitializeComponent ();
			MarkItLabel.GestureRecognizers.Add (new TapGestureRecognizer((v, obj) => {
				((PartnerCourseDetailViewModel)this.BindingContext).MarkItNowCmd.Execute(null);
			}));
		}

		public static readonly BindableProperty ShowDayProperty = 
			BindableProperty.Create<PartnerAttendanceItemView, string> (
				(ctrl) => ctrl.ShowDay,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((PartnerAttendanceItemView) bindable).Day.Text = newValue;
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
			BindableProperty.Create<PartnerAttendanceItemView, string> (
				(ctrl) => ctrl.ShowDate,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((PartnerAttendanceItemView) bindable).Date.Text = newValue;
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

		public static readonly BindableProperty CanShowMarkItNowProperty = 
			BindableProperty.Create<PartnerAttendanceItemView, bool> (
				(ctrl) => ctrl.CanShowMarkItNow,			
				default(bool),
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					((PartnerAttendanceItemView) bindable).MarkItLabel.IsVisible  = newValue;
				}
			);

		public bool CanShowMarkItNow {
			get { 
				return (bool)GetValue (CanShowMarkItNowProperty);
			}
			set { 
				SetValue (CanShowMarkItNowProperty, value);
			}
		}

		public static readonly BindableProperty AbsentStatusProperty = 
			BindableProperty.Create<PartnerAttendanceItemView, string> (
				(ctrl) => ctrl.AbsentStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((PartnerAttendanceItemView) bindable).AbsentCount.Text = newValue;
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
			BindableProperty.Create<PartnerAttendanceItemView, string> (
				(ctrl) => ctrl.PresentStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((PartnerAttendanceItemView) bindable).PresentCount.Text = newValue;
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

