using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Polar.Model;

namespace Polar.ViewModel
{
    public class DoListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<(string projectName, Piece piece)> PieceTupleList { get; private set; }

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

        public DoListVM()
        {
            user = Client.GetUser();
            PieceTupleList = user.BuildPieceList();
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
