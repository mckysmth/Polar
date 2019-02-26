using System;
using Polar.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;

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

        public void AddPiece() 
        {
            Pieces.Add(new Piece(Id));
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }
    }
}
