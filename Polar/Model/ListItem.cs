using System;
using System.ComponentModel;
using MongoDB.Bson;

namespace Polar.Model
{
    public class ListItem : INotifyPropertyChanged
    {
        //private Project project;

        //public Project Project
        //{
        //    get { return project; }
        //    set
        //    {
        //        project = value;
        //        OnPropertyChanged("Password");
        //    }
        //}

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

        public ObjectId Id { get; set; }

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
