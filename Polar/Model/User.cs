using System;
using System.ComponentModel;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Polar.Model
{
    [BsonIgnoreExtraElements]
    public class User : INotifyPropertyChanged
    {

        public ObjectId Id { get; set; }

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


        //TODO: Ignore this property when deserialize
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string proertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(proertyName));
        }

        public static async Task<bool> Register(User user)
        {
            bool returnValue = false;

            var filter = Builders<BsonDocument>.Filter.Eq("Email", user.Email);

            BsonDocument bsonsUserDoc = user.ToBsonDocument();

            long count = await Client.GetUserCollection().CountDocumentsAsync(filter);

            if (count == 0)
            {
                returnValue = true;

                Client.userID = user.Id;

                await Client.GetUserCollection().InsertOneAsync(bsonsUserDoc);
            }



            return returnValue;
        }

        public static async Task<bool> Login(string email, string password)
        {
            bool returnValue = false;

            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);

            long count = await Client.GetUserCollection().CountDocumentsAsync(filter);

            if (count == 1)
            {
                var document = await Client.GetUserCollection().Find(filter).FirstAsync();

                User user = BsonSerializer.Deserialize<User>(document);

                if (user.email == email && user.password == password)
                {
                    returnValue = true;

                    Client.userID = user.Id;
                }
            }

            return returnValue;
        }

    }
}
