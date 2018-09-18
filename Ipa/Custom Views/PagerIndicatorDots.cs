using System;
using System;
using Xamarin.Forms;
using System.Collections;
using System.Linq;

namespace Ipa
{
	public class PagerIndicatorDots : StackLayout
	{
		int dotCount = 1;
		int _selectedIndex;

		public Color DotColor { get; set; }
		public Color SelectedDotColor{ get; set; }
		public double DotSize { get; set; }

		public PagerIndicatorDots()
		{
			BackgroundColor = Color.Aqua;
			HorizontalOptions = LayoutOptions.CenterAndExpand;
			VerticalOptions = LayoutOptions.Center;
			Orientation = StackOrientation.Horizontal;
			DotColor = Color.FromRgb(22,56,102);
			DotSize = 10d;
		}

		void CreateDot()
		{
			//Make one button and add it to the dotLayout
			var dot = new MyButton {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				BorderRadius = Convert.ToInt32(DotSize/2),
				HeightRequest = DotSize,
				WidthRequest = DotSize,
				BackgroundColor = DotColor
			};
			Children.Add(dot);
		}

		public static BindableProperty ItemsSourceProperty =
			BindableProperty.Create<PagerIndicatorDots, IList> (
				pi => pi.ItemsSource,
				null,
				BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					((PagerIndicatorDots)bindable).ItemsSourceChanging ();
				},
				propertyChanged: (bindable, oldValue, newValue) => {
					((PagerIndicatorDots)bindable).ItemsSourceChanged ();
				}
			);

		public IList ItemsSource {
			get {
				return (IList)GetValue(ItemsSourceProperty);
			}
			set {
				SetValue (ItemsSourceProperty, value);
			}
		}

		public static BindableProperty SelectedItemProperty =
			BindableProperty.Create<PagerIndicatorDots, IWalkThroughData> (
				pi => pi.SelectedItem,
				null,
				BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) => {
					((PagerIndicatorDots)bindable).SelectedItemChanged ();
				});

		public IWalkThroughData SelectedItem {
			get {
				return (IWalkThroughData)GetValue (SelectedItemProperty);
			}
			set {
				SetValue (SelectedItemProperty, value);
			}
		}

		void ItemsSourceChanging ()
		{
					if (ItemsSource != null)
				_selectedIndex = ItemsSource.IndexOf (SelectedItem);
		}

		void ItemsSourceChanged ()
		{
			if (ItemsSource == null) return;

			// Dots *************************************
			var countDelta = ItemsSource.Count - Children.Count;

			if (countDelta > 0) {
				for (var i = 0; i < countDelta; i++) 
				{
					CreateDot();
				}
			} 
			else if (countDelta < 0) 
			{
				for (var i = 0; i < -countDelta; i++) 
				{
					Children.RemoveAt (0);
				}
			}
			//*******************************************
		}

		void SelectedItemChanged () {
			var selectedIndex = ItemsSource.IndexOf (SelectedItem);
			var pagerIndicators = Children.Cast<MyButton> ().ToList ();

			foreach(var pi in pagerIndicators)
			{
				UnselectDot(pi);
			}

			if(selectedIndex > -1)
			{
				SelectDot(pagerIndicators[selectedIndex]);
			}
		}

		static void UnselectDot (MyButton dot)
		{
			dot.Opacity = 0.5;
		}

		static void SelectDot (MyButton dot)
		{
			dot.Opacity = 1.0;
		}
	}
}

