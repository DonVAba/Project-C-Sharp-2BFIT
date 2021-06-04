using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace Homepage.converters
{
    public class StringToImage : IValueConverter
    {
        public string FilePath { get; set; } = Directory.GetCurrentDirectory();

        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string nomImage = value as string;
            if (string.IsNullOrWhiteSpace(nomImage)) return null;
            string cheminImage = Path.Combine(FilePath, nomImage);
            return new Uri(cheminImage, UriKind.RelativeOrAbsolute);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
