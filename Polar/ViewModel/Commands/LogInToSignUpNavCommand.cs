using System;
using System.Windows.Input;


namespace Polar.ViewModel.Commands
{
    public class LogInToSignUpNavCommand : ICommand
    {


        public LogInVM LogInViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public LogInToSignUpNavCommand(LogInVM logInVM)
        {
            LogInViewModel = logInVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LogInViewModel.NavigateToSignUp();

        }
    }
}
