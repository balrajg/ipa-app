using System;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace Ipa
{
	public class ForumListItemViewModel: ViewModelBase
	{
		private ChatRoomDetail _ChatRoom;

		public ChatRoomDetail ChatDetail{
			get{
				return _ChatRoom;
			}
		}

		public ForumListItemViewModel (ChatRoomDetail chatRoom)
		{
			_ChatRoom = chatRoom;
		}

		public string RoomName{
			get{
				return _ChatRoom.RoomName;
			}
		}

		public string LastUserName{
			get{ 
				return _ChatRoom.LastUser;
			}
		}

		public string LastMessage{
			get{ 
				return _ChatRoom.LastMessage;
			}
		}

		private ImageSource _LastUserImage;
		public ImageSource LastUserImage{
			get{ 
				return _LastUserImage ?? (_LastUserImage = ImageSource.FromUri (new Uri(_ChatRoom.ProfileImage)));
			}
		}

		public string LastMessageTime{
			get{ 
				return _ChatRoom.LastMessageTimestamp;
			}
		}

		public void UpdateLastMessage(Message message){
			_ChatRoom.LastUser = message.User;
			_ChatRoom.LastMessage = message.MessageText;
			_ChatRoom.LastMessageTimestamp = message.Timestamp;
			_ChatRoom.ProfileImage = message.ImageUri;
			RaisePropertyChanged ("LastUserImage");
			RaisePropertyChanged ("LastMessage");
			RaisePropertyChanged ("LastMessageTime");
			RaisePropertyChanged ("LastUserName");
		}
	}
}

