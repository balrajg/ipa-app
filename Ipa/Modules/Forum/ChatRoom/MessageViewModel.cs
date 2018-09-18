using Chat.ChatHelper.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Chat.ChatHelper.ViewModel;
using System.Collections.ObjectModel;

namespace Ipa
{
     class MessageViewModel :  IMessageViewModel
    {
        private Message _Message;

        public string UserName
        {
			get { return _Message.User; }
        }

		private static ImageSource _DefaultUserImage = ImageSource.FromFile ("user_pic.png");

        private UriImageSource _UserImage;
        public ImageSource UserImage
        {
            get { 
                // Return UserImage if any
				try{
	                return _UserImage ?? (_UserImage = new UriImageSource() { 
	                    CacheValidity  = new System.TimeSpan(8,0,0),
	                    CachingEnabled = true,
						Uri = new System.Uri(_Message.ImageUri)
	                });
				}catch{
					return _DefaultUserImage;
				}
            }
        }

        public MessageType Type
        {
            get { 
                //For now we supports only text 
                return MessageType.Text;
            }
        }
			
        public bool IsMyMessage
        {
            get {
				var res = _Message.User.ToUpper().Equals(App.UserName.ToUpper());
				return res;
            }
        }

        public string MessageText
        {
			get { return _Message.MessageText; }
        }

        public string SentTime
        {
			get { return _Message.Timestamp; }
        }

        public string FileUrl
        {
            get {
                // Url of the file If any
                return string.Empty;
            }
        }

        public MessageViewModel(Message message) {
            _Message = message;
        }
    }
     class GroupedMessageModel : ObservableCollection<MessageViewModel>
    {
        public GroupedMessageModel(string messageDate)
        {
            MessageDate = messageDate;
        }

        public string MessageDate
        {
            get;
             set;
        }
        
    }

}
