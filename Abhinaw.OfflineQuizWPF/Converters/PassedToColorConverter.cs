using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Abhinaw.OfflineQuizWPF.Converters
{
	public class PassedToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(value is bool))
			return new SolidColorBrush(Colors.Red);

			return (bool)value ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
