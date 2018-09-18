using System;
using Xamarin.Forms;

namespace Ipa
{
	public interface IWalkThroughData
	{
		ImageSource Source { get; set;}
		string Heading{ get; set; }
		string Description{ get; set; }

	}
}

