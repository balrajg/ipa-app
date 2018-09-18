using System;
using Xamarin.Forms;

namespace Chat.ChatHelper.Views
{
	public class BubbleView: ContentView
	{
		private bool _IsMyMessage;
		public bool IsMyMessage{
			set{
				_IsMyMessage = value;
			}
			get{
				return _IsMyMessage;
			}
		}
	}
}

