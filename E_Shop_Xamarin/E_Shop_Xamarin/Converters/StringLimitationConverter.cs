using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace E_Shop_Xamarin.Converters
{
    public class StringLimitationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ReturnedString = (string)value;
            if (ReturnedString.Length > 50)
                ReturnedString = $"{ReturnedString.Substring(0, 50)}...";

            return ReturnedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
