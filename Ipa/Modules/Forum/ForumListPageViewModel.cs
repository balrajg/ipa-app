using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using System.Diagnostics;

namespace Ipa
{
	public class ForumListPageViewModel: ViewModelBase
	{
		private List<ForumListItemViewModel> ForumListData;

		private bool _IsBusy;

		public bool IsBusy {
			get { 
				return _IsBusy;
			}
			set {
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					RaisePropertyChanged (() => IsBusy);
				}
			}

		}

		private List<ForumListItemViewModel> _RawForumList = new List<ForumListItemViewModel> ();

		public List<ForumListItemViewModel> RawForumList {
			set { 
				_RawForumList = value;
			}
			get {

				return _RawForumList;
			}
		}

		private string _SearchText;

		public string SearchText {
			set { 
				if (Set (() => SearchText, ref _SearchText, value)) {
					RaisePropertyChanged (() => SearchText);
					if ((SearchText != null) && (SearchText.Length > 0)) {
						Search ();
					} else {
						if (ForumList.Count != RawForumList.Count)
							ForumList = new ObservableCollection<ForumListItemViewModel> (RawForumList);
					}

				}
			}
			get { 
				return _SearchText;
			}
		}

		private ObservableCollection<ForumListItemViewModel> _ForumList;

		public ObservableCollection<ForumListItemViewModel> ForumList {
			get { 
				return _ForumList;
			}
			set { 
				if (Set (() => ForumList, ref _ForumList, value)) {
					if (ForumList.Count > 0) {
						IsForum = true;
					} else {
						IsForum = false;
					}
					RaisePropertyChanged (() => ForumList);
				}
			}
		}
		private bool _IsForum;

		public bool IsForum {
			get { 
				return _IsForum;
			}
			set { 
				if (Set (() => IsForum, ref _IsForum, value)) {
					RaisePropertyChanged (() => IsForum);
				}
			}
		}

		private ForumListItemViewModel _SelectedForum;

		public ForumListItemViewModel SelectedForum {
			get { 
				return _SelectedForum;
			}
			set { 
				_SelectedForum = value;
				if (_SelectedForum != null) {
					OnForumSelected ();
				}
				RaisePropertyChanged (() => SelectedForum);
			}
		}

		private List<Course> CourseList;

		public ForumListPageViewModel (List<Course> courseList)
		{
			FetchForumDetails (courseList);
			CourseList = courseList;
			MessagingCenter.Subscribe<ChatRoomViewModel,Message> (this, "LastMessage", (sender,arg) => {
				foreach ( var forumRoom in ForumList){
					if(forumRoom.RoomName.Equals(sender.RoomName))
					{
						forumRoom.UpdateLastMessage(arg);
						break;
					}
				}
			});
		}


		private async Task FetchForumDetails (List<Course> CourseList)
		{
			if (CrossConnectivity.Current.IsConnected) {
				ChatHandler.GetChatRoom (
					(response) => {
						this.GetForumViewModel (response.ChatRoomData, CourseList);
					},
					(errorResponse) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private async Task GetForumViewModel (List<ChatRoomDetail> forumList, List<Course> courseList)
		{
			ObservableCollection<ForumListItemViewModel> forumViewModelList = new ObservableCollection<ForumListItemViewModel> ();
			foreach (var course in courseList) {
				foreach (ChatRoomDetail item in forumList) {
					if (course.CourseId == item.CourseID) {
						ForumListItemViewModel vm = new ForumListItemViewModel (item);
						RawForumList.Add (vm);
					}
				}
			}
			ForumList = new ObservableCollection<ForumListItemViewModel> (RawForumList);
		}
		public void RaiseProperty(){
			RaisePropertyChanged (() => ForumList);
		}
	
		private void OnForumSelected ()
		{
			ChatRoomView page = new ChatRoomView ();
			ChatRoomViewModel viewModel = new ChatRoomViewModel (page,this.SelectedForum.ChatDetail);
			page.BindingContext = viewModel;

			NavigationHandler.GlobalNavigator.Navigation.PushAsync (page);
			SelectedForum = null;
		}

		private async Task Search ()
		{
			ForumList = new ObservableCollection<ForumListItemViewModel> (RawForumList.FindAll ((vm) => { 
				return vm.RoomName.Contains (SearchText);
			}
			));
		}
	}
}

