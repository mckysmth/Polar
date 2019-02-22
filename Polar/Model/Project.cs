using System;
using Polar.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using Polar.Services;

namespace Polar.Model
{
    public class Project : INotifyPropertyChanged
    { 

        [PrimaryKey]
        public int Id { get; set; }

        [Ignore]
        public ObservableCollection<Piece> Pieces { get; set; }

        //public List<User> User { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public Project()
        {
            SQLService SQL = new SQLService();
            Id = SQL.CountProjects();
            Pieces = new ObservableCollection<Piece>();
        }

        public Project(bool SholdAddPiece)
        {
            SQLService SQL = new SQLService();
            Id = SQL.CountProjects();
            Pieces = new ObservableCollection<Piece>();
            if (SholdAddPiece)
            {
                Pieces.Add(new Piece(this.Id, SQL.CountPieces()));
            }
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
            SQLService SQL = new SQLService();
            int pieceID;

            pieceID = SQL.CountPieces() + Pieces.Count;
            
            Pieces.Add(new Piece(this.Id, pieceID));
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }
    }
}
