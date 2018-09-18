using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ipa
{
	public class GalleryCarouselView: ScrollView
	{
		readonly StackLayout _stack;

		public GalleryCarouselView ()
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
			BindableProperty.Create<GalleryCarouselView, IList<IWalkThroughData>> (
				view => view.ItemsSource,
				null,
				propertyChanged: (bindableObject, oldValue, newValue) => {
					((GalleryCarouselView)bindableObject).ItemsSourceChanged ();
				}
			);

		public IList<IWalkThroughData> ItemsSource {
			get {
				return (IList<IWalkThroughData>)GetValue (ItemsSourceProperty);
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
//			ImageSource defaultImage = ImageSource.FromFile ("default_image_large.png");
			foreach (IWalkThroughData item in ItemsSource) {
				var view = (View)ItemTemplate.CreateContent ();
				var bindableObject = view as WalkthroughView;
//				if (bindableObject != null) {
//					bindableObject.Source = defaultImage;
//					bindableObject.TargetUri = item;
//				}
				if (bindableObject != null) {
					bindableObject.BindingContext = item;
					bindableObject.Source = item.Source;
					bindableObject.Heading = item.Heading;
					bindableObject.DescriptionText = item.Description;
//					bindableObject.SetBinding (ExtendedImage.SourceProperty, ".");
				}
				_stack.Children.Add (view);
			}
			this.UpdateChildrenLayout ();
			//this.SelectedItem = ((IWalkThroughData) ((WalkthroughView)_stack.Children [0]).BindingContext);
			this.ForceLayout ();
		}

		public DataTemplate ItemTemplate {
			get;
			set;
		}

		public static readonly BindableProperty SelectedItemProperty = 
			BindableProperty.Create<GalleryCarouselView, IWalkThroughData> (
				view => view.SelectedItem,
				null,
				BindingMode.TwoWay,
				propertyChanged: ((bindable, oldValue, newValue) => {
					if(newValue != null)
						Debug.WriteLine ("Triggered carousel view "+newValue.Description);
					else
						Debug.WriteLine ("Triggered carousel view >>>> new value null");
				})
			);

		public IWalkThroughData SelectedItem {
			get {
				return (IWalkThroughData)GetValue (SelectedItemProperty);
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

