using System;
using System.Windows.Input;
using Polar.Model;

namespace Polar.ViewModel.Commands
{
    public class SignUpCommand : ICommand
    {
        public SignUpVM SignUpViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public SignUpCommand(SignUpVM signUpVM)
        {
            SignUpViewModel = signUpVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SignUpViewModel.NavigateToLading();
        }
    }
}
