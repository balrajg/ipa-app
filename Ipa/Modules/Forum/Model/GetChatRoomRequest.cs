using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ipa
{
	public class GetChatRoomRequest 
	{
		
	}
	public class GetChatRoomResponse:ResponseBase
	{
     	[JsonProperty (PropertyName = "apiResponse", NullValueHandling = NullValueHandling.Ignore)]
		public List<ChatRoomDetail> ChatRoomData { get; set; }
	}
	public class ChatRoomDetail{
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
		[JsonProperty (PropertyName = "roomID", NullValueHandling = NullValueHandling.Ignore)]
		public string RoomID { get; set; }
		[JsonProperty (PropertyName = "roomName", NullValueHandling = NullValueHandling.Ignore)]
		public string RoomName { get; set; }
		[JsonProperty (PropertyName = "roomDesc", NullValueHandling = NullValueHandling.Ignore)]
		public string RoomDesc { get; set; }
		[JsonProperty (PropertyName = "lastUser", NullValueHandling = NullValueHandling.Ignore)]
		public string LastUser { get; set; }
		[JsonProperty (PropertyName = "lastMessage", NullValueHandling = NullValueHandling.Ignore)]
		public string LastMessage { get; set; }
		[JsonProperty (PropertyName = "profileImage", NullValueHandling = NullValueHandling.Ignore)]
		public string ProfileImage { get; set; }
		[JsonProperty (PropertyName = "totalusrCount", NullValueHandling = NullValueHandling.Ignore)]
		public string TotalUserCount { get; set; }
		[JsonProperty (PropertyName = "lastMessageTimestamp", NullValueHandling = NullValueHandling.Ignore)]
		public string LastMessageTimestamp { get; set; }

	}
}


