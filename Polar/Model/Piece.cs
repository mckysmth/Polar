﻿using System;
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

        public Piece()
        {
            Id = Guid.NewGuid().ToString();
            Tasks = new ObservableCollection<Task>();
        }

        public Piece(string projectID)
        {
            Id = Guid.NewGuid().ToString();
            ProjectID = projectID;
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
            Tasks.Add(new Task(Id));
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public Project getProject()
        {
            SQLService SQL = new SQLService();

            return SQL.GetProjectById(ProjectID);

        }


    }
}
