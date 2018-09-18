using System;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Ipa.Modules.Forum.Model
{
   
    public class GetOthersMessageRequest
    {
        //		{"uniqueAppId":"56d83a390a15b","roomID":"1","courseID":"21"}
        [JsonProperty(PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
        public string UniqueAppId { get; set; }
        [JsonProperty(PropertyName = "roomID", NullValueHandling = NullValueHandling.Ignore)]
        public string RoomID { get; set; }
        [JsonProperty(PropertyName = "courseID", NullValueHandling = NullValueHandling.Ignore)]
        public string CourseID { get; set; }
        [JsonProperty(PropertyName = "UserName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "LastUpdatedTime", NullValueHandling = NullValueHandling.Ignore)]
        public string LastUpdatedTime { get; set; }

    }
    
}
