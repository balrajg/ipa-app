using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using RestSharp.Portable;
using Ipa.Modules.Forum.Model;

namespace Ipa
{
	public class ChatHandler 
	{
		public static async Task EnterChatRoom(string roomID,string courseID,string userName, Action<EnterChatRoomResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/enterchat", Method.PUT);	
			request.AddBody (new EnterChatRoomRequest(){
				UniqueAppId = App.UniqueAppId,
				RoomID=roomID,
				CourseID=courseID,
				UserName = userName
			});
			EnterChatRoomResponse response = await APIServiceProvider.ServiceProvider.Execute<EnterChatRoomResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

		public static async Task SendMessage(string roomID,string courseID,string userName,string msgText, Action<SendMessageResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/msgchat", Method.PUT);	
			request.AddBody (new SendMessageRequest(){
				UniqueAppId = App.UniqueAppId,
				RoomID=roomID,
				CourseID=courseID,
				UserName = userName,
				MsgText=msgText
			});
			SendMessageResponse response = await APIServiceProvider.ServiceProvider.Execute<SendMessageResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task ExitChat(string roomID,string courseID,string userName, Action<ExitChatResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/exitchat", Method.PUT);	
			request.AddBody (new ExitChatRequest(){
				UniqueAppId = App.UniqueAppId,
				RoomID=roomID,
				CourseID=courseID,
				UserName = userName
			});
			ExitChatResponse response = await APIServiceProvider.ServiceProvider.Execute<ExitChatResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetChatMessage(string roomID,string courseID, Action<GetChatMessageResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getchatmsgs", Method.PUT);	
			request.AddBody (new GetChatMessageRequest(){
				UniqueAppId = App.UniqueAppId,
				RoomID=roomID,
				CourseID=courseID
			});
			GetChatMessageResponse response = await APIServiceProvider.ServiceProvider.Execute<GetChatMessageResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
        public static async Task GetOthersMessage(String roomId, String CourseId, String userName, Action<GetChatMessageResponse> successCallBack, Action<ResponseBase> errorCallback)
        {
            RestRequest request = new RestRequest("/lms/api/getothersmessages", Method.PUT);
            request.AddBody(new GetOthersMessageRequest()
            {

            });
            GetChatMessageResponse response = await APIServiceProvider.ServiceProvider.Execute<GetChatMessageResponse>(request);
            if ((response != null) && (response.ResponseCode == "1000"))
            {
                successCallBack?.Invoke(response);
            }
            else
            {
                errorCallback?.Invoke((ResponseBase)response);
            }
        }

        public static async Task GetChatRoom(Action<GetChatRoomResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getchatrooms", Method.PUT);	
			request.AddBody (new GetChatRoomRequest(){
				
			});
			GetChatRoomResponse response = await APIServiceProvider.ServiceProvider.Execute<GetChatRoomResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
	}
}


