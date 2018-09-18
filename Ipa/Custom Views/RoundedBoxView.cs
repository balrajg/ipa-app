using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ipa
{
    public class RoundedBoxView : BoxView
    {
		public static readonly BindableProperty BorderSizeProperty =
			BindableProperty.Create<RoundedBoxView,double> (p => p.BorderSize, 0.0d);
		public double BorderSize
        {
            set
            {
				SetValue (BorderSizeProperty,value);
            }
            get
            {
				return (double)GetValue (BorderSizeProperty);
            }

        }

		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create<RoundedBoxView,Color> (p => p.BorderColor, Color.White);
		//Gets or sets the color of the progress bar
		public Color BorderColor {
			get { return (Color)GetValue (BorderColorProperty); }
			set { SetValue (BorderColorProperty, value); }
		}

		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create<RoundedBoxView,double> (p => p.CornerRadius, 0.0d);
		public double CornerRadius
        {
            set
            {
				SetValue (CornerRadiusProperty, value);
            }
            get
            {
				return (double)GetValue (CornerRadiusProperty);
            }
        }
    }
}
