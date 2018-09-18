using System;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace Ipa
{
	public class EnterChatRoomRequest 
	{
//		{"uniqueAppId":"56d83a390a15b","roomID":"1","courseID":"21","userName":"user2"}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "roomID", NullValueHandling = NullValueHandling.Ignore)]
		public string RoomID { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
	}
	public class EnterChatRoomResponse : ResponseBase
	{
//		{"status":"Success","responseCode":"1000"}
	}
}


