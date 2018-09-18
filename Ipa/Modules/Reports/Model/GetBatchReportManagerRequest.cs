using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetBatchReportManagerRequest 
	{
//		{"uniqueAppId":"2344HEUDMK3344","userName":"","courseID":""}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
	}
	public class BatchReportRequest
	{
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
	}
	public class GetBatchReportManagerResponse : ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ManagerReportReponse ApiData{ get; set;}
	}
	public class ManagerReportReponse
	{
		[JsonProperty (PropertyName = "batchreportList", NullValueHandling = NullValueHandling.Ignore)]
		public List<ManagerReportSummary> BatchreportList{ get; set;}
	}
}


