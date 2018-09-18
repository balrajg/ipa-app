using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class MarkAttendanceRequest
	{
		//{"uniqueAppId":"2344HEUDMK3344","apiRequest":{"courseID":"","attendance":"","attendanceList":[{"dt":"<yyyy-mm-dd>", "presentList":["<username>","",""], "absentList":["<username>","",""]},{}]}}
		[JsonProperty(PropertyName ="uniqueAppId", NullValueHandling = NullValueHandling.Ignore) ]
		public string UniqueAppId {get; set;}
		[JsonProperty(PropertyName ="apiRequest", NullValueHandling = NullValueHandling.Ignore) ]
		public MarkAttendance MarkAttendanceData{ get; set;}
	}
	public  class MarkAttendanceResponse :ResponseBase
	{
//		{"status": "Success","responseCode": "1000"}
	}
}

