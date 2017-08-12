﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChessLearningTool.Presentation.Commands
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        protected Command(Action onExecute, Func<bool> canExecute)
        {

        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
