using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class ReporteeListForAllCourse 
	{
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
	}
	public class ReporteeListForAllCourseResponse : ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ReporteeCourseDetail ReporteeCourseList { get; set; }
	}
	public class ReporteeCourseDetail
	{
		[JsonProperty (PropertyName = "courseList", NullValueHandling = NullValueHandling.Ignore)]
		public List<CourseData> CourseList{ get; set;}

	}
	public class CourseData 
	{
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseId{ get; set;}
		[JsonProperty (PropertyName = "reporteeList", NullValueHandling = NullValueHandling.Ignore)]
		public List<Reportee> ReporteeList{ get; set;}
	}
}


