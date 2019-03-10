using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Polar.Model;
using Polar.Services;
using Polar.ViewModel.Converters;
using Xamarin.Forms;

namespace Polar.ViewModel
{
    public class ProjectListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DeleteProject { get; }
        public ICommand ReuseProject { get; }

        private User user;

        public ProjectListPage ProjectListPage { get; set; }


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
            ProjectListPage = projectListPage;
            User = App.user;
            DeleteProject = new Command(ExecuteDeleteProject);
            ReuseProject = new Command(ExecuteReuseProject);
        }

        private void ExecuteReuseProject(object obj)
        {
            if (obj is Project project)
            {
                project.Reuse();

                SQLService SQL = new SQLService();
                SQL.UpdateProject(project);

                foreach (var piece in project.Pieces)
                {
                    SQL.UpdatePiece(piece);
                    foreach (var task in piece.Tasks)
                    {
                        SQL.UpdateTask(task);
                    }
                }
                App.Current.MainPage = new NavPage();
            }
        }

        private void ExecuteDeleteProject(object obj)
        {
            SQLService SQL = new SQLService();
            if (obj is Project project)
            {
                User.DeleteProject(project);
                SQL.DeleteProject(project);
            } 
            else if (obj is Piece piece)
            {
                User.GetProjectByPiece(piece).DeletePiece(piece);
                SQL.DeletePiece(piece);
            }
            else if (obj is Task task)
            {
                User.GetPieceByTask(task).DeleteTask(task);
                SQL.DeleteTask(task);
            }



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
