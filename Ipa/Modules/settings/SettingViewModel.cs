using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ipa
{
	public class SettingViewModel : ViewModelBase
	{
		public SettingViewModel ()
		{
			GetProfileInfo ();
			MessagingCenter.Subscribe<ProfileViewModel> (this, "UpdateProfile", (sender) => {
				RaisePropertyChanged (() => ProfileImage);
				RaisePropertyChanged (() => FristName);
			});
		}

		private Profile _userProfile = new Profile ();

		public string FristName {
			set { 
				_userProfile.PersonalInfo.FullName = value;
				RaisePropertyChanged (() => FristName);
			}
			get {
				return _userProfile.PersonalInfo.FullName;
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
		public string AppVersion{
			get{
				return string.Format ("Version {0}", Constants.APP_VERSION);
			}
		}
		private ImageSource _ProfileImage = ImageSource.FromFile ("user_pic.png");

		public ImageSource ProfileImage {
			set { 
				if (Set (() => ProfileImage, ref _ProfileImage, value)) {
					RaisePropertyChanged (() => ProfileImage);
				}
			}
			get {
				try {
					UriImageSource image = (UriImageSource)UriImageSource.FromUri(new Uri (_userProfile.PersonalInfo.ProfileImage));
					image.CachingEnabled = false;

					return (_ProfileImage =image);
				} catch (Exception e) {
					Debug.WriteLine ("Can't form profile pic uri:>>" + _userProfile.PersonalInfo.ProfileImage);
					return _ProfileImage;// = ImageSource.FromFile ("default_image.png")); 
				}
			}
		}

		private RelayCommand _EditProfileCmd;

		public RelayCommand EditProfileCmd {
			get { 
				return _EditProfileCmd ?? (_EditProfileCmd = new RelayCommand (() => {
					DoEditProfile ();
				}));
			}
		}

		private RelayCommand _ChangePasswordCmd;

		public RelayCommand ChangePasswordCmd {
			get { 
				return _ChangePasswordCmd ?? (_ChangePasswordCmd = new RelayCommand (() => {
					DoChangePassword ();
				}));
			}
		}

		private RelayCommand _AboutUsCmd;

		public RelayCommand AboutUsCmd {
			get { 
				return _AboutUsCmd ?? (_AboutUsCmd = new RelayCommand (() => {
					DoAboutUs();
				}));
			}
		}

		private RelayCommand _TermsCondtionCmd;

		public RelayCommand TermsConditionCmd {
			get { 
				return _TermsCondtionCmd ?? (_TermsCondtionCmd = new RelayCommand (() => {
					DoTermsCondition();
				}));
			}
		}

		private RelayCommand _HowAppWorkCmd;

		public RelayCommand HowAppWorkCmd {
			get { 
				return _HowAppWorkCmd ?? (_HowAppWorkCmd = new RelayCommand (() => {
					DoHowthisAppWorks();
				}));
			}
		}
		public void DoAboutUs()
		{
			IsBusy = true;
			BrowserPage browserPage = new BrowserPage ();
			browserPage.BindingContext = new BrowserViewModel (string.Empty, "About Us", false);
			NavigationHandler.GlobalNavigator.PushAsync (browserPage);
			IsBusy = false;

		}
		public void DoTermsCondition()
		{
			IsBusy = true;
			TermsAndConditionPage _Page1 = new TermsAndConditionPage ();
			_Page1.BindingContext = new BrowserViewModel (string.Empty, "Terms & Conditons", false);
			NavigationHandler.GlobalNavigator.PushAsync (_Page1);
			IsBusy = false;


		}
		public void DoHowthisAppWorks()
		{
			IsBusy = true;

			HowthisAppWorksPage _Page = new HowthisAppWorksPage ();
			_Page.BindingContext = new BrowserViewModel (string.Empty, "How this App Works", false);
			NavigationHandler.GlobalNavigator.PushAsync (_Page);
			IsBusy = false;

		}
		public void DoChangePassword ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				ChangePwdPage _ChangePwdPage = new ChangePwdPage ();
				_ChangePwdPage.BindingContext = new ProfileViewModel (this._userProfile);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_ChangePwdPage);
				IsBusy = false;
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		public  void DoEditProfile ()
		{
//			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				EditProfilePage _EditProfilePage = new EditProfilePage ();
				_EditProfilePage.BindingContext = new ProfileViewModel (this._userProfile);
				NavigationHandler.GlobalNavigator.Navigation.PushAsync (_EditProfilePage);
				IsBusy = false;
//			} else {
//				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
//			}
		}


		public async void init ()
		{
			await GetProfileInfo ();
		}

		private async Task GetProfileInfo ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				await UserHandler.GetProfile (App.UserName,
					(responseProfile) => {
						this._userProfile = responseProfile.ProfileInfo;
						SetProfileInfo ();
						IsBusy = false;
					},
					(errorResponseProfile) => {
						NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.UpdateUnSuccess, Constants.OK_TEXT);
//						Debug.WriteLine ("Error:: /nCode: " + errorResponseProfile.ResponseCode + "/nMessage: " + errorResponseProfile.Status);
						IsBusy = false;
					});
			} else {
				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		public void SetProfileInfo ()
		{
			RaisePropertyChanged (() => FristName);
			RaisePropertyChanged (() => ProfileImage);
		}
	}
}


