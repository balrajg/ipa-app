using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Ipa
{
	public partial class WalkthroughView : ContentView
	{
		public WalkthroughView ()
		{
			InitializeComponent ();
		}
		public ImageSource Source {
			set{
				this.SampleImage.Source = value;
			}
			get{ 
				return this.SampleImage.Source;
			}
		}

		public string Heading {
			set{
				this.Header.Text = value;
			}
			get{ 
				return this.Header.Text;
			}
		}

		public string DescriptionText {
			set{
				this.Description.Text = value;
			}
			get{ 
				return this.Description.Text;
			}
		}
	}
}

