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
    { 

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public ObservableCollection<Piece> Pieces { get; set; }

        public List<User> User { get; set; }

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

            Pieces.Add(new Piece());
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
            Pieces.Add(new Piece());
        }
    }
}
