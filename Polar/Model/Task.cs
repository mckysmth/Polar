using System;
using System.ComponentModel;
using MongoDB.Bson;

namespace Polar.Model
{
    public class Task : INotifyPropertyChanged
    {
        public ObjectId Id { get; set; }

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
            Id = ObjectId.GenerateNewId();
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
