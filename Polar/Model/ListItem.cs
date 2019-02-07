using System;
using System.ComponentModel;

namespace Polar.Model
{
    public class ListItem : INotifyPropertyChanged
    {
        private Project project;

        public Project Project
        {
            get { return project; }
            set
            {
                project = value;
                OnPropertyChanged("Password");
            }
        }

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
