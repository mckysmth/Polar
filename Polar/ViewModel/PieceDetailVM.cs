using System;
using System.ComponentModel;
using Polar.Model;

namespace Polar.ViewModel
{
    public class PieceDetailVM : INotifyPropertyChanged
    {
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

        private Piece piece;

        public Piece Piece 
        {
            get { return piece; } 
            set
            {
                piece = value;
                OnPropertyChanged("Piece");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PieceDetailVM(Piece piece)
        {
            Piece = piece;

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
