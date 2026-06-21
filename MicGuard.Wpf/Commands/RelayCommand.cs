using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MicGuard.Wpf.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;

        public RelayCommand(Action execute) => this.execute = execute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            execute();
        }
    }
}