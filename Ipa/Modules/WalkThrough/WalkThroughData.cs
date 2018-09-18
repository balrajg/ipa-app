using System;

namespace Ipa
{
	public class WalkThroughData : IWalkThroughData
	{
		public WalkThroughData ()
		{
		}
		public Xamarin.Forms.ImageSource Source {
			set;
			get;
		}

		public string Heading {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}
	}
}

