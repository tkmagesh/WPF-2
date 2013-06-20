using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace MyFirstWPFApp
{
    public class MultiSliderValuesToSolidBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var red = System.Convert.ToByte(values[0]);
            var green = System.Convert.ToByte(values[1]);
            var blue = System.Convert.ToByte(values[2]);
            return new SolidColorBrush(new Color() {R = red, G = green, B = blue, A = 255});
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var brush = (SolidColorBrush) value;
            return new object[] { System.Convert.ToDouble(brush.Color.R), System.Convert.ToDouble(brush.Color.G), System.Convert.ToDouble(brush.Color.B) };
        }
    }
}
