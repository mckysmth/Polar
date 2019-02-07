using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Polar.Model
{
    public static class Client
    {
        static MongoClient mongoClient = new MongoClient();
        public static IMongoDatabase database = mongoClient.GetDatabase("Polar");
        public static ObjectId userID;




        public static IMongoCollection<User> GetUserCollection()
        {
            IMongoCollection<User> collection = database.GetCollection<User>("Users");

            return collection;
        }

        public static IMongoCollection<Project> GetProjectsCollection()
        {
            IMongoCollection<Project> collection = database.GetCollection<Project>("Projects");

            return collection;
        }

        public static User GetUser()
        {
            var filter = Builders<User>.Filter.Eq("_id", userID);
           
            return GetUserCollection().Find(filter).First();
        }
    }
}
