using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetChatMessageRequest 
	{
//		{"uniqueAppId":"56d83a390a15b","roomID":"1","courseID":"21"}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "roomID", NullValueHandling = NullValueHandling.Ignore)]
		public string RoomID { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
		
	}
	public class GetChatMessageResponse:ResponseBase
	{
//		{"status": "Success","responseCode": "1000","currentTimestamp": "15-03-2016 17:04:39","apiResponse": [{"user": "admin","message": "hi","timestamp": "2016-02-18 20:56:50"},{"user": "user2","message": "user2","timestamp": "2016-02-22 19:09:11"},{"user": "703109250","message": "user2","timestamp": "1970-01-01 05:30:00"},{"user": "admin","message": "To Rohit Agarwal: sdsd","timestamp": "2016-02-22 19:30:25"},{"user": "703109250","message": "user2","timestamp": "1970-01-01 05:30:00"},]}
		[JsonProperty (PropertyName = "currentTimestamp", NullValueHandling = NullValueHandling.Ignore)]
		public string CurrentTimestamp { get; set; }
		[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public List<Message> ChatData { get; set; }
	}
	public class Message{
		[JsonProperty (PropertyName = "user", NullValueHandling = NullValueHandling.Ignore)]
		public string User { get; set; }
		[JsonProperty (PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
		public string MessageText { get; set; }
		[JsonProperty (PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
		public string Timestamp { get; set; }
		public string ImageUri { get; set; }
	}
   
}


