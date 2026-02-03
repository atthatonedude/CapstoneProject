using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CapstoneProject.MVVMBase
{
    public class RelayCommand : ICommand
    {   
        private readonly Action<object> executeable;
        private readonly Func<object, bool> canExecuteable;
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
            }

        public RelayCommand(Action<object> execute, Func<object,bool> canExecute = null)
        {
            executeable = execute;
            canExecuteable = canExecute;
        }

        public bool CanExecute(object parameter) => canExecuteable == null || canExecuteable(parameter);
        public void Execute(object parameter) => executeable(parameter);
    }
}
