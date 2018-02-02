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
            if (!value.GetType().Equals(typeof(Tin)))
                throw new Exception(string.Format("BUG - ValueConverter.Convert: T is not of type {0}", value.GetType().Name));

            return Convert((Tin)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.GetType().Equals(typeof(Tout)))
                throw new Exception(string.Format("BUG - ValueConverter.ConvertBack: T is not of type {0}", value.GetType().Name));

            return ConvertBack((Tout)value);
        }

        protected abstract Tout Convert(Tin value);

        protected abstract Tin ConvertBack(Tout value);
    }
}
