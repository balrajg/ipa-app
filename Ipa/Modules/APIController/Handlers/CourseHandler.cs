using System;
using RestSharp.Portable;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Ipa
{
	public class CourseHandler
	{
		public static async Task GetCourseList(string userName, Action<CourseListResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getcourselist", Method.PUT);	
			request.AddBody (new CourseListRequest(){
				UniqueAppId = App.UniqueAppId,
				UserName = userName
			});
			CourseListResponse response = await APIServiceProvider.ServiceProvider.Execute<CourseListResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

		public static async Task GetAssessmentList(string courseId,string activityId,string activityName,Action<GetAssesmentResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getassessment", Method.PUT);	
			GetAssesmentRequest _getAssesmentRequest= new GetAssesmentRequest(){
				UniqueAppId = App.UniqueAppId,
				CourseId = courseId,
				ActivityId = activityId,
				ActivityName = activityName
			};
			request.AddBody (_getAssesmentRequest);
			Debug.WriteLine(JsonConvert.SerializeObject(_getAssesmentRequest));
			GetAssesmentResponse response = await APIServiceProvider.ServiceProvider.Execute<GetAssesmentResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetSubmitAssessment(AssessmentData data, Action<SubmitAssessmentResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/submitassessment", Method.PUT);
			SubmitAssessmentRequest _SubmitAssessmentRequest = new SubmitAssessmentRequest (){
				UniqueAppId = App.UniqueAppId,
				Data = data
			};
			request.AddBody (_SubmitAssessmentRequest);
			Debug.WriteLine(JsonConvert.SerializeObject(_SubmitAssessmentRequest));

			SubmitAssessmentResponse response = await APIServiceProvider.ServiceProvider.Execute<SubmitAssessmentResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetActivityCompletedReport(string userName,string courseId,List<string> participantList, Action<ActivityCompletionReportResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getactivitycompletionreport", Method.PUT);	
			request.AddBody (new ActivityCompletionReport(){
				UniqueAppId = App.UniqueAppId,
				UserName = userName,
				CourseId = courseId,
				ParticipantList = participantList
			});
			ActivityCompletionReportResponse response = await APIServiceProvider.ServiceProvider.Execute<ActivityCompletionReportResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
                
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
	}
}

