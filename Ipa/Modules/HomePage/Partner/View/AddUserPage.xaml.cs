using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class AddUserPage : ContentPage
	{
		public AddUserPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			AddUserItem();
			AddUserBtn.GestureRecognizers.Add (new TapGestureRecognizer((obj) => {
				AddUserItem();
			}));

			SendBtn.GestureRecognizers.Add (new TapGestureRecognizer((v, obj) => {
				if(IsValid()){
					List<ParticipantList> participantList = new List<ParticipantList>();
					foreach(AddUserItemView view in AddUserStackLayout.Children){
						participantList.Add (new ParticipantList(){
							FullName = view.EmpId,
							EmpID = view.EmpId
						});
					}
					((AddUserViewModel)this.BindingContext).SendCmd.Execute (participantList);

				}else{
					NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, "All fields are mandatory.", Constants.OK_TEXT);
				}
			}));
		}

		public void AddUserItem()
		{
			AddUserItemView _ViewItem = new AddUserItemView ();
			_ViewItem.OnRemoveClicked += ( sender, args) => {
				RemoveUser ((AddUserItemView)sender);	
			};
			AddUserStackLayout.Children.Add (_ViewItem);
		}

		public void RemoveUser(AddUserItemView view)
		{
			AddUserStackLayout.Children.Remove (view);
		}

		private bool IsValid(){
			foreach(AddUserItemView view in AddUserStackLayout.Children){
				if (string.IsNullOrEmpty (view.EmpId) || string.IsNullOrEmpty (view.Name))
					return false;
			}
			return true;
		}

	}
}

