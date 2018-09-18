using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class AttendanceDetail
	{
		[JsonProperty (PropertyName =  "dt", NullValueHandling = NullValueHandling.Ignore)]
		public string Date; //yyyy-mm-dd
		[JsonProperty (PropertyName =  "presentList", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> PresentList;
		[JsonProperty (PropertyName =  "absentList", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> AbsentList;
	}

	public class Attendance 
	{
		[JsonProperty (PropertyName =  "currentTime", NullValueHandling = NullValueHandling.Ignore)]
		public string CurrentTime;
		[JsonProperty (PropertyName = "attendanceList", NullValueHandling = NullValueHandling.Ignore)]
		public List<AttendanceDetail> AttendanceList;
		[JsonProperty (PropertyName =  "canEdit", NullValueHandling = NullValueHandling.Ignore)]
		public bool CanEdit;
	}
}

