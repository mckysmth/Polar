using System;
using System.ComponentModel;
using SQLite;

namespace Polar.Model
{
    public class Task : INotifyPropertyChanged
    {
        public string Id { get; set; }

        public string PieceID { get; set; }

        private string taskName;

        public string TaskName
        {
            get { return taskName; }
            set
            {
                taskName = value;
                OnPropertyChanged("TaskName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task()
        {
        }

        public Task(string pieceID)
        {
            PieceID = pieceID;
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
