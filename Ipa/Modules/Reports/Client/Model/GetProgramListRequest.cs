using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetProgramListRequest 
	{
//		{"uniqueAppId":"2344HEUDMK3344","userName":"user2"}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
	}
	public class GetProgramListReponse : ResponseBase
	{
//		{"status": "Success","responseCode": "1000","apiResponse": {"program": [{"prgID": "21","prgName": "SEAL PM Master1"},{"prgID": "25","prgName": "SEAL 10"},{"prgID": "26","prgName": "SEAL Test"}]}}
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ProgramReportReponse ProgramReportReponseData;

	}
	public class ProgramReportReponse
	{
		[JsonProperty (PropertyName = "program", NullValueHandling = NullValueHandling.Ignore)]
		public List<Program> ProgramList { get; set; }
	}
	public class Program
	{
		[JsonProperty (PropertyName = "prgID", NullValueHandling = NullValueHandling.Ignore)]
		public string PrgID { get; set; }
		[JsonProperty (PropertyName = "prgName", NullValueHandling = NullValueHandling.Ignore)]
		public string PrgName { get; set; }
	}
}


