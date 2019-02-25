using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                foreach (var project in GetProjectListByUserID(returnUser))
                {
                    returnUser.AddProject(project);
                }

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

        public void InsertNewProject(User user, Project project)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                UserProject userProject = new UserProject
                {
                };

                connection.Insert(userProject);
                connection.Insert(project);
                InsertAllPieces(project.Pieces);
            }
        }

        private void InsertAllPieces(ObservableCollection<Piece> pieces)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                foreach (var piece in pieces)
                {
                    connection.Insert(piece);
                    InsertAllTasks(piece.Tasks);
                }
            }
        }

        private void InsertAllTasks(ObservableCollection<Task> tasks)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                foreach (var task in tasks)
                {
                    connection.Insert(task);
                }
            }
        }

        private List<Project> GetProjectListByUserID(User user)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                List<UserProject> userProjects = connection.Table<UserProject>().ToList().FindAll(up => up.UserId == user.Id);
                List<Project> projects = connection.Table<Project>().ToList();

                List<Project> projectsForUser =
                    (from userProject in userProjects
                     join project in projects on userProject.ProjectId equals project.Id
                     select project).ToList();


                foreach (var proj in projectsForUser)
                {
                    foreach (var piece in getPieceByProjectID(proj))
                    {
                        proj.AddPiece(piece);
                    }
                }

                return projectsForUser;
            }
        }

        private List<Piece> getPieceByProjectID(Project project)
        {
            using (connection = new SQLiteConnection(App.DatabaseLocation))
            {
                List<Piece> pieces = connection.Table<Piece>().ToList().FindAll(pc => pc.ProjectID == project.Id);
                foreach (var piece in pieces)
                {
                    foreach (var task in GetTaskListByPieceID(piece))
                    {
                        piece.AddTask(task);
                    }
                }

                return pieces;
            }
        }

        private List<Task> GetTaskListByPieceID(Piece piece)
        {
            List<Task> tasks = connection.Table<Task>().ToList().FindAll(t => t.PieceID == piece.Id);

            return tasks;
        }
    }
}
