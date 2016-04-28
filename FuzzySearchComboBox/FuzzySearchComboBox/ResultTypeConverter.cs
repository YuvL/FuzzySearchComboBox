using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace
namespace Controls.FuzzySearchComboBox
{
    [ValueConversion(typeof(ResultType), typeof(string))]
    public class ResultTypeConverter : BaseConverter, IValueConverter
    {
        public ResultTypeConverter()
        {
            
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ResultType) value).GetName();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        } 
    }
}