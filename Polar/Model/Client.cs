using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Polar.Model
{
    public static class Client
    {
        static MongoClient mongoClient = new MongoClient();
        public static IMongoDatabase database = mongoClient.GetDatabase("Polar");
        public static ObjectId userID;




        public static IMongoCollection<BsonDocument> GetUserCollection()
        {
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Users");

            return collection;
        }

        public static IMongoCollection<BsonDocument> GetProjectsCollection()
        {
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Projects");

            return collection;
        }

        public static User GetUser()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", userID);
           
            return BsonSerializer.Deserialize<User>(GetUserCollection().Find(filter).First());
        }
    }
}
