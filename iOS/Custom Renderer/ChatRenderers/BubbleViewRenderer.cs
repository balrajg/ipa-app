using System;
using Xamarin.Forms;
using Chat.ChatHelper.Views;
using Chat.iOS.ChatRenderers;
using Xamarin.Forms.Platform.iOS;
using Chat.iOS.Views;
using UIKit;

[assembly: ExportRenderer(typeof(BubbleView), typeof(BubbleViewRenderer))]
namespace Chat.iOS.ChatRenderers
{
	public class BubbleViewRenderer: ViewRenderer<BubbleView, BubbleUIView>
	{
		BubbleUIView view;

		public BubbleViewRenderer ()
		{
			
		}

		protected override void OnElementChanged (ElementChangedEventArgs<BubbleView> e)
		{
			base.OnElementChanged (e);
			if (this.Element != null){
				
				if (this.Control == null) {
					view = new BubbleUIView () {
						IsMyMessage = this.Element.IsMyMessage
					};
					SetNativeControl (view);
				}
				else {
					view.IsMyMessage = this.Element.IsMyMessage;
				}
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName.Equals ("IsMyMessage")) {
				view.IsMyMessage = this.Element.IsMyMessage;
			} else if (e.PropertyName.Equals ("Width")) {
//				view.SetNeedsDisplay ();
			} else if (e.PropertyName.Equals ("Height")) {
//				view.SetNeedsDisplay ();
			}
		}


	}
}

