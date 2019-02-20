using System;
using System.Windows.Input;
using Polar.Model;

namespace Polar.ViewModel.Commands
{
    public class LogInCommand : ICommand
    {
        public LogInVM LogInViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public LogInCommand(LogInVM logInVM)
        {
            LogInViewModel = logInVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LogInViewModel.LogIn();
        }
    }
}
