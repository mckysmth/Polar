using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SQLite;

namespace Polar.Model
{
    public class Piece : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Task> Tasks { get; private set; }

        public int ProjectID { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

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

        private bool isOnDoList;

        public bool IsOnDoList
        {
            get { return isOnDoList; }
            set
            {
                isOnDoList = value;
                OnPropertyChanged("IsOnDoList");
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
