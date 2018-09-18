using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetProgramReport 
	{
//		{"uniqueAppId":"2344HEUDMK3344","userName":"janaki","prgID":"21"}

		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty (PropertyName = "prgID", NullValueHandling = NullValueHandling.Ignore)]
		public string PrgID { get; set; }
	}
	public class GetProgramReportReponse : ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public Response ResponseData;
	}
	public class Response
	{
		[JsonProperty (PropertyName = "programReport", NullValueHandling = NullValueHandling.Ignore)]
		public List<ProgramReport> ProgramReportList { get; set; }
	}
	public class ProgramReport
	{
		[JsonProperty (PropertyName = "courseName", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseName { get; set; }
		[JsonProperty (PropertyName = "attendance", NullValueHandling = NullValueHandling.Ignore)]
		public string Attendance { get; set; }
		[JsonProperty (PropertyName = "prescore", NullValueHandling = NullValueHandling.Ignore)]
		public string Prescore { get; set; }
		[JsonProperty (PropertyName = "l1score", NullValueHandling = NullValueHandling.Ignore)]
		public string L1score { get; set; }
		[JsonProperty (PropertyName = "postscore", NullValueHandling = NullValueHandling.Ignore)]
		public string Postscore { get; set; }
		[JsonProperty (PropertyName = "lapscore", NullValueHandling = NullValueHandling.Ignore)]
		public string Lapscore { get; set; }
	}
}


