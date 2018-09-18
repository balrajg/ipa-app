using Chat.ChatHelper.ViewModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System.Diagnostics;
using Xamarin.Forms;

namespace Ipa
{
    class ChatRoomViewModel: ViewModelBase
    {
		private ChatRoomDetail _RoomDetail;
		private bool _IsEntered = false;

		private bool _IsBusy;
		public bool IsBusy{
			get{ 
				return _IsBusy;
			}
			set{
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					RaisePropertyChanged (() => IsBusy);
				}
			}

		}

		public string RoomName{
			get{ 
				return _RoomDetail.RoomName;
			}
		}
		public string ImageProfile{
			get{ 
				return _RoomDetail.ProfileImage;
			}
		}
		public string MembersCount{
			get{ 
				return string.Format ("{0} Members", _RoomDetail.TotalUserCount);
			}
		}

        ObservableCollection<IMessageViewModel> _Messages;
        public ObservableCollection<IMessageViewModel> Messages {
			set {
				if (Set (() => Messages, ref _Messages, value)) {
					RaisePropertyChanged (() => Messages);
					_Page.ToScrollMethod ();
				}
			}
			get {
				return _Messages ?? (_Messages = new ObservableCollection<IMessageViewModel> ());
			}
		}
        public ObservableCollection<GroupedMessageModel> _groupedMessage;
        public ObservableCollection<GroupedMessageModel> groupedMessage
        {
            set
            {
                if (Set(() => groupedMessage, ref _groupedMessage, value))
                {
                    RaisePropertyChanged(() => groupedMessage);
                    _Page.ToScrollMethod();
                }
            }
            get
            {
                return _groupedMessage ?? (_groupedMessage = new ObservableCollection<GroupedMessageModel>());
            }
        }
        private IMessageViewModel _SelectedMessage;
		public IMessageViewModel SelectedMessage{
			set{ 
				_SelectedMessage = value;
				RaisePropertyChanged (()=> SelectedMessage);
				if (_SelectedMessage != null)
					SelectedMessage = null;
//				if (Set (() => SelectedMessage, ref _SelectedMessage, value)) {
//					RaisePropertyChanged (()=> SelectedMessage);
//				}
			}
			get{ 
				return _SelectedMessage;
			}
		}

		private string _YourMessage;
		public string YourMessage{
			set{
				if (Set (() => YourMessage, ref _YourMessage, value)) {
					RaisePropertyChanged (() => YourMessage);
				}
					RaisePropertyChanged (() => CanEnableSendBtn);
			}
			get{
					return _YourMessage;
			}
		}


		public bool CanEnableSendBtn{
			get{ 
				return ((YourMessage != null) && (YourMessage.Length > 0)) ? true : false;
			}
		}

		private RelayCommand _SendCmd;
		public RelayCommand SendCmd{
			get{ 
				return _SendCmd ?? (_SendCmd = new RelayCommand(()=>{
					SendMessage();
				}));
			}
		}


		private RelayCommand _BackCmd;
		public RelayCommand BackCmd{
			get{ 
				return _BackCmd ?? (_BackCmd = new RelayCommand(()=> {
					DoBack();

				} ));
			}
		}
		public async void DoBack()
		{
			IsBusy = true;
			await ExitChat ();
			MessagingCenter.Send<ChatRoomViewModel>(this, "LastMessage");
			NavigationHandler.GlobalNavigator.Navigation.PopAsync(true);
			IsBusy = false;
		}
		private ChatRoomView _Page;
		public ChatRoomViewModel(ChatRoomView page,ChatRoomDetail details){
			_Page = page;
			_RoomDetail = details;
			GetMessages ();
			EnterChat ();
           // initializeTimer();
            // MessagingCenter.Send<ChatRoomViewModel,Message>(this, "LastMessage",message);
        }


        void initializeTimer()
        {

           // Device.StartTimer(System.TimeSpan.FromSeconds(60), () => { Debug.WriteLine("Called in interval of 2 seconds"); return true; });

        }
      
