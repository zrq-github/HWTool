using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace HW.DevelopTool.Converters;

[ValueConversion(typeof(bool), typeof(bool))]
internal class BoolToInverseBoolConverter
    : IValueConverter
{
    public static readonly BoolToInverseBoolConverter Instance = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not bool boolValue)
            return DependencyProperty.UnsetValue;

        return !boolValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(value, targetType, parameter, culture);
    }
}
