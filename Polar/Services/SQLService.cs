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

        public void InsertUser(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();

                connection.Insert(user);

            }
        }


        public List<User> GetUserList(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();

                List<User> users = connection.Table<User>().ToList();

                return users;
            }
        }

        public User GetUserByEmail(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();

                List<User> users = connection.Table<User>().ToList();

                User returnUser = users.FirstOrDefault(u => u.Email == user.Email);

                return returnUser;
            }
        }
    }
}
