using System;
using System.Globalization;
using Xamarin.Forms;

namespace Polar.ViewModel.Converters
{
    public class BooleanToStringStatus :IValueConverter
    {
        public BooleanToStringStatus()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = string.Empty;

            bool itemBooloean = (bool)value;

            if (itemBooloean)
            {
                status = "Done";
            }
            else
            {
                status = "In Progess";
            }

            return status;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