        private async Task SendMessage(){
			if (CrossConnectivity.Current.IsConnected) {
                DateTime now = DateTime.Now;
                var message = new Message
                {
                    User = App.UserName,
                    MessageText = YourMessage,
                    Timestamp = now.ToString("hh:mm dd-MMM"),
                    ImageUri = App.UserProfileImage
                };
                Messages.Add(new MessageViewModel(message));
                YourMessage = string.Empty;
                 _Page.ToScrollMethod();

                ChatHandler.SendMessage (_RoomDetail.RoomID, _RoomDetail.CourseID, App.UserName, message.MessageText, 
					(response) => {
						
                        MessagingCenter.Send<ChatRoomViewModel,Message>(this, "LastMessage",message);
						
						
						IsBusy=false;

					},
					(error) => {
                        Messages.RemoveAt(Messages.Count);
                        NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, "'"+ message.MessageText +"'" + Constants.MESSAGE_SENT_UNSUCCESSFULL , Constants.OK_TEXT);
					});
			} else {
               
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private async Task GetMessages(){
			if (CrossConnectivity.Current.IsConnected) {
				ChatHandler.GetChatMessage (_RoomDetail.RoomID, _RoomDetail.CourseID,
					(response)=>
					{
						GetViewModel(response.ChatData);
					},
					(error)=>
					{
					//Todo
						NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME,"Chat Room Is Empty", Constants.OK_TEXT);
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}
        // To synchronize new recieved messages == initializeTimer
        private async Task ReieveOthersMessages()
        {
            String LastUpdatedTime = "balraj";
            if (CrossConnectivity.Current.IsConnected)
            {
                ChatHandler.GetOthersMessage(_RoomDetail.RoomID, _RoomDetail.CourseID, App.UserName,
                    (response) =>
                    {
                        GetViewModel(response.ChatData);
                    },
                    (error) =>
                    {
                        //Todo
                        NavigationHandler.LoginNavigator.DisplayAlert(Constants.APP_NAME, "Chat Room Is Empty", Constants.OK_TEXT);
                    });
            }
            else
            {
                NavigationHandler.GlobalNavigator.DisplayAlert(Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
            }
        }
		private async Task EnterChat(){
			if (CrossConnectivity.Current.IsConnected) {
				ChatHandler.EnterChatRoom (_RoomDetail.RoomID, _RoomDetail.CourseID, App.UserName, 
					(response) => {
						//user enters into the chat.
						_IsEntered = true;
					},
					async (error) => {
						_IsEntered= false;
						await NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						NavigationHandler.GlobalNavigator.PopAsync ();
					}
				);
			} else {
				NavigationHandler.ForumNavigator.DisplayAlert (Constants.APP_NAME, this.YourMessage, Constants.OK_TEXT);
			}
		}

		private async Task ExitChat(){
			if (CrossConnectivity.Current.IsConnected) {
				ChatHandler.ExitChat (_RoomDetail.RoomID, _RoomDetail.CourseID, App.UserName, 
					(response)=>{
						//user exits from chat 
						_IsEntered = false;
					},
					(error)=>{
						NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
					}
				);
			} else {
				NavigationHandler.ForumNavigator.DisplayAlert (Constants.APP_NAME, this.YourMessage, Constants.OK_TEXT);
			}
		}
		private bool _IsMyMessage;
		public bool IsMyMessage{
			set{ 
				_IsMyMessage = value;

			}
			get{ 
				return _IsMyMessage;
			}
		}
    
		private void GetViewModel(List<Message> messageList){
			ObservableCollection<IMessageViewModel> chatMessages = new ObservableCollection<IMessageViewModel> ();
			foreach (Message msg in messageList) {
				MessageViewModel vm = new MessageViewModel (msg);
				chatMessages.Add (vm);
			}

			Messages = chatMessages;
		}
        /*
        private void GetViewModel(List<Message> messageList)
        {
            ObservableCollection<IMessageViewModel> chatMessages = new ObservableCollection<IMessageViewModel>();
            ObservableCollection<GroupedMessageModel> chatMessageGrouped = new ObservableCollection<GroupedMessageModel>();
            var firstGroup = new GroupedMessageModel("0-10") ;
            int msgCount = 0;
            foreach (Message msg in messageList)
            {
                MessageViewModel vm = new MessageViewModel(msg);
                chatMessages.Add(vm);
                if (msgCount == 10)
                {
                    chatMessageGrouped.Add(firstGroup);
                    firstGroup.Clear();
                    msgCount = 0;
                }
            }
            groupedMessage = chatMessageGrouped;
            Messages = chatMessages;
        }*/
    }
}
