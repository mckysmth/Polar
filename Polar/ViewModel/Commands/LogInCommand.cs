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
            User user = (User)parameter;
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {
            LogInViewModel.LogIn();
        }
    }
}
