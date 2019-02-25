using System;
using System.ComponentModel;
using SQLite;

namespace Polar.Model
{
    public class Task : INotifyPropertyChanged
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string PieceId { get; set; }

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
            Id = Guid.NewGuid().ToString();
        }

        public Task(string pieceId)
        {
            PieceId = pieceId;
            Id = Guid.NewGuid().ToString();
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
