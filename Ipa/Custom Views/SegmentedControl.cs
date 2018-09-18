using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace Ipa
{
	public class SegmentedControl : View, IViewContainer<SegmentedControlOption>
	{
		public IList<SegmentedControlOption> Children { get; set; }

		public SegmentedControl ()
		{
			Children = new List<SegmentedControlOption> ();

		}

		public event ValueChangedEventHandler ValueChanged;
	
		public delegate void ValueChangedEventHandler (object sender, EventArgs e);
	
		private string selectedValue;

		public string SelectedValue {
			get{ return selectedValue; }
			set {
				selectedValue = value;
				if (ValueChanged != null)
					ValueChanged (this, EventArgs.Empty);
			}
		}
		public static readonly BindableProperty SelectValueProperty = 
			BindableProperty.Create<SegmentedControl, string> (
				(ctrl) => ctrl.SelectValue,			
				string.Empty,
				defaultBindingMode: BindingMode.TwoWay
			);

		public string SelectValue {
			get { 
				return (string)GetValue (SelectValueProperty);
			}
			set { 
				SetValue (SelectValueProperty, value);
			}
		}
	}
	public class SegmentedControlOption:View
	{
		public SegmentedControlOption ()
		{
		}
		public static readonly BindableProperty TextProperty = BindableProperty.Create<SegmentedControlOption, string> (p => p.Text, "");

		public string Text {
			get{ return (string)GetValue (TextProperty); }
			set{ SetValue (TextProperty, value); }
		}

	}
}


