using System;
using System.Security.Authentication;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson;
using Polar.Model;
using System.Collections.ObjectModel;

namespace Polar.Services
{
    public class MongoService
    {
        string dbName = "Polar";
        string userCollectionName = "Users";
        string projectCollectionName = "Project";

        IMongoCollection<User> userCollection;
        IMongoCollection<User> UserCollection
        {
            get
            {
                if (userCollection == null)
                {
                    // This will create or get the collection
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    userCollection = ConnectDB().GetCollection<User>(userCollectionName, collectionSettings);
                }
                return userCollection;
            }
        }

        IMongoCollection<Project> projectCollection;
        IMongoCollection<Project> ProjectCollection
        {
            get
            {
                if (projectCollection == null)
                {
                    // This will create or get the collection
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    projectCollection = ConnectDB().GetCollection<Project>(projectCollectionName, collectionSettings);
                }
                return projectCollection;
            }
        }


        private IMongoDatabase ConnectDB()
        {
            // APIKeys.Connection string is found in the portal under the "Connection String" blade
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl("mongodb://food-app:UjsUsROtZnTaR7v2yM7bvW1nOWea68VwRLiJ6IaMbo4QvEctRpAVSv85pejGMBFmxwnus1LsmUjrTGhbVSUswQ==@food-app.documents.azure.com:10255/?ssl=true&replicaSet=globaldb")
            );

            settings.SslSettings =
                new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            // Initialize the client
            var mongoClient = new MongoClient(settings);

            // This will create or get the database
            var db = mongoClient.GetDatabase(dbName);

            return db;
        }


        public async System.Threading.Tasks.Task InsertNewUser(User user)
        {
            await UserCollection.InsertOneAsync(user);
        }

        public async Task<ObservableCollection<User>> GetAllUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>(); 
            try
            {
                var allTasks = await UserCollection
                    .Find(new BsonDocument())
                    .ToListAsync();

                foreach (var item in allTasks)
                {
                    users.Add(item);
                }

                return users;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var singleUser = await UserCollection
                .Find(f => f.Email.Equals(email))
                .FirstOrDefaultAsync();

            return singleUser;
        }

        public async System.Threading.Tasks.Task InsertProject(Project project)
        {
            await ProjectCollection.InsertOneAsync(project);
        }

        public async Task<ObservableCollection<Project>> GetAllProjects()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>();
            try
            {
                var allTasks = await ProjectCollection
                    .Find(new BsonDocument())
                    .ToListAsync();

                foreach (var item in allTasks)
                {
                    projects.Add(item);
                }

                return projects;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
