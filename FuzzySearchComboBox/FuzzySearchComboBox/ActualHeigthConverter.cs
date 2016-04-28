using System;
using System.Globalization;
using System.Windows.Data;

namespace Controls.FuzzySearchComboBox
{
    [ValueConversion(typeof(double), typeof(double))]
    public class ActualHeigthConverter : BaseConverter, IValueConverter
    {
        public ActualHeigthConverter()
        {
            
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value + (double)parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        } 
    }
}