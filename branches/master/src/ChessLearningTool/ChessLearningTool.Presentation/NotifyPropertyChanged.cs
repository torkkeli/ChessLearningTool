using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T value, Expression<Func<T>> expression, T newValue)
        {
            value = newValue;
            OnPropertyChanged(expression);
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var memExp = expression.Body as MemberExpression;

            if (memExp == null)
                throw new Exception(string.Format("BUG: Can't convert {0} to MemberExpression.", expression.GetType().Name));

            OnPropertyChanged(memExp.Member.Name);
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
