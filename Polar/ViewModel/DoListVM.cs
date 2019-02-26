using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Polar.Model;
using Polar.Services;
using Xamarin.Forms;

namespace Polar.ViewModel
{
    public class DoListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NavigateToNewProjectPage { get; }

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
        public ObservableCollection<Piece> Backlog { get; set; }


        public DoListVM()
        {
            User = App.user;
            Backlog = User.GetBackLog();
            NavigateToNewProjectPage = new Command(async () => await ExecuteNavigateToNewProjectPageCommand());

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        private async System.Threading.Tasks.Task ExecuteNavigateToNewProjectPageCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewProjectPage());

        }



    }
}
