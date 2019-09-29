using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Abhinaw.OfflineQuizWPF.Converters
{
	public class UserNameCollapsedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return Visibility.Visible;
			if (string.IsNullOrEmpty(value.ToString()))
				return Visibility.Visible;

			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
