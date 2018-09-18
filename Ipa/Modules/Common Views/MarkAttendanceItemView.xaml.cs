using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ipa
{
	public partial class MarkAttendanceItemView : ContentView
	{
		private static ImageSource presentImg = ImageSource.FromFile ("present.png");
		private static ImageSource presentUnselectImg = ImageSource.FromFile("present_off.png");
		private static ImageSource absentImg = ImageSource.FromFile("absent.png");
		private static ImageSource absentUnselectImg = ImageSource.FromFile("absent_off.png");

		public MarkAttendanceItemView ()
		{
			InitializeComponent ();
			AbsentLayout.GestureRecognizers.Add (new TapGestureRecognizer ((v) => {
				if(IsAbsentSelected){
					IsAbsentSelected=false;
				}else{
					IsAbsentSelected=true;
				}
			}));
			PresentLayout.GestureRecognizers.Add (new TapGestureRecognizer ((v) => {
				if(IsPresentSelected){
					IsPresentSelected=false;
				}else{
					IsPresentSelected=true;
				}
			}));
		}
	
		public static readonly BindableProperty ParticipantNameProperty = 
			BindableProperty.Create<MarkAttendanceItemView, string> (
				(ctrl) => ctrl.ParticipantName,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((MarkAttendanceItemView) bindable).Name.Text = newValue;
				}
			);

		public string ParticipantName {
			get { 
				return (string)GetValue (ParticipantNameProperty);
			}
			set { 
				SetValue (ParticipantNameProperty, value);
			}
		}

		public static readonly BindableProperty ParticipantIdProperty = 
			BindableProperty.Create<MarkAttendanceItemView, string> (
				(ctrl) => ctrl.ParticipantId,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, string oldValue, string newValue) => {
					((MarkAttendanceItemView) bindable).Id.Text = newValue;
				}
			);

		public string ParticipantId {
			get { 
				return (string)GetValue (ParticipantIdProperty);
			}
			set { 
				SetValue (ParticipantIdProperty, value);
			}
		}

		public static readonly BindableProperty IsPresentSelectedProperty = 
			BindableProperty.Create<MarkAttendanceItemView, bool> (
				(ctrl) => ctrl.IsPresentSelected,			
				false,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					if(newValue){
						((MarkAttendanceItemView)bindable).PresentSelected();
					}else{
						((MarkAttendanceItemView)bindable).PresentUnselected();
					}
				}
			);

		public bool IsPresentSelected {
			get { 
				return (bool)GetValue (IsPresentSelectedProperty);
			}
			set { 
				SetValue (IsPresentSelectedProperty, value);
			}
		}

		public void PresentSelected(){
			PresentCheckBox.Source = presentImg;
			PresentText.TextColor = Color.FromRgb (95,212,111);
		}

		public void PresentUnselected(){
			PresentCheckBox.Source = presentUnselectImg;
			PresentText.TextColor = Color.FromRgb (114,114,114);
		}

		public static readonly BindableProperty IsAbsentSelectedProperty = 
			BindableProperty.Create<MarkAttendanceItemView, bool> (
				(ctrl) => ctrl.IsAbsentSelected,			
				false,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (BindableObject bindable, bool oldValue, bool newValue) => {
					if(newValue){
						((MarkAttendanceItemView)bindable).AbsentSelected();
					}else{
						((MarkAttendanceItemView)bindable).AbsentUnselected();
					}
				}
			);

		public bool IsAbsentSelected {
			get { 
				return (bool)GetValue (IsAbsentSelectedProperty);
			}
			set { 
				SetValue (IsAbsentSelectedProperty, value);
			}
		}

		public void AbsentSelected(){
			AbsentCheckBox.Source = absentImg;
			AbsentText.TextColor = Color.FromRgb (239,63,63);
		}

		public void AbsentUnselected(){
			AbsentCheckBox.Source = absentUnselectImg;
			AbsentText.TextColor = Color.FromRgb (114,114,114);
		}
	}
}

