using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ipa;

namespace Chat.ChatHelper.Views
{
    public class ChatListView: ListView
    {
        public ChatListView():base(){
            this.SeparatorVisibility = Xamarin.Forms.SeparatorVisibility.None;
            this.ItemTemplate = new DataTemplate(typeof(MessageViewCell));
            this.HasUnevenRows = true;
           
        }
    }
}
