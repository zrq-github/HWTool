using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HW.DevelopTool.Converters
{
    internal class HWProductToNameConverter
        : IValueConverter
    {
        public static readonly HWProductToNameConverter Instance = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<IProduct> products)
            {
                List<string> strings = new();
                foreach (var product in products)
                {
                    strings.Add(product.Name);
                }
                return strings;
            }
            else if (value is IProduct product)
            {
                return product.Name;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
