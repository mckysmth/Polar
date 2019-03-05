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
        public ObservableCollection<Piece> TodaysList { get; set; }

        public DoListVM(DoListPage doListPage)
        {
            DoListPage = doListPage;
            User = App.user;
            Backlog = User.GetBackLog();
            TodaysList = User.GetToaysList();
            NavigateToNewProjectPage = new Command(() => ExecuteNavigateToNewProjectPageCommand());

        }

        public void UpdateBackLog()
        {
            foreach (var item in User.GetBackLog())
            {
                if (!Backlog.Contains(item))
                {
                    Backlog.Add(item);
                }
            }

            for (int i = 0; i < Backlog.Count; i++)
            {
                if (Backlog[i].IsComplete)
                {
                    Backlog.Remove(Backlog[i]);
                }
            }
        }

        public void UpdateTodaysList()
        {
            foreach (var item in Backlog)
            {
                if (item.IsOnDoList)
                {
                    if (!TodaysList.Contains(item))
                    {
                        TodaysList.Add(item);
                    }
                }
                else
                {
                    TodaysList.Remove(item);
                }
            }

            for (int i = 0; i < TodaysList.Count; i++)
            {
                    if (TodaysList[i].IsComplete)
                    {
                        TodaysList.Remove(TodaysList[i]);
                    }
            }
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
