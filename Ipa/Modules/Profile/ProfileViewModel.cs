using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using Plugin.Connectivity;
using Plugin.Media;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using RestSharp.Portable.Content;
using System.Net.Http;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace Ipa
{
	public class ProfileViewModel : ViewModelBase
	{
		private Profile _userProfile = new Profile ();
		private bool IsUpdateProfile;

		public ProfileViewModel ()
		{
			GetProfileInfo ();
			IsUpdateProfile = true; 
//			ErrorColor = Color.FromRgb (97, 97, 97);
//			ValidColor = Color.FromRgb (97, 97, 97);
//			InValidColor = Color.FromRgb (97, 97, 97);
//			EColor = Color.FromRgb (97, 97, 97);
		}

		public ProfileViewModel(Profile profile){
			_userProfile = profile;
//			ErrorColor = Color.FromRgb (97, 97, 97);
//			ValidColor = Color.FromRgb (97, 97, 97);
//			InValidColor = Color.FromRgb (97, 97, 97);
//			EColor = Color.FromRgb (97, 97, 97);
			IsBusy = false;
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

		public string FristName {
			set { 
				_userProfile.PersonalInfo.FullName = value;
				if (FristName.Length > 0) {
					ValidColor = Color.FromRgb (97, 97, 97);	
				} 
//				else {
//					ValidColor = Color.Red;
//				}
				RaisePropertyChanged (() => FristName);
			}
			get {
				return _userProfile.PersonalInfo.FullName;
			}
		}

		public string SurName {
			set { 
				_userProfile.PersonalInfo.SurName = value;
				if (SurName.Length > 0) {
					ErrorColor = Color.FromRgb (97, 97, 97);	
				} 
//				else {
//					ErrorColor = Color.Red;
//				}
				RaisePropertyChanged (() => SurName);
			}
			get { 
				return _userProfile.PersonalInfo.SurName;
			}
		}

		private bool _IsSelectedFile;

		public bool IsSelectedFile {
			set {
				if (Set (() => IsSelectedFile, ref _IsSelectedFile, value)) {
					RaisePropertyChanged (() => IsSelectedFile);
				}
			}
			get { 
				return _IsSelectedFile;
			}
		}

		private MediaFile _SelectedFile;

		public MediaFile SelectedFile {
			set {
				if (Set (() => SelectedFile, ref _SelectedFile, value)) {
					_SelectedFile = value;
					if (SelectedFile != null) {
						ProfileImage = ImageSource.FromStream (() => SelectedFile.GetStream ());
					}
				}
			}
			get { 
				return _SelectedFile;
			}
		}

		private ImageSource _ProfileImage = ImageSource.FromFile ("user_pic.png");

		public ImageSource ProfileImage {
			set { 
				if (Set (() => ProfileImage, ref _ProfileImage, value)) {
					RaisePropertyChanged ("ProfileImage");
				}
			}
			get {

				try {
					
					if(SelectedFile == null){
						
						UriImageSource image = (UriImageSource)UriImageSource.FromUri(new Uri (_userProfile.PersonalInfo.ProfileImage));
						image.CacheValidity = TimeSpan.FromMilliseconds(0);
						image.CachingEnabled = false;

						return (_ProfileImage = image);
					}else{
						return _ProfileImage;
					}
				} catch (Exception e) {
					Debug.WriteLine ("Can't form profile pic uri:>>" + _userProfile.PersonalInfo.ProfileImage);
					return _ProfileImage;
				}
			}
		}

		public string MobileNumber {
			set { 
				if (value != null) {
					_userProfile.PersonalInfo.Phone = value;
					if (MobileNumber.Length > 0) {
						InValidColor = Color.FromRgb (97, 97, 97);	
					} 
//					else {
//						InValidColor = Color.Red;
//					}
					RaisePropertyChanged (() => MobileNumber);
				}
			}
			get { 
				return _userProfile.PersonalInfo.Phone ?? string.Empty;
			}
		}

		public string MailId {
			set { 
				_userProfile.PersonalInfo.EmailId = value;
				if (MailId.Length > 0) {
					EColor = Color.FromRgb (97, 97, 97);	
				} 
//				else {
//					EColor = Color.Red;
//				}
				RaisePropertyChanged (() => MailId);
			}
			get { 
				return _userProfile.PersonalInfo.EmailId;
			}
		}

		public string EmpId {
			get { 
				return _userProfile.OrganizationInfo.EmpId;
			}
			set { 
				_userProfile.OrganizationInfo.EmpId = value;
				if (EmpId.Length > 0) {
					InValidColor = Color.FromRgb (97, 97, 97);
				} 
//				else {
//					InValidColor = Color.Red;
//				}
				RaisePropertyChanged (() => EmpId);
			}
		}

		public string OrganizationName {
			set { 
				_userProfile.OrganizationInfo.OrganizationName = value;
				if (OrganizationName.Length > 0) {
					ValidColor = Color.FromRgb (97, 97, 97);
				} 
//				else {
//					ValidColor = Color.Red;
//				}
				RaisePropertyChanged (() => OrganizationName);
			}
			get {
				return _userProfile.OrganizationInfo.OrganizationName;
			}
		}

		public string Designation {
			set { 
				_userProfile.OrganizationInfo.Designation = value;
				if (Designation.Length > 0) {
					EColor = Color.FromRgb (97, 97, 97);
				} 
//				else {
//					EColor = Color.Red;
//				}
				RaisePropertyChanged (() => Designation);
			}
			get {
				return _userProfile.OrganizationInfo.Designation;
			}
		}

		public string City {
			set { 
				_userProfile.OrganizationInfo.City = value;
				if (City.Length > 0) {
					ErrorColor = Color.FromRgb (97, 97, 97);
				} 
//				else {
//					ErrorColor = Color.Red;
//				}
				RaisePropertyChanged (() => City);
			}
			get { 
				return _userProfile.OrganizationInfo.City;
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

		private Color _EColor;

		public Color EColor {
			get { 
				return _EColor;
			}
			set { 
				if (Set (() => EColor, ref _EColor, value)) {
					RaisePropertyChanged (() => EColor);
				}
			}
		}

		private Color _InValidColor;

		public Color InValidColor {
			get { 
				return _InValidColor;
			}
			set { 
				if (Set (() => InValidColor, ref _InValidColor, value)) {
					RaisePropertyChanged (() => InValidColor);
				}
			}
		}

		private string _OldPassword;

		public string OldPassword {
			set { 
				if (Set (() => OldPassword, ref _OldPassword, value)) {
					
					RaisePropertyChanged (() => OldPassword);
				}
			}
			get { 
				return _OldPassword;
			}
		}

		private string _Password;

		public string Password {
			set { 
				if (Set (() => Password, ref _Password, value)) {
					if (Password.Length > 0) {
						ValidColor = Color.FromRgb (97, 97, 97);
					} 
//					else {
//						ValidColor = Color.Red;
//					}
					RaisePropertyChanged (() => Password);
				}
			}
			get { 
				return _Password;
			}
		}

		private string _ConfirmPassword;

		public string ConfirmPassword {
			set { 
				if (Set (() => ConfirmPassword, ref _ConfirmPassword, value)) {
					if (ConfirmPassword.Length > 0) {
						ErrorColor = Color.FromRgb (97, 97, 97);
					} 
//					else {
//						ErrorColor = Color.Red;
//					}
					RaisePropertyChanged (() => ConfirmPassword);
				}
			}
			get { 
				return _ConfirmPassword;
			}
		}

		#region Commands

		private RelayCommand _NextCmd;

		public RelayCommand NextCmd {
			get { 
				return _NextCmd ?? (_NextCmd = new RelayCommand (() => {	
					if (NavigationHandler.LoginNavigator.CurrentPage is SetupProfilePage) {
//						if (IsValidUpdateProfile ()) {
							SetupOrgPage _organisation = new SetupOrgPage ();
							_organisation.BindingContext = this;
							NavigationHandler.LoginNavigator.Navigation.PushAsync (_organisation);
//						} else {
//							if (string.IsNullOrEmpty (FristName) && string.IsNullOrEmpty (SurName) && string.IsNullOrEmpty (MobileNumber) && string.IsNullOrEmpty (MailId)) {
//								ValidColor = Color.Red;
//								ErrorColor = Color.Red;
//								InValidColor = Color.Red;
//								EColor = Color.Red;
//							} else if (string.IsNullOrEmpty (FristName)) {
//								ValidColor = Color.Red;
//							} else if (string.IsNullOrEmpty (SurName)) {
//								ErrorColor = Color.Red;
//							} else if (string.IsNullOrEmpty (MobileNumber)) {
//								InValidColor = Color.Red;
//							} else if (string.IsNullOrEmpty (MailId)) {
//								EColor = Color.Red;
//							} else {
//								EColor = Color.FromRgb (97, 97, 97);
//								InValidColor = Color.FromRgb (97, 97, 97);
//								ValidColor = Color.FromRgb (97, 97, 97);
//								ErrorColor = Color.FromRgb (97, 97, 97);
//							} 
//							NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.InSuccess, Constants.OK_TEXT);
//						}
					} else { 
//						if (IsValidOrgInfo ()) {
							SetupUpdatePwdPage _updatePassword = new SetupUpdatePwdPage ();
							_updatePassword.BindingContext = this;
							NavigationHandler.LoginNavigator.Navigation.PushAsync (_updatePassword); 
//						} else {
//							if (string.IsNullOrEmpty (EmpId) && string.IsNullOrEmpty (OrganizationName) && string.IsNullOrEmpty (Designation) && string.IsNullOrEmpty (City)) {	
//								ValidColor = Color.Red;
//								ErrorColor = Color.Red;
//								InValidColor = Color.Red;
//								EColor = Color.Red;
//							} else if (string.IsNullOrEmpty (OrganizationName)) {
//								ValidColor = Color.Red;
//							} else if (string.IsNullOrEmpty (City)) {
//								ErrorColor = Color.Red;
//							} else if (string.IsNullOrEmpty (EmpId)) {
//								InValidColor = Color.Red;
//							} else if (string.IsNullOrEmpty (Designation)) {
//								EColor = Color.Red;
//							} else {
//								EColor = Color.FromRgb (97, 97, 97);
//								InValidColor = Color.FromRgb (97, 97, 97);
//								ValidColor = Color.FromRgb (97, 97, 97);
//								ErrorColor = Color.FromRgb (97, 97, 97);
//							} 
//							NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.InSuccess, Constants.OK_TEXT);
//						}
					}
				}));
			}
		}

		private RelayCommand _SubmitCmd;

		public RelayCommand SubmitCmd {
			get { 
				return _SubmitCmd ?? (_SubmitCmd = new RelayCommand (() => {
					if(IsUpdateProfile)
						UpdateProfile ();
					else
						UpdatePassword ();
				}));
			}
		}

		private RelayCommand _SaveCmd;

		public RelayCommand SaveCmd {
			get { 
				return _SaveCmd ?? (_SaveCmd = new RelayCommand (() => {
					UpdateEditProfile ();
				}));
			}
		}

		private RelayCommand _ChangePasswordCmd;
		public RelayCommand ChangePasswordCmd{
			get{ 
				return _ChangePasswordCmd ?? (_ChangePasswordCmd = new RelayCommand(()=>{
					UpdatePassword();
				}));
			}
		}

		private RelayCommand _FromCameraCmd;

		public RelayCommand FromCameraCmd {
			get { 
				return _FromCameraCmd ?? (_FromCameraCmd = new RelayCommand (() => {
					DoFromCamera();
				}));
			}
		}

		private RelayCommand _FromGalleryCmd;

		public RelayCommand FromGalleryCmd {
			get { 
				return _FromGalleryCmd ?? (_FromGalleryCmd = new RelayCommand (() => {
					DoFromGallery ();
				}));
			}
		}

		private RelayCommand _BackBtnCmd;

		public RelayCommand BackBtnCmd {
			get { 
				return _BackBtnCmd ?? (_BackBtnCmd = new RelayCommand (() => {
					NavigationHandler.LoginNavigator.Navigation.PopAsync ();
				}));
			}
		}

		private RelayCommand _SettingBackBtnCmd;

		public RelayCommand SettingBackBtnCmd {
			get { 
				return _SettingBackBtnCmd ?? (_SettingBackBtnCmd = new RelayCommand (() => {
					NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
				}));
			}
		}

		#endregion

		private async void GetProfileInfo ()
		{
			if (CrossConnectivity.Current.IsConnected) { 
				IsBusy = true;
				await UserHandler.GetProfile (App.UserName,
					(responseProfile) => {
						this._userProfile = responseProfile.ProfileInfo;
						App.UserProfileImage = _userProfile.PersonalInfo.ProfileImage;
						SetProfileInfo ();
						IsBusy = false;
					},
					(errorResponseProfile) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;
					});
			} else {
				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}



		private void SetProfileInfo ()
		{
			RaisePropertyChanged (() => FristName);
			RaisePropertyChanged (() => SurName);
			RaisePropertyChanged (() => ProfileImage);
			RaisePropertyChanged (() => MailId);
			RaisePropertyChanged (() => City);
			RaisePropertyChanged (() => EmpId);
			RaisePropertyChanged (() => MobileNumber);
			RaisePropertyChanged (() => Designation);
			RaisePropertyChanged (() => OrganizationName);
			RaisePropertyChanged (() => Password);
			RaisePropertyChanged (() => ConfirmPassword);
		}
		private async void UpdatePassword ()
		{
			if (!string.IsNullOrEmpty (this.OldPassword) && this.OldPassword.Equals (App.Password)) {
				//				if (!string.IsNullOrEmpty (this.OldPassword)){
								if (Validator.IsPasswordMatch (Password, ConfirmPassword)) {

					this._userProfile.PersonalInfo.Password = Password;
					if (CrossConnectivity.Current.IsConnected) { 
						IsBusy = true;
						await UserHandler.UpdateProfile (_userProfile,
							(responseUpdateProfile) => {
								Debug.WriteLine ("Success" + responseUpdateProfile.ResponseCode);
								NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
								IsBusy = false;
							},
							(errorReponseUpdateProfile) => {
								NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.UpdateUnSuccess, Constants.OK_TEXT);
								IsBusy = false;
							});
					} else {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
					}
				} else {
					if (Validator.IsPasswordMatch (Password, ConfirmPassword)) {
						ErrorColor = Color.Red;
						ValidColor = Color.Red;

					} else if (string.IsNullOrEmpty (Password)) {
						ValidColor = Color.Red;
					} else if (string.IsNullOrEmpty (ConfirmPassword)) {
						ErrorColor = Color.Red;
					} else {
						ValidColor = Color.FromRgb (97, 97, 97);
						ErrorColor = Color.FromRgb (97, 97, 97);
					}
					NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.PASSWORD_MISMATCH, Constants.OK_TEXT);
				} 
			} else {

				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.OLD_PASSWORD_MISMATCH, Constants.OK_TEXT);
			}
		}
		private async void UploadImage ()
		{
			if (CrossConnectivity.Current.IsConnected) {
				IsBusy = true;
				await UserHandler.FileUpload (SelectedFile.GetStream(),
					(Response) => {
						Debug.WriteLine("Success");
						IsBusy = false;
					},

					(error) => {
						NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.ServerUnSuccess, Constants.OK_TEXT);
						IsBusy = false;

					});
			} else {
				NavigationHandler.GlobalNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
			}
		}

		private async void UpdateEditProfile()
		{

				if (CrossConnectivity.Current.IsConnected) { 
					IsBusy = true;
					if (SelectedFile != null) {
						UploadImage ();
					}
					await UserHandler.UpdateProfile (_userProfile,
						(responseUpdateProfile) => {
							Debug.WriteLine ("Success" + responseUpdateProfile.ResponseCode);
							NavigationHandler.GlobalNavigator.Navigation.PopAsync ();
							MessagingCenter.Send<ProfileViewModel>(this, "UpdateProfile");
									
							IsBusy = false;
						},
						(errorReponseUpdateProfile) => {
							NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.UpdateUnSuccess, Constants.OK_TEXT);
							IsBusy = false;
						});
				} else {
					NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
				}

		}

		private async void UpdateProfile ()
		{
			if (IsValidPassword ()) {
				_userProfile.PersonalInfo.Password = Password;
				App.Password = Password;
				if (SelectedFile != null) {
					UploadImage ();
				}

				if (CrossConnectivity.Current.IsConnected) { 
					IsBusy = true;
					await UserHandler.UpdateProfile (_userProfile,
						(responseUpdateProfile) => {
                            Debug.WriteLine("success in update profile page after passweord");
							Debug.WriteLine ("Success" + responseUpdateProfile.ResponseCode);
							App.CurrentApplication.GlobalViewModel = new MotherViewModel ();
							NavigationHandler.GlobalNavigator.Navigation.PopModalAsync ();
							IsBusy = false;
						},
						(errorReponseUpdateProfile) => {
							NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.UpdateUnSuccess, Constants.OK_TEXT);
							IsBusy = false;
						});
				} else {
					NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.NETWORK_ERROR, Constants.OK_TEXT);
				}
			} else {
				if (string.IsNullOrEmpty (Password) && string.IsNullOrEmpty (ConfirmPassword)) {
					ErrorColor = Color.Red;
					ValidColor = Color.Red;
				} else if (string.IsNullOrEmpty (Password)) {
					ValidColor = Color.Red;
				} else if (string.IsNullOrEmpty (ConfirmPassword)) {
					ErrorColor = Color.Red;
				} else {
					ValidColor = Color.FromRgb (97, 97, 97);
					ErrorColor = Color.FromRgb (97, 97, 97);
				}
				NavigationHandler.LoginNavigator.DisplayAlert (Constants.APP_NAME, Constants.PASSWORD_MISMATCH, Constants.OK_TEXT);
			}
		}

		public async void DoFromCamera ()
		{
			try
			{
				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				{
					return;
				}

				var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
				if (status != PermissionStatus.Granted)
				{
					if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
					{
						var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
						status = results[Permission.Camera];
					}

				}

				if (status == PermissionStatus.Granted)
				{
					var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
					{
						SaveToAlbum = false
					};
					var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
					if (file == null)
						return;
					SelectedFile = file;
				}
				else if (status != PermissionStatus.Unknown)
				{
					NavigationHandler.GlobalNavigator.DisplayAlert( Constants.APP_NAME, Constants.PERMISSION_DENIED , Constants.OK_TEXT);
				}

			}
			catch (Exception ex)
			{
				NavigationHandler.GlobalNavigator.DisplayAlert(Constants.APP_NAME, Constants.CAMERA_FAIL, Constants.OK_TEXT);
			}
		}

		public async void DoFromGallery ()
		{
			try
			{
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
				if (status != PermissionStatus.Granted)
				{
					if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
					{
						var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
						status = results[Permission.Storage];
					}
				}

				if (status == PermissionStatus.Granted)
				{
					if (!CrossMedia.Current.IsPickPhotoSupported)
					{
						NavigationHandler.GlobalNavigator.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
						return;
					}
					var file = await CrossMedia.Current.PickPhotoAsync();

					if (file == null)
						return;
					SelectedFile = file;
				}
				else if (status != PermissionStatus.Unknown)
				{
					NavigationHandler.GlobalNavigator.DisplayAlert(Constants.APP_NAME, Constants.PERMISSION_DENIED, Constants.OK_TEXT);
				}
			}
			catch (Exception ex)
			{
				NavigationHandler.GlobalNavigator.DisplayAlert( Constants.APP_NAME, Constants.GALLERY_FAIL, Constants.OK_TEXT);
			}
		}

//		private bool IsValidUpdateProfile ()
//		{
//			if (!string.IsNullOrEmpty (FristName) && !string.IsNullOrEmpty (SurName) && !string.IsNullOrEmpty (MobileNumber) && !string.IsNullOrEmpty (MailId)) {	
//				return true;
//			} else {
//				return false;
//			}
//		}
//
//		private bool IsValidOrgInfo ()
//		{
//			if (!string.IsNullOrEmpty (EmpId) && !string.IsNullOrEmpty (OrganizationName) && !string.IsNullOrEmpty (Designation) && !string.IsNullOrEmpty (City)) {	
//				return true;
//			} else {
//				return false;
//			}
//		}

		private bool IsValidPassword ()
		{
			if (!string.IsNullOrEmpty (Password) && !string.IsNullOrEmpty (ConfirmPassword) && Password.Equals (ConfirmPassword)) {
				return true;
			} else {
				return false;
			}
		}
	}
}

