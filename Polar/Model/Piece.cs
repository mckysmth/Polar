using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Polar.Model
{
    public class Piece : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Task> Tasks { get; private set; }

        private string pieceName;

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
            Tasks = new ObservableCollection<Task>();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void AddTask()
        {
            Tasks.Add(new Task());
        }


    }
}
