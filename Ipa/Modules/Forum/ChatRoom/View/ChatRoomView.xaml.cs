using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Chat.ChatHelper.Views;
using System.Linq;

namespace Ipa
{
	public partial class ChatRoomView : ContentPage
	{
		ChatListView ChatView;

		public ChatRoomView ()
		{
			InitializeComponent ();

			NavigationPage.SetHasNavigationBar (this, false);

            /*ChatView = new ChatListView (){
				BackgroundColor = Color.FromHex ("#EEEEEE"),
				HorizontalOptions=LayoutOptions.FillAndExpand,
				VerticalOptions=LayoutOptions.FillAndExpand
			};
			ChatView.SetBinding (ChatListView.ItemsSourceProperty, "Messages");//SelectedMessage
			ChatView.SetBinding (ChatListView.SelectedItemProperty, "SelectedMessage",BindingMode.TwoWay); */
            ChatView = new ChatListView()
            {
                BackgroundColor = Color.FromHex("#EEEEEE"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
               // IsGroupingEnabled = true,
                //GroupDisplayBinding = new Binding("MessageDate"),
              //  GroupShortNameBinding = new Binding ("MessageDate"),
               
                //  GroupDisplayBinding = new Binding("MessageDate"),
                
            };
            
            ChatView.SetBinding(ChatListView.ItemsSourceProperty, "Messages");//SelectedMessage
            ChatView.SetBinding(ChatListView.SelectedItemProperty, "SelectedMessage", BindingMode.TwoWay);

            MyEntry messageEntry = new MyEntry {
				Placeholder = "Type your message here",
				FontSize=14,
				HeightRequest=25,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			messageEntry.SetBinding (Entry.TextProperty, "YourMessage");

			Image sendImg = new Image {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Source = ImageSource.FromFile ("send.png"),
				Aspect = Aspect.AspectFit
			};

			StackLayout sendBtn = new StackLayout(){
				HeightRequest = 25,
				WidthRequest = 25,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					sendImg
				}
			};
			sendBtn.SetBinding (StackLayout.IsVisibleProperty, "CanEnableSendBtn");
			sendBtn.GestureRecognizers.Add (new TapGestureRecognizer ((v,o)=>{
				((ChatRoomViewModel)this.BindingContext).SendCmd.Execute (null);
			}));

			ChatMessage.Children.Add (ChatView);
			ChatRoom.Children.Add (new StackLayout {
				BackgroundColor = Color.White,
				HeightRequest = 40,
				Spacing=0,
				VerticalOptions=LayoutOptions.End,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(10,10,10,10),
				Children = {
					messageEntry,
					sendBtn
				}
			});

//			ChatRoom
		}
		public void ToScrollMethod(){
			if (((ChatRoomViewModel)this.BindingContext).Messages != null && ((ChatRoomViewModel)this.BindingContext).Messages.Count > 0) {
				ChatView.ScrollTo (((ChatRoomViewModel)this.BindingContext).Messages.Last (), ScrollToPosition.End, false);
			}
		}
	}

}

