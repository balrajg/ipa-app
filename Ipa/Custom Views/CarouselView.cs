using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ipa
{
	public class CarouselView : ScrollView
	{
		readonly StackLayout _stack;

		public CarouselView ()
		{
			Orientation = ScrollOrientation.Horizontal;

			_stack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Spacing = 0,//10
				Padding = new Thickness(0,0,0,0)//20,0,20,0
			};
			Content = _stack;
		}

		public IList<View> Children {
			get {
				return _stack.Children;
			}
		}

		private bool _layingOutChildren;
		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			base.LayoutChildren (x, y, width, height);
			if (_layingOutChildren) return;

			_layingOutChildren = true;
			foreach (var child in Children) child.WidthRequest = width;// -40
			_layingOutChildren = false;
		}

		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create<CarouselView, IList<IAssessmentItemData>> (
				view => view.ItemsSource,
				null,
				propertyChanged: (bindableObject, oldValue, newValue) => {
					((CarouselView)bindableObject).ItemsSourceChanged ();
				}
			);

		public IList<IAssessmentItemData> ItemsSource {
			get {
				return (IList<IAssessmentItemData>)GetValue (ItemsSourceProperty);
			}
			set {
				SetValue (ItemsSourceProperty, value);
			}
		}

		void ItemsSourceChanged ()
		{
			_stack.Children.Clear ();
			if (ItemsSource == null)
				return;
			foreach (IAssessmentItemData item in ItemsSource) {
				var view = (View)ItemTemplate.CreateContent ();
				var bindableObject = view as QuestionView;
				if (bindableObject != null) {
					bindableObject.BindingContext = item;
				}
				_stack.Children.Add (view);
			}
			_stack.ForceLayout ();
			this.UpdateChildrenLayout ();
			this.ForceLayout ();
		}

		public DataTemplate ItemTemplate {
			get;
			set;
		}

		public static readonly BindableProperty SelectedItemProperty = 
			BindableProperty.Create<CarouselView, IAssessmentItemData> (
				view => view.SelectedItem,
				null,
				BindingMode.OneWay,
				propertyChanged: ((bindable, oldValue, newValue) => {
					Debug.WriteLine ("Triggered carousel view");
				})
			);

		public IAssessmentItemData SelectedItem {
			get {
				return (IAssessmentItemData)GetValue (SelectedItemProperty);
			}
			set {
				SetValue (SelectedItemProperty, value);
			}
		}

		public int SelectedIndex {

			get {
				if (null != ItemsSource)
					return ItemsSource.IndexOf (SelectedItem);
				else
					return 0;
			}
		}
	}
}


