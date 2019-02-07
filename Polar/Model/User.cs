using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Polar.Model
{

    public class User : INotifyPropertyChanged
    {

        public ObjectId Id { get; set; }
        public ObservableCollection<ObjectId> ProjectIDs { get; set; }

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

        public ObservableCollection<ListItem> BuildPieceList()
        {
            ObservableCollection<ListItem> listItems = new ObservableCollection<ListItem>();
            ObservableCollection<Project> queryable = new ObservableCollection<Project>();
            var collection = Client.GetProjectsCollection();

            foreach (ObjectId objID in this.ProjectIDs)
            {
                var filter = Builders<Project>.Filter.Eq("_id", objID);
                Project project = collection.Find(filter).First();


                queryable.Add(project);
            }
            //var queryable = collection.AsQueryable();

            var projectQuery =
            from fProject in queryable
            from fPiece in fProject.Pieces
            group fPiece by fProject;


            foreach (var group in projectQuery)
            {
                foreach (var piece in group)
                {
                    listItems.Add(new ListItem { Piece = piece, Id = group.Key });
                }
            }






            return listItems; 

          }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static async Task<bool> Register(User user)
        {
            bool returnValue = false;

            var filter = Builders<User>.Filter.Eq("Email", user.Email);

            //BsonDocument bsonsUserDoc = user.ToBsonDocument();

            long count = await Client.GetUserCollection().CountDocumentsAsync(filter);

            if (count == 0)
            {
                returnValue = true;

                Client.userID = user.Id;

                await Client.GetUserCollection().InsertOneAsync(user);

            }



            return returnValue;
        }

        public static async Task<bool> Login(string email, string password)
        {
            bool returnValue = false;

            var filter = Builders<User>.Filter.Eq("Email", email);

            long count = await Client.GetUserCollection().CountDocumentsAsync(filter);

            if (count == 1)
            {
                User user = await Client.GetUserCollection().Find(filter).FirstAsync();
                
                if (user.email == email && user.password == password)
                {
                    returnValue = true;

                    Client.userID = user.Id;
                }
            }

            return returnValue;
        }

        public void AddProject(Project project) 
        {
            ProjectIDs.Add(project.Id);
        }

        public static async Task<bool> UpdateProjectIDs(User user)
        {
            var filter = Builders<User>.Filter.Eq("_id", user.Id);
            var update = Builders<User>.Update.Set("ProjectIDs", user.ProjectIDs);

            await Client.GetUserCollection().UpdateOneAsync(filter, update);

            return true;
        }


    }
}
