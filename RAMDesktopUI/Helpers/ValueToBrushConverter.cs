using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RAMDesktopUI.Helpers
{
    public class ValueToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? input = null;
            if (value is bool?)
            {
                input = value as bool?;
            }
            else
            {
                double val = System.Convert.ToDouble(value);
                if (val > 0)
                {
                    input = true;
                }
                else if (val < 0)
                {
                    input = false;
                }
            }

            if(input == true)
            {
                return new SolidColorBrush(Colors.ForestGreen);
            }
            else if (input == false)
            {
                return new SolidColorBrush(Colors.Firebrick);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
