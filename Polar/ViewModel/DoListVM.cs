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

        public DoListPage DoListPage { get; set; }

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


        public DoListVM(DoListPage doListPage)
        {
            DoListPage = doListPage;
            User = App.user;
            Backlog = User.GetBackLog();
            NavigateToNewProjectPage = new Command(() => ExecuteNavigateToNewProjectPageCommand());

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        private void ExecuteNavigateToNewProjectPageCommand()
        {
            DoListPage.Navigation.PushAsync(new NewProjectPage());

        }



    }
}
