using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chat.ChatHelper.Views
{
    public class BubbleLabel: Label
    {
		private bool _IsMyMessage;
        public bool IsMyMessage{
            set{
				if (_IsMyMessage != value) {
						_IsMyMessage = value;
				}
            }
            get{
                return _IsMyMessage;
            }
        }
    }
}
