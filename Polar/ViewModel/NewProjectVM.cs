using System;
using System.ComponentModel;
using Polar.Model;
using Polar.Services;
using Polar.ViewModel.Commands;

namespace Polar.ViewModel
{
    public class NewProjectVM : INotifyPropertyChanged
    {
        public CreateNewProjectCommand CreateNewProjectCommand { get; set; }

        private User user;

        public NewProjectPage NewProjectPage { get; set; }

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private Project project;

        public Project Project
        {
            get { return project; }
            set
            {
                project = value;
                OnPropertyChanged("Project");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewProjectVM(NewProjectPage newProjectPage)
        {
            NewProjectPage = newProjectPage;
            User = App.user;

            Project = new Project(true);

            CreateNewProjectCommand = new CreateNewProjectCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public async void CreateNewProject()
        {
            Project.Clean();
            User.AddProject(Project);

            //SQLService SQL = new SQLService();

            await AzureService.InsertNewProject(User, Project);
            await NewProjectPage.Navigation.PopAsync();

        }


    }
}
