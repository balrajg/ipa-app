using System;
using Xamarin.Forms;
using System.Globalization;

namespace Ipa.Converters
{
	public class NotConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture){
			bool bindTo;
			if (bool.TryParse (value as string, out bindTo))
				bindTo = false;
			
			return  !bindTo;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture){
			bool bindTo;
			if (bool.TryParse (value as string, out bindTo))
				bindTo = false;

			return  !bindTo;
		}

	}
}

