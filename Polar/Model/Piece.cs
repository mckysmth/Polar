using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Polar.Services;
using SQLite;

namespace Polar.Model
{
    public class Piece : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [PrimaryKey]
        public string Id { get; set; }

        [Ignore]
        public ObservableCollection<Task> Tasks { get; private set; }

        public string ProjectID { get; set; }

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

        public Piece()
        {
            Id = Guid.NewGuid().ToString();
            Tasks = new ObservableCollection<Task>();
            IsComplete = false;
        }

        public Piece(string projectID)
        {
            Id = Guid.NewGuid().ToString();
            ProjectID = projectID;
            Tasks = new ObservableCollection<Task>();
            IsComplete = false;
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
            Tasks.Add(new Task(Id));
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public Project GetProject()
        {


            foreach (var item in App.user.Projects)
            {
                if (item.Id == ProjectID)
                {
                    return item;
                }
            }
            return null;

        }

        public void DeleteTask(Task task)
        {
            Tasks.Remove(task);
            SQLService SQL = new SQLService();
            SQL.DeleteTask(task);
        }


    }
}
