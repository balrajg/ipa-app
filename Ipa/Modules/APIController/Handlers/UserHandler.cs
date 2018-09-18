using System;
using RestSharp.Portable;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using Acr.Settings;
using Plugin.DeviceInfo;

namespace Ipa
{
	public class UserHandler
	{
		public static async Task GetLogin(string userName, string password, Action<LoginResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/login", Method.PUT);
			var deviceToken = CrossSettings.Current.Get<string>(Constants.PUSH_TOKEN, "empty");

			LoginRequest _loginRequest = new LoginRequest{
				DeviceToken = deviceToken,
				UserName = userName,
				Password = password,
				DeviceID = CrossDeviceInfo.Current.Id
			};

			//_loginRequest.DeviceToken = "74c77fa7b8ff39ab9666a104fe3d47896723c56e91e40c4a5b079b1b61d3deb8";

			Debug.WriteLine(_loginRequest);
			request.AddBody (_loginRequest);
			Debug.WriteLine(JsonConvert.SerializeObject(_loginRequest));
			LoginResponse response = await APIServiceProvider.ServiceProvider.Execute<LoginResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
	
		public async static Task ResendPassword(string userName, Action<ForgetPasswodResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/forgotpassword",Method.PUT);
			ForgetPasswordRequest _ForgetPasswordRequest = new ForgetPasswordRequest {
				DeviceToken = CrossDeviceInfo.Current.Id,
				userName = userName
			};
			request.AddBody (_ForgetPasswordRequest);
			Debug.WriteLine(JsonConvert.SerializeObject(_ForgetPasswordRequest));
			ForgetPasswodResponse response = await APIServiceProvider.ServiceProvider.Execute<ForgetPasswodResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

		public static async Task GetProfile(string userName, Action<ViewProfileResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/viewprofile",Method.PUT);
			ViewProfileRequest _ViewProfileRequest = new ViewProfileRequest{
				UniqueAppId = App.UniqueAppId,
				UserName = userName
			};
					request.AddBody (_ViewProfileRequest);
					Debug.WriteLine(JsonConvert.SerializeObject(_ViewProfileRequest));
			ViewProfileResponse response = await APIServiceProvider.ServiceProvider.Execute<ViewProfileResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

		public static async Task UpdateProfile(Profile profileInfo, Action<UpdateProfileResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/updateprofile",Method.PUT);
			UpdateProfileRequest _updateProfileRequest = new UpdateProfileRequest{
				UniqueAppId = App.UniqueAppId,
				UserName = profileInfo.PersonalInfo.UserName,
				ProfileInfo = profileInfo
			};
			request.AddBody (_updateProfileRequest);
			Debug.WriteLine(JsonConvert.SerializeObject(_updateProfileRequest));
			UpdateProfileResponse response = await APIServiceProvider.ServiceProvider.Execute<UpdateProfileResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task FileUpload(Stream File, Action<string> successCallback, Action<string> errorCallback){

			RestRequest request = new RestRequest ("/lms/upload.php",Method.POST);
			string username = App.UserName + ".jpg";
			request.AddFile("fileToUpload",File,username,"image/*");

			string response = await APIServiceProvider.ServiceProvider.Execute(request);
			if ((response != null)) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((string)response); 
			}

		}

	}
}