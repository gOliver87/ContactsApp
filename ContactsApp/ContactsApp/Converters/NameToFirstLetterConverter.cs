using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ContactsApp.Converters
{
    internal class NameToFirstLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var name = value as string;
                if (!string.IsNullOrWhiteSpace(name))
                    return name.Substring(0, 1).ToUpper();
            }
            catch (Exception)
            {
                //Should be logged
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
