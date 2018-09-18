using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class MarkAttendance
	{
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore )]
		public string CourseId{ set; get; }

		[JsonProperty (PropertyName = "attendanceList", NullValueHandling = NullValueHandling.Ignore )]
		public List<AttendanceDetail> AttendanceList{ set; get; }
	}
}

