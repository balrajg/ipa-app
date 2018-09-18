using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using RestSharp.Portable;
using Newtonsoft.Json;


namespace Ipa
{
	public class AttendanceHandler
	{
		public static async Task GetAttendance(string courseId,Action<GetAttendanceListReponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getattendancelist", Method.PUT);	
			request.AddBody (new GetAtendanceListRequest(){
				UniqueAppId = App.UniqueAppId,
				CourseID = courseId
			});
			GetAttendanceListReponse response = await APIServiceProvider.ServiceProvider.Execute<GetAttendanceListReponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetMarkAttendance(MarkAttendance markAttendance,Action<MarkAttendanceResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/markattendance", Method.PUT);	
			MarkAttendanceRequest requestData = new MarkAttendanceRequest () {
				UniqueAppId = App.UniqueAppId,
				MarkAttendanceData = markAttendance
			};
			Debug.WriteLine (JsonConvert.SerializeObject(requestData));
			request.AddBody (requestData);
			MarkAttendanceResponse response = await APIServiceProvider.ServiceProvider.Execute<MarkAttendanceResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

	}
}

