using System;
using System.Windows.Input;

namespace Polar.ViewModel.Commands
{
    public class CreateNewProjectCommand : ICommand
    {
        public NewProjectVM NewProjectVM { get; set; }

        public event EventHandler CanExecuteChanged;

        public CreateNewProjectCommand(NewProjectVM newProjectVM)
        {
            NewProjectVM = newProjectVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NewProjectVM.CreateNewProject();
        }
    }
}
