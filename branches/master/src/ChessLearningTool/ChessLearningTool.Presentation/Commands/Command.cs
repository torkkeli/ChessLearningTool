using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChessLearningTool.Presentation.Commands
{
    public class Command<T> : ICommand
        where T : class
    {
        private readonly Action<T> _onExecute;
        private readonly Func<T, bool> _canExecute;

        public Command(Action<T> onExecute, Func<T, bool> canExecute)
        {
            _onExecute = onExecute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var arg = parameter as T;

            if (arg == null)
                throw new Exception($"BUG : Command.CanExecute parameter (type: {parameter.GetType().Name}) must be of type {typeof(T).Name}.");

            return _canExecute?.Invoke(arg) ?? true;
        }

        public void Execute(object parameter)
        {
            var arg = parameter as T;

            if (arg == null)
                throw new Exception($"BUG : Command.CanExecute parameter (type: {parameter.GetType().Name}) must be of type {typeof(T).Name}.");

            _onExecute(arg);
        }
    }
}
