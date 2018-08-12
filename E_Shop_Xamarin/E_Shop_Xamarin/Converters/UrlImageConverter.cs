using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Converters
{
    public class UrlImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value as string))
                return null;
            return new UriImageSource { Uri = new Uri(value as string), CachingEnabled=true, CacheValidity=new TimeSpan(360,0,0,0,0)};
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
