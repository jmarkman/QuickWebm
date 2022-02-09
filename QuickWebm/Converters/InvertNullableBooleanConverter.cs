using System;
using System.Globalization;
using System.Windows.Data;

namespace QuickWebm.Converters
{
    [ValueConversion(typeof(bool?), typeof(bool?))]
    public class InvertNullableBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => targetType != typeof(bool?)
                ? throw new InvalidOperationException("The target must be a nullable boolean")
                : ((bool?)value).HasValue && !((bool?)value).Value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => !(value as bool?);
    }
}
