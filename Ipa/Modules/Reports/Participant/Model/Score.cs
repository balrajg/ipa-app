using System;
using Newtonsoft.Json;

namespace Ipa
{
	public class Score
	{
		[JsonProperty (PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
		public string Category;
		[JsonProperty (PropertyName = "score", NullValueHandling = NullValueHandling.Ignore)]
		public string EarnedScore;


		public override string ToString ()
		{
			return string.Format ("{0} {1}", Category, EarnedScore);
		}
	}
}

