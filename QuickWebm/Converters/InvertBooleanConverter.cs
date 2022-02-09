﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace QuickWebm.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => targetType != typeof(bool)
                ? throw new InvalidOperationException("The target must be a boolean")
                : !(bool)value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => throw new NotSupportedException();
    }
}
