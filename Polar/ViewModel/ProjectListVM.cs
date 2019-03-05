using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Polar.Model;
using Polar.Services;
using Xamarin.Forms;

namespace Polar.ViewModel
{
    public class ProjectListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DeleteProject { get; }

        private User user;

        public ProjectListPage DoListPage { get; set; }

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public ProjectListVM(ProjectListPage projectListPage)
        {
            DoListPage = projectListPage;
            User = App.user;
            DeleteProject = new Command(ExecuteDeleteProject);

        }

        private void ExecuteDeleteProject(object obj)
        {
            Project project = (Project)obj;
            User.DeletProject(project);

            SQLService SQL = new SQLService();
            SQL.DeleteProject(project);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }






    }
}
