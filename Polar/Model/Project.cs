using System;
using System.ComponentModel;
using MongoDB.Bson;

namespace Polar.Model
{
    public class Project : INotifyPropertyChanged
    {
        public ObjectId Id { get; set; }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Project()
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
