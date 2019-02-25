using System;
using Polar.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;

namespace Polar.Model
{
    public class Project : INotifyPropertyChanged
<<<<<<< HEAD
    {
        [PrimaryKey]
        public string Id { get; set; }
=======
    { 

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
>>>>>>> parent of ce62694... SQL save and load project

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
<<<<<<< HEAD
            Id = Guid.NewGuid().ToString();
            Pieces = new ObservableCollection<Piece>();
            Pieces.Add(new Piece(this.Id));
            
=======
            this.Pieces = new ObservableCollection<Piece>();

        }

        public Project(bool SholdAddPiece)
        {

            this.Pieces = new ObservableCollection<Piece>();
            if (SholdAddPiece)
            {
                Pieces.Add(new Piece(this.Id));
            }
>>>>>>> parent of ce62694... SQL save and load project
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
            Pieces.Add(new Piece(this.Id));
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }
    }
}
