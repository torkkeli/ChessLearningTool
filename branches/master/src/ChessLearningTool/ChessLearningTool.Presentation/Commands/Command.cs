using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChessLearningTool.Presentation.Commands
{
    public abstract class Command : ICommand
    {
        private readonly Action _onExecute;
        private readonly Func<bool> _canExecute;
        protected Command(Action onExecute, Func<bool> canExecute)
        {
            _onExecute = onExecute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            CanExecuteChanged?.Invoke(parameter, EventArgs.Empty);

            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _onExecute();
        }
    }
}
