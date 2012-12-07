﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Win8Extensions.Converters
{
    /// <summary>
    /// Value converter that translates true to <see cref="Visibility.Collapsed"/> and false to
    /// <see cref="Visibility.Visible"/>.
    /// </summary>
    public class ReverseBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) {
            return (value is bool && (bool)value) ? Visibility.Collapsed: Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return value is Visibility && (Visibility)value == Visibility.Collapsed;
        }
    }
}