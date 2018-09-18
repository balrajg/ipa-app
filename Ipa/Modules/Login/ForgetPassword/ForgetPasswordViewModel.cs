using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Connectivity;

namespace Ipa
{
	public class ForgetPasswordViewModel : ViewModelBase
	{
		public ForgetPasswordViewModel ()
		{

		}
		private bool _CanShowClearButton;

		public bool CanShowClearButton {
			set { 
				if (Set (() => CanShowClearButton, ref  _CanShowClearButton, value)) {
					RaisePropertyChanged (() => CanShowClearButton);
				}
			}
			get {
				return _CanShowClearButton;
			}
		}

		private bool _IsBusy;

		public bool IsBusy {
			set { 
				if (Set (() => IsBusy, ref _IsBusy, value)) {
					RaisePropertyChanged (() => IsBusy);
				}
			}
			get { 
				return _IsBusy;
			}
		}

		private string _UserName;

		public string UserName {
			set { 
				if (Set (() => UserName, ref  _UserName, value)) {
					
					if (UserName.Length==0) {
						CanShowClearButton = false;
					} else {
						CanShowClearButton = true;
					}
					RaisePropertyChanged (() => UserName);
				}
			}
			get {
				return _UserName;
			}
		}
			
		#region Commands

		private RelayCommand _SubmitCmd;

		public RelayCommand SubmitCmd {
			get { 
				return _SubmitCmd ?? (_SubmitCmd = new RelayCommand (() => {
					ResendPassword ();
				}));
			}
		}
		private RelayCommand _ClearTextCmd;

		public RelayCommand ClearTextCmd {
			get { 
				return _ClearTextCmd ?? (_ClearTextCmd = new RelayCommand (() => {
					Clear ();
				}));
			}
		}
		private RelayCommand _BackCmd;

		public RelayCommand BackCmd {
			get { 
				return _BackCmd ?? (_BackCmd = new RelayCommand (() => {
					NavigationHandler.LoginNavigator.Navigation.PopAsync ();
				}));
			}
		}
		#endregion

		#region Methods
		void Clear()
		{
			UserName = string.Empty;
		}

		void ResendPassword ()
		{
			if (IsValidData ()) {
				if (CrossConnectivity.Current.IsConnected) { 
					IsBusy = true;
					UserHandler.ResendPassword (UserName,
						(response)=>{
							Debug.WriteLine("Success");
							NavigationHandler.LoginNavigator.DisplayAlert(Constants.APP_NAME, Constants.PASSWORD_CHANGE, Constants.OK_TEXT);
							NavigationHandler.LoginNavigator.Navigation.PopAsync ();
							IsBusy = false;
						},
						(errorResponse)=>{
							Debug.WriteLine("Error:: /nCode: "+errorResponse.ResponseCode+"/nMessage: "+errorResponse.Status);
							IsBusy = false;
						});
				} else {
					NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
				}
			} else {
				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.InSuccess, Constants.OK_TEXT);
			}
		}

		private bool IsValidData ()
		{
			if (string.IsNullOrEmpty (UserName) || string.IsNullOrWhiteSpace (UserName))
				return false;
			return true;
		}
		#endregion
	}
}

