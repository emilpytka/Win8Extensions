using System;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Win8Extensions.Converters
{
    /// <summary>
    /// Converter check if list which is send as parameter contains any elements. If jes return Visiblity.Visible, else return Visiblity.Collapsed
    /// </summary>
    public class ListContentToVisibility : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var list = value as ICollection;
            return (list != null && list.Count > 0) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
