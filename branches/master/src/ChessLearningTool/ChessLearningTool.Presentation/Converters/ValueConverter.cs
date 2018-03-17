using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ChessLearningTool.Presentation.Converters
{
    public abstract class ValueConverter<Tin, Tout> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (!value.GetType().IsSubclassOf(typeof(Tin)))
                throw new Exception($"BUG - ValueConverter.Convert:  {value.GetType().Name} is not of type {typeof(Tin).Name}");

            return Convert((Tin)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.GetType().IsSubclassOf(typeof(Tout)))
                throw new Exception($"BUG - ValueConverter.Convert:  {value.GetType().Name} is not of type {typeof(Tout).Name}");

            return ConvertBack((Tout)value);
        }

        protected abstract Tout Convert(Tin value);

        protected abstract Tin ConvertBack(Tout value);
    }
}
