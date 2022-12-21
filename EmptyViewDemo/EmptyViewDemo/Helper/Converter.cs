using Microsoft.Maui.Controls;
using System;
using System.Globalization;


namespace EmptyViewDemo
{
    public class ListViewBoolToSortImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sortOptions = (ListViewSortOptions)value;
            if (sortOptions == ListViewSortOptions.Ascending)
                return "\ue709";
            else if (sortOptions == ListViewSortOptions.Descending)
                return "\ue719";
            else
                return "\ue709";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
