using System;
using System.Collections.Generic;
using System.Linq;
using Polar.Model;
using SQLite;

namespace Polar.Services
{
    public class SQLService
    {

        SQLiteConnection connection;

        public SQLService()
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                //connection.DropTable<User>();
                //connection.DropTable<Project>();
                //connection.DropTable<Piece>();
                //connection.DropTable<Task>();
                //connection.DropTable<UserProject>();


                connection.CreateTable<User>();
                connection.CreateTable<Project>();
                connection.CreateTable<Piece>();
                connection.CreateTable<Task>();
                connection.CreateTable<UserProject>();
            }
        }

        public void InsertNewUser(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                App.user = user;
                connection.Insert(user);
            }
        }


        public List<User> GetUserList(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                List<User> users = connection.Table<User>().ToList();

                return users;
            }
        }

        public User GetUserByEmail(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                List<User> users = connection.Table<User>().ToList();

                User returnUser = users.FirstOrDefault(u => u.Email == user.Email);

                return returnUser;
            }
        }

        public void UpdateUser(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                App.user = user;
                connection.Update(user);

            }
        }
    }
}
