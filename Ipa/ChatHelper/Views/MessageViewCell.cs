using Chat.ChatHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ipa;

namespace Chat.ChatHelper.Views
{
    public class MessageViewCell: ViewCell
    {
        public MessageViewCell() { 
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            IMessageViewModel vm = this.BindingContext as IMessageViewModel;
            if (vm.Type == Model.MessageType.Text) {
				TextMessageView view = new TextMessageView(vm.IsMyMessage);
                /*view.SetBinding(TextMessageView.MessageTextProperty, vm.MessageText);
                view.SetBinding(TextMessageView.UserNameProperty, vm.UserName);
                view.SetBinding(TextMessageView.TimeStampProperty, vm.SentTime);
                 * */
                view.Name = vm.UserName;
                view.MessageText = vm.MessageText;
                view.SentTime = vm.SentTime;
				view.IsMyMessage = vm.IsMyMessage;
                view.ProfileImageSource = vm.UserImage;
                this.View = view;
            }
        }
    }
}
