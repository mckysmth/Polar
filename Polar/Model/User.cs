using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace Polar.Model
{

    public class User : INotifyPropertyChanged
    {
        public ObservableCollection<ObjectId> ProjectIDs { get; set; }

        public static ObjectId id;
        public ObjectId Id 
        { 
            get { return id; }
            set 
            {
                id = value;
            }
        }

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



        public event PropertyChangedEventHandler PropertyChanged;


        public User()
        {
            Id = ObjectId.GenerateNewId();
            this.ProjectIDs = new ObservableCollection<ObjectId>();
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
            ProjectIDs.Add(project.Id);
        }
    }
}
