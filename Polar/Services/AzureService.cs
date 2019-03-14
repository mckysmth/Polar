using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Polar.Model;

namespace Polar.Services
{
    public static class AzureService
    {
        public static async System.Threading.Tasks.Task InsertNewUser(User user)
        {
            App.user = user;
            await App.MobileService.GetTable<User>().InsertAsync(user);

        }

        public static async System.Threading.Tasks.Task<User> GetUserByEmail(User user)
        {
            User returnUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == user.Email).ToListAsync()).FirstOrDefault();

            if (returnUser != null)
            {
                foreach (var project in await GetProjectListByUserID(returnUser))
                {
                    returnUser.AddProject(project);
                }

                foreach (var eventPc in await GetAllEventPiecesByUser(returnUser))
                {
                    returnUser.EventPieces.Add(eventPc);
                }
            }



            return returnUser;
        }

        public static async System.Threading.Tasks.Task InsertNewPiece(Piece piece)
        {
            await App.MobileService.GetTable<Piece>().InsertAsync(piece);
        }

        private static async System.Threading.Tasks.Task<List<Piece>> GetAllEventPiecesByUser(User returnUser)
        {
            List<Piece> pieces = await App.MobileService.GetTable<Piece>().Where(p => p.UserID == returnUser.Id && p.DateTime >= DateTime.Now.Date).ToListAsync();

            foreach (var piece in pieces)
            {
                foreach (var task in await GetTaskListByPieceID(piece))
                {
                    piece.AddTask(task);
                    if (piece.IsComplete)
                    {
                        piece.IsComplete = false;

                        await App.MobileService.GetTable<Piece>().UpdateAsync(piece);
                    }


                }
            }

            return pieces;
        }

        private static async System.Threading.Tasks.Task<List<Task>> GetTaskListByPieceID(Piece piece)
        {
            List<Task> tasks = await App.MobileService.GetTable<Task>().Where(t => t.PieceId == piece.Id).ToListAsync();
            foreach (var task in tasks)
            {
                if (piece.UserID != null && task.IsComplete)
                {

                    task.IsComplete = false;

                    await App.MobileService.GetTable<Task>().UpdateAsync(task);
                }
            }

            return tasks;
        }

        private static async System.Threading.Tasks.Task<List<Project>> GetProjectListByUserID(User returnUser)
        {
            List<UserProject> userProjects = await App.MobileService.GetTable<UserProject>().Where(up => up.UserId == returnUser.Id).ToListAsync();
            List<Project> projects = new List<Project>();
            foreach (var up in userProjects)
            {
                projects.AddRange(await App.MobileService.GetTable<Project>().Where(p => p.Id == up.ProjectId).ToListAsync());
            }


            foreach (var proj in projects)
            {
                foreach (var piece in await GetPieceByProjectID(proj))
                {
                    proj.AddPiece(piece);
                }
            }

            return projects;
        }

        public static async System.Threading.Tasks.Task InsertNewTask(Task task)
        {
            await App.MobileService.GetTable<Task>().InsertAsync(task);
        }

        public static async System.Threading.Tasks.Task DeleteTask(Task task)
        {
            await App.MobileService.GetTable<Task>().DeleteAsync(task);        
        }

        public static async System.Threading.Tasks.Task DeletePiece(Piece piece)
        {
            await App.MobileService.GetTable<Piece>().DeleteAsync(piece);

            foreach (var task in piece.Tasks)
            {
                await DeleteTask(task);
            }
        }

        public static async System.Threading.Tasks.Task DeleteProject(Project project)
        {
            await App.MobileService.GetTable<Project>().DeleteAsync(project);
            UserProject userProject = (await App.MobileService.GetTable<UserProject>().Where(up => up.ProjectId == project.Id).ToListAsync()).FirstOrDefault();

            if (userProject != null)
            {
                await App.MobileService.GetTable<UserProject>().DeleteAsync(userProject);
            }

            foreach (var piece in project.Pieces)
            {
                await DeletePiece(piece);
            }
        }

        private static async System.Threading.Tasks.Task<List<Piece>> GetPieceByProjectID(Project proj)
        {
            List<Piece> pieces = await App.MobileService.GetTable<Piece>().Where(pc => pc.ProjectID == proj.Id).ToListAsync();
            foreach (var piece in pieces)
            {
                foreach (var task in await GetTaskListByPieceID(piece))
                {
                    piece.AddTask(task);
                }
            }
            return pieces;
        }

        public static async System.Threading.Tasks.Task InsertNewProject(User user, Project project)
        {
            UserProject userProject = new UserProject
            {
                ProjectId = project.Id,
                UserId = user.Id
            };
            await App.MobileService.GetTable<UserProject>().InsertAsync(userProject);
            await App.MobileService.GetTable<Project>().InsertAsync(project);

            await InsertAllPieces(project.Pieces);
        }

        public static async System.Threading.Tasks.Task InsertAllPieces(ObservableCollection<Piece> pieces)
        {
            foreach (var piece in pieces)
            {
                await App.MobileService.GetTable<Piece>().InsertAsync(piece);
            }

            foreach (var piece in pieces)
            {
                await InsertAllTasks(piece.Tasks);
            }
        }

        public static async System.Threading.Tasks.Task InsertAllTasks(ObservableCollection<Task> tasks)
        {
            foreach (var task in tasks)
            {
                await App.MobileService.GetTable<Task>().InsertAsync(task);
            }
        }

        public static async System.Threading.Tasks.Task UpdatePiece(Piece piece)
        {
            await App.MobileService.GetTable<Piece>().UpdateAsync(piece);
        }

        public static async System.Threading.Tasks.Task UpdateProject(Project project)
        {
            await App.MobileService.GetTable<Project>().UpdateAsync(project);
        }

        public static async System.Threading.Tasks.Task UpdateTask(Task task)
        {
            await App.MobileService.GetTable<Task>().UpdateAsync(task);
        }
    }
}
