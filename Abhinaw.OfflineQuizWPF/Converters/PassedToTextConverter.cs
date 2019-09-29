using System;
using System.Globalization;
using System.Windows.Data;

namespace Abhinaw.OfflineQuizWPF.Converters
{
	public class PassedToTextConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(value is bool))
				return "Failed";
			return (bool)value ? "Passed" : "Failed";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
