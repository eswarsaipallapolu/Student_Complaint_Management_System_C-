using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace StudentComplaintSystem.Views
{
    public class ComboBoxItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ComboBoxItem comboBoxItem)
            {
                return comboBoxItem.Content?.ToString() ?? string.Empty;
            }
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}