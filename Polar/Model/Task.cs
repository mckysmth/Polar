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

        private bool isComplete;

        public bool IsComplete
        {
            get { return isComplete; }
            set
            {
                isComplete = value;
                OnPropertyChanged("TaskName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task()
        {
            Id = Guid.NewGuid().ToString();
            IsComplete = false;
        }

        public Task(string pieceId)
        {
            PieceId = pieceId;
            Id = Guid.NewGuid().ToString();
            IsComplete = false;
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
