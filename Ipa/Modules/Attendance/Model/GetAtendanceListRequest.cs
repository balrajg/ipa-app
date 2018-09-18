using System;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace Ipa
{
	public class GetAtendanceListRequest 
	{
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
	}
	public class GetAttendanceListReponse: ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public Attendance AttendanceData;
	}
}


