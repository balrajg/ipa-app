using System;

using Xamarin.Forms;
using System.Globalization;

namespace Ipa
{
	public class MultiTriggerConverter :IValueConverter
	{
		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			if ((int)value > 0) // length > 0 ?
				return true;            // some data has been entered
			else
				return false;           // input is empty
		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			throw new NotSupportedException ();
		}
	}
}


