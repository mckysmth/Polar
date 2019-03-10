using System;
using Polar.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using SQLite;

namespace Polar.Model
{
    public class Project : INotifyPropertyChanged { 


        [PrimaryKey]
        public string Id { get; set; }

        [Ignore]
        public ObservableCollection<Piece> Pieces { get; set; }

        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }

        private bool isComplete;

        public bool IsComplete
        {
            get { return isComplete; }
            set
            {
                isComplete = value;
                OnPropertyChanged("TaskName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Project()
        {
            Id = Guid.NewGuid().ToString();
            Pieces = new ObservableCollection<Piece>();
            IsComplete = false;
        }

        public Project(bool ShouldAddPiece)
        {
            Id = Guid.NewGuid().ToString();
            Pieces = new ObservableCollection<Piece>();
            Pieces.Add(new Piece(Id));
            IsComplete = false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Clean()
        {
            foreach (var piece in Pieces)
            {
                if (piece.Tasks.Count < 1)
                {
                    Task task = new Task(piece.Id)
                    {
                        TaskName = "Done"
                    };
                    piece.AddTask(task);
                }
            }
        }

        public void AddPiece() 
        {
            Pieces.Add(new Piece(Id));
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }

        public void DeletePiece(Piece piece)
        {
            Pieces.Remove(piece);

        }


        public void Reuse()
        {
            IsComplete = false;

            foreach (var piece in Pieces)
            {
                piece.IsComplete = false;
                piece.IsOnDoList = false;

                foreach (var task in piece.Tasks)
                {
                    task.IsComplete = false;
                }
            }
        }

    }
}
