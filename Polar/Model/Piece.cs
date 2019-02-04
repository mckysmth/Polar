using System;
using System.ComponentModel;

namespace Polar.Model
{
    public class Piece : INotifyPropertyChanged
    {
        private string pieceName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string PieceName
        {
            get { return pieceName; }
            set
            {
                pieceName = value;
                OnPropertyChanged("PieceName");
            }
        }

        public Piece()
        {
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
