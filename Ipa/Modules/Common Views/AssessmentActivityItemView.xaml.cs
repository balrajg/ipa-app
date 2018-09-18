using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class AssessmentActivityItemView : ContentView
	{
		public AssessmentActivityItemView ()
		{
			InitializeComponent ();
		}

		public static readonly BindableProperty ActivityNameProperty = 
			BindableProperty.Create<AssessmentActivityItemView, string> (
				(ctrl) => ctrl.ActivityName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AssessmentActivityItemView) bindable).Activityname.Text = newValue;
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
			
		public static readonly BindableProperty CompletedStatusProperty = 
			BindableProperty.Create<AssessmentActivityItemView, string> (
				(ctrl) => ctrl.CompletedStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AssessmentActivityItemView) bindable).CompletedText.Text = newValue;
				}
			);

		public string CompletedStatus {
			get { 
				return (string)GetValue (CompletedStatusProperty);
			}
			set { 
				SetValue (CompletedStatusProperty, value);
			}
		}
		public static readonly BindableProperty PendingStatusProperty = 
			BindableProperty.Create<AssessmentActivityItemView, string> (
				(ctrl) => ctrl.PendingStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AssessmentActivityItemView) bindable).PendingText.Text = newValue;
				}
			);

		public string PendingStatus {
			get { 
				return (string)GetValue (PendingStatusProperty);
			}
			set { 
				SetValue (PendingStatusProperty, value);
			}
		}
		public static readonly BindableProperty OverdueStatusProperty = 
			BindableProperty.Create<AssessmentActivityItemView, string> (
				(ctrl) => ctrl.OverdueStatus,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((AssessmentActivityItemView) bindable).OverdueText.Text = newValue;
				}
			);

		public string OverdueStatus {
			get { 
				return (string)GetValue (OverdueStatusProperty);
			}
			set { 
				SetValue (OverdueStatusProperty, value);
			}
		}
	}
}

