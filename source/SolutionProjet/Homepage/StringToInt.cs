using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Homepage
{
    public class StringToInt : IValueConverter // A faire fonctionner avec la vue
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.TryParse((string)value, out int ret) ? ret : 0;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        
    }
}
