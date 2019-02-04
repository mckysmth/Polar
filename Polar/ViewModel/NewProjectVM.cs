using System;
using System.ComponentModel;
using Polar.Model;
using Polar.ViewModel.Commands;

namespace Polar.ViewModel
{
    public class NewProjectVM : INotifyPropertyChanged
    {
        public CreateNewProjectCommand CreateNewProjectCommand { get; set; }

        private User user;

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

        public NewProjectVM()
        {
            User = Client.GetUser();
            Project = new Project();

            User.AddProject(Project);
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
            await User.UpdateProjectIDs(User);
        }


    }
}
