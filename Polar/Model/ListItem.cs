using System;
using System.ComponentModel;

namespace Polar.Model
{
    public class ListItem : INotifyPropertyChanged
    {

        private Piece piece;

        public Piece Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                OnPropertyChanged("Password");
            }
        }

        //public ObjectId Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
