using System;
using Windows.UI.Xaml.Data;

namespace ShoppingList.Screens.Converters
{
    public class DateTimeFormStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTime date)
            {
                var formatData = $"{date.Month}/{date.Day}/{date.Year}";
                return formatData;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;

        }
    }
}
