using System;
using System.Windows.Input;


namespace Polar.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {


        public LogInVM LogInViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public NavigationCommand(LogInVM logInVM)
        {
            LogInViewModel = logInVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LogInViewModel.Navigate();

        }
    }
}
