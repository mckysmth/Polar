using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
using SQLite;

namespace Polar.Model
{
    public class Piece : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [PrimaryKey]
        public string Id { get; set; }

        [Ignore]
        [JsonIgnore]
        public ObservableCollection<Task> Tasks { get; private set; }

        public string ProjectID { get; set; }

        public string UserID { get; set; }

        private DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");
            }
        }

        private int isRepeating;
        public int IsRepeating
        {
            get { return isRepeating; }
            set
            {
                isRepeating = value;
                OnPropertyChanged("IsRepeating");
            }
        }
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

        public Piece(string userID, DateTime dateTime, int isRepeating) 
        {
            Id = Guid.NewGuid().ToString();
            UserID = userID;
            DateTime = dateTime;
            IsRepeating = isRepeating;
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
        }

        public void AddRepeatTime(bool canAdd)
        {
            DateTime startDate = DateTime;

            Repeater repeaterCode = (Repeater)IsRepeating;

            bool isResedule = false;
            string repeaterString = Enum.Format(typeof(Repeater), repeaterCode, "f");

            if (repeaterCode == Repeater.Monthly)
            {
                if (canAdd)
                {
                    DateTime = DateTime.AddMonths(1);
                }
                else
                {
                    DateTime = DateTime.AddMonths(-1);
                }
                isResedule = true;
            }
            else if (repeaterCode == Repeater.Weekly)
            {
                if (canAdd)
                {
                    DateTime = DateTime.AddDays(7);
                }
                else
                {
                    DateTime = DateTime.AddDays(-7);
                }
                isResedule = true;
            }


            while (!isResedule && repeaterCode != Repeater.None)
            {
                if (repeaterString.Contains(Enum.Format(typeof(DayOfWeek), startDate.DayOfWeek, "f")) && !startDate.Equals(DateTime))
                {
                    DateTime = startDate;
                    isResedule = true;
                }
                else if (canAdd)
                {
                    startDate = startDate.AddDays(1);
                }
                else
                {
                    startDate = startDate.AddDays(-1);

                }

            }
        }
    }
}
