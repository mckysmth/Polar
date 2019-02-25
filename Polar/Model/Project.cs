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

<<<<<<< HEAD

    public ObservableCollection<Piece> Pieces { get; set; }
=======
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public ObservableCollection<Piece> Pieces { get; set; }
>>>>>>> parent of ce62694... SQL save and load project

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
            this.Pieces = new ObservableCollection<Piece>();

        }

        public Project(bool SholdAddPiece)
        {

            this.Pieces = new ObservableCollection<Piece>();
            if (SholdAddPiece)
            {
<<<<<<< HEAD
=======
                Pieces.Add(new Piece(this.Id));
>>>>>>> parent of ce62694... SQL save and load project
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
<<<<<<< HEAD
=======
            Pieces.Add(new Piece(this.Id));
>>>>>>> parent of ce62694... SQL save and load project
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }
    }
}
