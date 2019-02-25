//using System;
//using System.Collections.Generic;
//using Polar.Model;

//namespace Polar.Services
//{
//    public class AzureService
//    {
//        SQLiteConnection App.mobileServiceClient;

//        public AzureService()
//        {
//            //using (App.mobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            //{
//            //    //connection.DropTable<User>();
//            //    //connection.DropTable<Project>();
//            //    //connection.DropTable<Piece>();
//            //    //connection.DropTable<Task>();
//            //    //connection.DropTable<UserProject>();


//            //    App.mobileServiceClient.CreateTable<User>();
//            //    App.mobileServiceClient.CreateTable<Project>();
//            //    App.mobileServiceClient.CreateTable<Piece>();
//            //    App.mobileServiceClient.CreateTable<Task>();
//            //    App.mobileServiceClient.CreateTable<UserProject>();
//            //}
//        }

//        public async System.Threading.Tasks.Task InsertNewUser(User user)
//        {
//            App.user = user;
//            await App.MobileServiceClient.GetTable<User>().InsertAsync(user);
//        }

//        public async System.Threading.Tasks.Task<User> GetUserByEmailAsync(User user)
//        {

//            List<User> users = await App.MobileServiceClient.GetTable<User>().Where(u => u.Email == user.Email).ToListAsync();

//            User returnUser = users.Find(u => u.Email == user.Email);

//            if (returnUser != null)
//            {
//                foreach (var project in GetProjectListByUserIDAsync(returnUser))
//                {
//                    returnUser.AddProject(project);
//                }
//            }

//            return returnUser;

//        }

//        public void UpdateUser(User user)
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                App.user = user;
//                App.MobileServiceClient.Update(user);

//            }
//        }

//        public void InsertNewProject(User user, Project project)
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                UserProject userProject = new UserProject
//                {
//                    UserId = user.Id,
//                    ProjectId = project.Id
//                };

//                App.MobileServiceClient.Insert(userProject);
//                App.MobileServiceClient.Insert(project);
//                InsertAllPieces(project.Pieces);


//            }
//        }

//        public void InsertAllPieces(ObservableCollection<Piece> pieces)
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                App.MobileServiceClient.InsertAll(pieces);
//                foreach (var piece in pieces)
//                {
//                    InsertAllTasks(piece.Tasks);
//                }
//            }
//        }

//        public void InsertAllTasks(ObservableCollection<Task> tasks)
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                App.MobileServiceClient.InsertAll(tasks);
//            }
//        }

//        public async System.Threading.Tasks.Task<List<Project>> GetProjectListByUserIDAsync(User user)
//        {
//            //List<UserProject> userProjects = await App.MobileServiceClient.GetTable<UserProject>().Where(up => up.UserId == user.Id).ToListAsync();
//            //List<Project> projects = await App.MobileServiceClient.GetTable<Project>().ToListAsync();
//            var projects = App.MobileServiceClient.;


//            List<Project> projectsForUser =
//            (from userProject in projects
//             join project in projects on userProject.ProjectId equals project.Id
//             select project).ToList();


//            foreach (var proj in projectsForUser)
//            {
//                foreach (var piece in getPieceByProjectID(proj))
//                {
//                    proj.AddPiece(piece);
//                }
//            }

//            return projectsForUser;
            
//        }

//        public List<Piece> getPieceByProjectID(Project project)
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                List<Piece> pieces = App.MobileServiceClient.Table<Piece>().ToList().FindAll(pc => pc.ProjectID == project.Id);
//                foreach (var piece in pieces)
//                {
//                    foreach (var task in GetTaskListByPieceID(piece))
//                    {
//                        piece.AddTask(task);
//                    }
//                }

//                return pieces;
//            }
//        }

//        public List<Task> GetTaskListByPieceID(Piece piece)
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                List<Task> tasks = App.MobileServiceClient.Table<Task>().ToList().FindAll(t => t.PieceID == piece.Id);

//                return tasks;
//            }
//        }

//        public int CountUsers()
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                try
//                {
//                    return App.MobileServiceClient.Table<User>().Count();
//                }
//                catch (Exception ex)
//                {
//                    return 0;
//                }

//            }
//        }

//        public int CountProjects()
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                try
//                {
//                    return App.MobileServiceClient.Table<Project>().Count();
//                }
//                catch (Exception ex)
//                {
//                    return 0;
//                }
//            }
//        }

//        public int CountPieces()
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                try
//                {
//                    return App.MobileServiceClient.Table<Piece>().Count();
//                }
//                catch (Exception ex)
//                {
//                    return 0;
//                }
//            }
//        }
//        public int CountTasks()
//        {
//            using (App.MobileServiceClient = new SQLiteConnection(App.DatabaseLocation))
//            {
//                try
//                {
//                    return App.MobileServiceClient.Table<Task>().Count();
//                }
//                catch (Exception ex)
//                {
//                    return 0;
//                }
//            }
//        }
//    }
//}
