using System;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace Ipa
{
	public class RateParticipantRequest 
	{
		[JsonProperty (PropertyName = "uniqueAppId", NullValueHandling = NullValueHandling.Ignore)]
		public string UniqueAppId { get; set; }	
		[JsonProperty(PropertyName ="apiRequest", NullValueHandling = NullValueHandling.Ignore) ]
		public ParticipantRating ParticipantRatingData{ get; set;}
	}
	public class RateParticipantReponse:ResponseBase
	{
		
	}
}


