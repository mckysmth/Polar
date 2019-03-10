using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Polar.Services;
using SQLite;

namespace Polar.Model
{

    public class User : INotifyPropertyChanged
    {
        [PrimaryKey] 
        public string Id { get; set; }

        [Ignore]
        public ObservableCollection<Project> Projects { get; set; }

        [Ignore]
        public ObservableCollection<Piece> EventPieces { get; set; }

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
            Id = Guid.NewGuid().ToString();
            Projects = new ObservableCollection<Project>();
            Email = "test";
            Password = "1234";
            EventPieces = new ObservableCollection<Piece>();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void AddEvent(Piece piece)
        {
            Task task = new Task()
            {
                TaskName = "Done",
                PieceId = piece.Id
            };

            piece.AddTask(task);

            EventPieces.Add(piece);
            SQLService SQL = new SQLService();
            SQL.InsertNewTask(task);
        }

        public void AddProject(Project project) 
        {
            Projects.Add(project);
        }

        public ObservableCollection<Piece> GetBackLog()
        {
            ObservableCollection<Piece> pieceList = new ObservableCollection<Piece>();

            foreach (var project in Projects)
            {
                foreach (var piece in project.Pieces)
                {
                    if (!project.IsComplete && !piece.IsComplete)
                    {
                        pieceList.Add(piece);
                    }
                }
            }

            return pieceList;
        }

        public ObservableCollection<Piece> GetToaysList()
        {
            ObservableCollection<Piece> pieceList = new ObservableCollection<Piece>();

            foreach (var project in Projects)
            {
                foreach (var piece in project.Pieces)
                {
                    if (piece.IsOnDoList && !piece.IsComplete && !project.IsComplete)
                    {
                        pieceList.Add(piece);
                    }
                }
            }

            foreach (var pc in EventPieces)
            {
                if (pc.DateTime.DayOfYear == DateTime.Now.DayOfYear)
                {
                    pieceList.Add(pc);
                }
            }

            return pieceList;
        }

        public bool CheckFinishPiecesByTask(Task task)
        {
            Project project = Projects.FirstOrDefault(p => p.Pieces.Contains(p.Pieces.FirstOrDefault(pc => pc.Id == task.PieceId)));

            Piece piece = project.Pieces.FirstOrDefault(pc => pc.Id == task.PieceId);

            bool allTasksComplete = true;

            foreach (var item in piece.Tasks)
            {
                if (!item.IsComplete)
                {
                    allTasksComplete = false;

                }
            }
            SQLService SQL = new SQLService();

            if (allTasksComplete)
            {
                if (!piece.IsComplete)
                {
                    piece.IsComplete = true;
                    CheckFinishProjectsByPiece(piece);
                    SQL.UpdatePiece(piece);
                }
                return allTasksComplete;
            }
            else
            {
                if (piece.IsComplete)
                {
                    piece.IsComplete = false;
                    SQL.UpdatePiece(piece);
                    CheckFinishProjectsByPiece(piece);
                }
            }

            return allTasksComplete;

        }

        public bool CheckFinishProjectsByPiece(Piece piece)
        {
            Project project = Projects.FirstOrDefault(p => p.Id == piece.ProjectID);

            bool allTasksComplete = true;

            foreach (var item in project.Pieces)
            {
                if (!item.IsComplete)
                {
                    allTasksComplete = false;
                }
            }

            SQLService SQL = new SQLService();

            if (allTasksComplete)
            {
                if (!project.IsComplete)
                {
                    project.IsComplete = true;
                    SQL.UpdateProject(project);
                }
                return allTasksComplete;
            }
            else
            {
                if (project.IsComplete)
                {
                    project.IsComplete = false;
                    SQL.UpdateProject(project);
                }
            }

            return allTasksComplete;
        }

        public void DeleteProject(Project project)
        {
            Projects.Remove(project);
        }

        public Project GetProjectByPiece(Piece piece)
        {
            return Projects.FirstOrDefault(p => p.Id == piece.ProjectID);
        }
        public Piece GetPieceByTask(Task task)
        {
            Project project = Projects.FirstOrDefault(p => p.Pieces.Contains(p.Pieces.FirstOrDefault(pc => pc.Id == task.PieceId)));

            return project.Pieces.FirstOrDefault(pc => pc.Id == task.PieceId);
        }
    }
}
