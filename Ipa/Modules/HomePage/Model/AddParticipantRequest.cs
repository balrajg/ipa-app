using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class AddParticipantRequest 
	{
//		{"uniqueAppId": "56bca14604d6d","apiRequest": {"courseID": "23","participantList": [{"fullName": "Rajini","empID": "HM23","surName": "R","emailID": "chennainiresh@gmail.com","phone": "7896541235"}]}}
		[JsonProperty(PropertyName ="uniqueAppId", NullValueHandling = NullValueHandling.Ignore) ]
		public string UniqueAppId {get; set;}
		[JsonProperty(PropertyName ="apiRequest", NullValueHandling = NullValueHandling.Ignore) ]
		public AddParticipant AddParticipantInfo{ get; set;}
	}

	public class AddParticipantResponse : ResponseBase
	{
//		{ "status": "Success","responseCode": "1000" }
	}

	public class AddParticipant{
		[JsonProperty(PropertyName ="courseID", NullValueHandling = NullValueHandling.Ignore) ]
		public string  CourseId{get; set;}
		[JsonProperty(PropertyName ="participantList", NullValueHandling = NullValueHandling.Ignore) ]
		public List<ParticipantList> ParticipantListData{get; set;}
	}

	public class ParticipantList
	{
		[JsonProperty(PropertyName ="fullName", NullValueHandling = NullValueHandling.Ignore) ]
		public string FullName {get; set;}
		[JsonProperty(PropertyName ="empID", NullValueHandling = NullValueHandling.Ignore) ]
		public string EmpID {get; set;}
		[JsonProperty(PropertyName ="surName", NullValueHandling = NullValueHandling.Ignore) ]
		public string SurName {get; set;}
		[JsonProperty(PropertyName ="emailID", NullValueHandling = NullValueHandling.Ignore) ]
		public string EmailID {get; set;}
		[JsonProperty(PropertyName ="phone", NullValueHandling = NullValueHandling.Ignore) ]
		public string Phone {get; set;}
	}
}


