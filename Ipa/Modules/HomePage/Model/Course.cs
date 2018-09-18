using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ipa
{
	public enum UserType
	{
		PARTICIPANT, MANAGER, CLIENT, PARTNER, MANAGER_CUM_PARTICIPANT
	}

//	{"uniqueAppId":"2344HEUDMK3344","userName":""}

	public class CourseListRequest
	{
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
	}

	public class CourseListResponse: ResponseBase
	{
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public ApiResponse Response;
	}
	public class ApiResponse
	{
		[JsonProperty (PropertyName = "currentDate", NullValueHandling = NullValueHandling.Ignore)]
		public string CurrentDate{ get; set; }
		[JsonProperty (PropertyName = "courseList", NullValueHandling = NullValueHandling.Ignore)]
		public List<Course> CourseList{ get ; set; }
	}


	public class Course
	{
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseId;
		[JsonProperty (PropertyName = "courseFullName", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseFullName;
		[JsonProperty (PropertyName = "courseShortName", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseShortName;
		[JsonProperty (PropertyName = "startDate", NullValueHandling = NullValueHandling.Ignore)]
		public string StartDate;// yyyy-MM-dd
		[JsonProperty (PropertyName = "endDate", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime EndDate;
		[JsonProperty (PropertyName = "roleID", NullValueHandling = NullValueHandling.Ignore)]
		public int[] RoleId;
		[JsonProperty (PropertyName = "reporteeCount", NullValueHandling = NullValueHandling.Ignore)]
		public string ReporteeCount;
		[JsonProperty (PropertyName = "participantCount", NullValueHandling = NullValueHandling.Ignore)]
		public string ParticipantCount;
		[JsonProperty (PropertyName = "activityList", NullValueHandling = NullValueHandling.Ignore)]
		public List<Activity> ActivityList;
	}

}

