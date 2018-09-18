using System;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using Ipa;
using Ipa.iOS.Renderers;

[assembly: ExportRenderer(typeof(GalleryCarouselView), typeof(GalleryCarouselLayoutRenderer))]
namespace Ipa.iOS.Renderers
{
	public class GalleryCarouselLayoutRenderer :ScrollViewRenderer
	{
		UIScrollView _native;
		int SelectedIndex;

		public GalleryCarouselLayoutRenderer ()
		{
			PagingEnabled = true;
			ShowsHorizontalScrollIndicator = false;
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null) return;

			_native = (UIScrollView)NativeView;
			//			_native.Scrolled += NativeScrolled;
			e.NewElement.PropertyChanged += ElementPropertyChanged;
			//			_native.DraggingEnded += (sender, args) => {
			//				_
			//			}; 
			_native.Scrolled += NativeScrolled;
		}

		bool changed = false;
		void NativeScrolled (object sender, EventArgs e)
		{
			var center = _native.ContentOffset.X + (_native.Bounds.Width / 2);
			int currentIndex = ((int)center) / ((int)_native.Bounds.Width);
			if (SelectedIndex != currentIndex && !changed) {
				((GalleryCarouselView)Element).SelectedItem = ((GalleryCarouselView)Element).ItemsSource [currentIndex];
				this.SelectedIndex = currentIndex;
				changed = true;
				//				ScrollToSelection (false);
			} else {
				changed = false;
			}
		}

		void ElementPropertyChanged(object sender, PropertyChangedEventArgs e) {

			if (e.PropertyName.Equals (GalleryCarouselView.SelectedItemProperty.PropertyName) && !Dragging) {
				ScrollToSelection (false);//false
			}
		}

		void ScrollToSelection (bool animate)
		{
			if (Element == null) return;

			_native.SetContentOffset (new CoreGraphics.CGPoint 
				(((_native.Bounds.Width * 
					Math.Max(0, ((GalleryCarouselView)Element).SelectedIndex))), 
					_native.ContentOffset.Y),
				animate);// -( Math.Max(0, ((GalleryCarouselView)Element).SelectedIndex) * 30)
			this.SelectedIndex = ((GalleryCarouselView)Element).SelectedIndex;
		}

		public override void Draw(CoreGraphics.CGRect rect)
		{
			base.Draw (rect);
			ScrollToSelection (false);
		}
	}
}

