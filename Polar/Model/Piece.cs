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

<<<<<<< HEAD
=======
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
>>>>>>> parent of ce62694... SQL save and load project


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

<<<<<<< HEAD

=======
        public Piece(int id)
        {
            Tasks = new ObservableCollection<Task>();
            ProjectID = id;
        }
>>>>>>> parent of ce62694... SQL save and load project

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void AddTask()
        {
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }


    }
}
