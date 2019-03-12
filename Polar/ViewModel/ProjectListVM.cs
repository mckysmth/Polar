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
            DeleteProject = new Command(ExecuteDeleteProjectAsync);
            ReuseProject = new Command(ExecuteReuseProjectAsync);
        }

        private async void ExecuteReuseProjectAsync(object obj)
        {
            if (obj is Project project)
            {
                project.Reuse();

                //SQLService SQL = new SQLService();
                await AzureService.UpdateProject(project);

                foreach (var piece in project.Pieces)
                {
                    await AzureService.UpdatePiece(piece);
                    foreach (var task in piece.Tasks)
                    {
                        await AzureService.UpdateTask(task);
                    }
                }
                App.Current.MainPage = new NavPage();
            }
        }

        private async void ExecuteDeleteProjectAsync(object obj)
        {
            //SQLService SQL = new SQLService();
            if (obj is Project project)
            {
                User.DeleteProject(project);
                await AzureService.DeleteProject(project);
            } 
            else if (obj is Piece piece)
            {
                User.GetProjectByPiece(piece).DeletePiece(piece);
                await AzureService.DeletePiece(piece);
            }
            else if (obj is Task task)
            {
                User.GetPieceByTask(task).DeleteTask(task);
                await AzureService.DeleteTask(task);
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
