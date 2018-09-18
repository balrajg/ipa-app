using System;
using UIKit;

namespace Chat.iOS.Views
{
	public class BubbleUIView : UIImageView
	{
//		static UIImage MyChatBackground =  UIImage.FromBundle ("MyChatBg");
//		static UIImage OthersChatBackground = UIImage.FromBundle ("OthersChatBg");

		public BubbleUIView ()
		{
			UpdateBackgroundImage ();
		}

		private bool _IsMyMessage;
		public bool IsMyMessage{
			set{
				if (IsMyMessage != value) {
					_IsMyMessage = value;
					this.UpdateBackgroundImage ();
				}
			}
			get{ 
				return _IsMyMessage;
			}
		}

		private void UpdateBackgroundImage(){

			UIImage img;
			if(this.IsMyMessage)
				img = UIImage.FromBundle ("MyChatBg");
			else
				img = UIImage.FromBundle ("OthersChatBg");

			this.Image = img;
		}


	}
}

