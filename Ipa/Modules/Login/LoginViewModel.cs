using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Connectivity;
using Acr.Settings;

namespace Ipa
{
	public class LoginViewModel : ViewModelBase
	{
		public LoginViewModel ()
		{
			CanShowPassword = true;
			Password = string.Empty;
			OnClickedEyeImage = ImageSource.FromFile ("show_password.png");
			ErrorColor = Color.FromRgb (97, 97, 97);
			ValidColor = Color.FromRgb (97, 97, 97);
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

		private bool _CanShowPassword;

		public bool CanShowPassword {
			set {
				if (Set (() => CanShowPassword, ref _CanShowPassword, value)) {
					RaisePropertyChanged (() => CanShowPassword);
				}
			}
			get { 
				return _CanShowPassword;
			}
		}

		private string _UserName;

		public string UserName {
			set { 
				if (Set (() => UserName, ref  _UserName, value)) {
					if (UserName.Length > 0) {
						ValidColor = Color.FromRgb (97, 97, 97);
					} else {
						ValidColor = Color.Red;
					}
					RaisePropertyChanged (() => UserName);
				}
			}
			get {
				return _UserName;
			}
		}

		private ImageSource _OnClickedEyeImage;

		public ImageSource OnClickedEyeImage {
			get { 
				return _OnClickedEyeImage;
			}
			set { 
				if (Set (() => OnClickedEyeImage, ref _OnClickedEyeImage, value)) {
					RaisePropertyChanged (() => OnClickedEyeImage);
				}
			}
		}

		private Color _ErrorColor;

		public Color ErrorColor {
			get { 
				return _ErrorColor;
			}
			set { 
				if (Set (() => ErrorColor, ref _ErrorColor, value)) {
					RaisePropertyChanged (() => ErrorColor);
				}
			}
		}

		private Color _ValidColor;

		public Color ValidColor {
			get { 
				return _ValidColor;
			}
			set { 
				if (Set (() => ValidColor, ref _ValidColor, value)) {
					RaisePropertyChanged (() => ValidColor);
				}
			}
		}

		private string _Password;

		public string Password {
			get { 
				return _Password;
			}
			set { 
				if (Set (() => Password, ref _Password, value)) {
					if (Password.Length < 0) {						
						CanShowPassword = false;
						ErrorColor = Color.Red;

					} else {
//						CanShowPassword = true;
						ErrorColor = Color.FromRgb (97, 97, 97);

					}
					RaisePropertyChanged (() => Password);
				}
			}
		}

		private RelayCommand _ShowPasswordCmd;

		public RelayCommand ShowPasswordCmd {
			get { 
				return _ShowPasswordCmd ?? (_ShowPasswordCmd = new RelayCommand (() => {
					ShowPassword ();
				}));
			}
		}

		private RelayCommand _LoginCmd;

		public RelayCommand LoginCmd {
			get { 
				return _LoginCmd ?? (_LoginCmd = new RelayCommand (() => {
					DoLogin ();
				}));
			}
		}

		private RelayCommand _ForgetPasswordCmd;

		public RelayCommand ForgetPasswordCmd {
			get { 
				return _ForgetPasswordCmd ?? (_ForgetPasswordCmd = new RelayCommand (() => {
					LaunchForgetPasswordScreen ();
				}));
			}
		}

		#region Methods

		public async void DoLogin ()
		{
			if (IsValidData ()) {
				if (CrossConnectivity.Current.IsConnected) { 
					IsBusy = true;
					if (!App.IsRegistered)
					{
						DeviceInfoHandler.UpdateDeviceInfo((response) =>
						{
							Debug.WriteLine("Device info updated.");
							App.IsRegistered = true;
						});
					}
					await UserHandler.GetLogin (UserName, Password, 
						(response) => {
							try {
								Debug.WriteLine ("success:" + response.UniqueAppId);
								App.UserName = UserName;
								App.UniqueAppId = response.UniqueAppId;
                                CrossSettings.Current.Set("IsLogin", true);
                                IsBusy = false;
                                // NavigationHandler.GlobalNavigator.Navigation.PopAsync(); //Navigate to main page after successful login
                                // SetupUpdatePwdPage _ChangePassword = new SetupUpdatePwdPage();
                                //_ChangePassword.BindingContext = new ProfileViewModel();
                                //NavigationHandler.LoginNavigator.Navigation.PushAsync (_ChangePassword); //navigate to update password page

                                App.CurrentApplication.GlobalViewModel = new MotherViewModel();
                                NavigationHandler.GlobalNavigator.Navigation.PopModalAsync();


                            } catch (Exception e) {
								Debug.WriteLine ("Exception is " + e.Message + " \n source: " + e.Source + " call stack :" + e.StackTrace);
							}
						},
						(errorResponse) => {
							NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.LoginUnSuccess, Constants.OK_TEXT);
							IsBusy = false;
						});
				} else {
					NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
				}

			} else {
				if (string.IsNullOrEmpty (UserName) && string.IsNullOrEmpty (Password)) {
					ErrorColor = Color.Red;
					ValidColor = Color.Red;
				} else if (string.IsNullOrEmpty (Password)) {
					ErrorColor = Color.Red;
				} else if (string.IsNullOrEmpty (UserName)) {
					ValidColor = Color.Red;
				} else {
					ValidColor = Color.FromRgb (97, 97, 97);
					ErrorColor = Color.FromRgb (97, 97, 97);
				}
				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.InSuccess, Constants.OK_TEXT);
			}
		}

		public void ShowPassword ()
		{
			if (CanShowPassword) {
				OnClickedEyeImage = ImageSource.FromFile ("eye.png");
				CanShowPassword = false;
			} else {
				OnClickedEyeImage = ImageSource.FromFile ("show_password.png");
				CanShowPassword = true;
			}
		}

		public void LaunchForgetPasswordScreen ()
		{
			NavigationHandler.LoginNavigator.Navigation.PushAsync (new ForgetPasswordPage ());
		}

		private bool IsValidData ()
		{
			if (!string.IsNullOrEmpty (UserName) && !string.IsNullOrEmpty (Password)) {			
				return true;
			} else {
				return false;
			}
		}

		#endregion
	}
}