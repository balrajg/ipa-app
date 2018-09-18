using System;
using RestSharp.Portable;
using System.Threading.Tasks;

namespace Ipa
{
	public class ReportHandler
	{
		public static async Task GetReporteeList(string userName,string courseId,Action<GetReporteeListResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getreporteelist", Method.PUT);	
			request.AddBody (new GetReproteeListRequest(){
				UniqueAppId = App.UniqueAppId,
				UserName = userName ,
				CourseID = courseId
			});
			GetReporteeListResponse response = await APIServiceProvider.ServiceProvider.Execute<GetReporteeListResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

		public static async Task GetAddParticipantList(AddParticipant addParticipant, Action<AddParticipantResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/addparticipant",Method.PUT);
			request.AddBody(new AddParticipantRequest{
				UniqueAppId = App.UniqueAppId,
				AddParticipantInfo  = addParticipant
			});
				AddParticipantResponse response = await APIServiceProvider.ServiceProvider.Execute<AddParticipantResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

		public static async Task GetUserReport(string userName,string courseId,Action<UserReportResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/userreport", Method.PUT);	
			request.AddBody (new UserReportRequest(){
				UniqueAppId = App.UniqueAppId,
				UserName = userName ,
				CourseID = courseId
			});
			UserReportResponse response = await APIServiceProvider.ServiceProvider.Execute<UserReportResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetBatchReportManager(string userName,string courseId,Action<GetBatchReportManagerResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getbatchreportbymgr", Method.PUT);	
			request.AddBody (new GetBatchReportManagerRequest(){
				UniqueAppId = App.UniqueAppId,
				UserName = userName ,
				CourseID = courseId
			});
			GetBatchReportManagerResponse response = await APIServiceProvider.ServiceProvider.Execute<GetBatchReportManagerResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetBatchReport(string courseId,Action<GetBatchReportManagerResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getbatchreport", Method.PUT);	
			request.AddBody (new BatchReportRequest(){
				UniqueAppId = App.UniqueAppId,
				CourseID = courseId
			});
			GetBatchReportManagerResponse response = await APIServiceProvider.ServiceProvider.Execute<GetBatchReportManagerResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetReporteeListForAllCourse(string userName,Action<ReporteeListForAllCourseResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getreporteelistforallcourse", Method.PUT);	
			request.AddBody (new ReporteeListForAllCourse(){
				UniqueAppId = App.UniqueAppId,
				UserName = userName
			});
			ReporteeListForAllCourseResponse response = await APIServiceProvider.ServiceProvider.Execute<ReporteeListForAllCourseResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}

		public static async Task GetRateParticipant(ParticipantRating participantRating,Action<RateParticipantReponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/rateparticipant", Method.PUT);	
			request.AddBody (new RateParticipantRequest(){
				UniqueAppId = App.UniqueAppId,
				ParticipantRatingData = participantRating
			});
			RateParticipantReponse response = await APIServiceProvider.ServiceProvider.Execute<RateParticipantReponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetParticipantRating(string userName,string courseID,Action<GetParticipantRatingResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getparticipantrating", Method.PUT);	
			request.AddBody (new GetParticipantRatingRequest(){
				UniqueAppId = App.UniqueAppId,
				UserName = userName,
				CourseID = courseID
			});
			GetParticipantRatingResponse response = await APIServiceProvider.ServiceProvider.Execute<GetParticipantRatingResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000") ) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetParticipantList(string userName,string courseID, Action<ParticipantListResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getparticipantlist",Method.PUT);
			request.AddBody(new ParticipantListRequest{
				UniqueAppId = App.UniqueAppId,
				UserName = userName,
				CourseID=courseID
			});
			ParticipantListResponse response = await APIServiceProvider.ServiceProvider.Execute<ParticipantListResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetProgramList(string userName, Action<GetProgramListReponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getprograms",Method.PUT);
			request.AddBody (new GetProgramListRequest {
				UniqueAppId = App.UniqueAppId,
				UserName = userName
			});
			GetProgramListReponse response = await APIServiceProvider.ServiceProvider.Execute<GetProgramListReponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetProgramReportList(string userName,string prgID, Action<GetProgramReportReponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getprogramreport",Method.PUT);
			request.AddBody(new GetProgramReport{
				UniqueAppId = App.UniqueAppId,
				UserName = userName,
				PrgID=prgID
			});
			GetProgramReportReponse response = await APIServiceProvider.ServiceProvider.Execute<GetProgramReportReponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
		public static async Task GetParticipantRatingQuestion(Action<PraticipantRatingQuestionListResponse> successCallback, Action<ResponseBase> errorCallback){
			RestRequest request = new RestRequest ("/lms/api/getparticipantratingquestionlist",Method.PUT);
			request.AddBody(new GetPraticipantRatingQuestionList{
				UniqueAppId = App.UniqueAppId,
			});
			PraticipantRatingQuestionListResponse response = await APIServiceProvider.ServiceProvider.Execute<PraticipantRatingQuestionListResponse> (request);
			if ((response != null) && (response.ResponseCode == "1000")) {
				successCallback?.Invoke (response);
			} else {
				errorCallback?.Invoke ((ResponseBase)response); 
			}
		}
	}
}

