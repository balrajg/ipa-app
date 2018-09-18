using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetReproteeListRequest
	{
//		{"uniqueAppId":"2344HEUDMK3344","userName":"","courseID":""}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
	}

	public class GetReporteeListResponse : ResponseBase
	{
//		{"responseCode":"1000","apiResponse":{"reporteeList":[{"userName":"","fullName":"","surName":"","profileImage":"<URL>","empID":""},{}]}}
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ReporteeData Data { get; set; }
	}

	public class ReporteeData
	{
		[JsonProperty (PropertyName = "reporteeList", NullValueHandling = NullValueHandling.Ignore)]
		public List<Reportee> ReportList { get; set; }
	}
}

