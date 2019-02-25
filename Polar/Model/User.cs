﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Polar.Services;
using SQLite;

namespace Polar.Model
{

    public class User : INotifyPropertyChanged
    {

        public string Id { get; set; }

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

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        [Ignore]
        public ObservableCollection<Project> Projects { get; set; }
    

        public event PropertyChangedEventHandler PropertyChanged;


        public User()
        {

            Id = Guid.NewGuid().ToString();
            Projects = new ObservableCollection<Project>();
            Email = "test";
            Password = "1234";
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void AddProject(Project project) 
        {
            Projects.Add(project);
        }

        public ObservableCollection<Piece> GetPieces()
        {

            ObservableCollection<Piece> pieceList = new ObservableCollection<Piece>();

            foreach (var project in Projects)
            {
                foreach (var piece in project.Pieces)
                {
                    pieceList.Add(piece);
                }
            }

            return pieceList;
        }
    }
}
