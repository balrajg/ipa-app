using System;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace Ipa
{
	public class SendMessageRequest 
	{
//		{"uniqueAppId":"56d83a390a15b","roomID":"1","courseID":"21","userName":"clientspoc","msgText":"Hi I'm niresh"}
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }
		[JsonProperty (PropertyName = "roomID", NullValueHandling = NullValueHandling.Ignore)]
		public string RoomID { get; set; }
		[JsonProperty (PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
		public string CourseID { get; set; }
		[JsonProperty (PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
		public string UserName { get; set; }
		[JsonProperty (PropertyName = "msgText", NullValueHandling = NullValueHandling.Ignore)]
		public string MsgText { get; set; }
	}
	public class SendMessageResponse :ResponseBase
	{
//		{"status":"Success","responseCode":"1000"}
	}
}


