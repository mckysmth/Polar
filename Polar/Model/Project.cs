using System;
using Polar.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Polar.Model
{
    public class Project : INotifyPropertyChanged
    {
        public ObjectId Id { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public Project()
        {
            Id = ObjectId.GenerateNewId();

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

        public static async Task<bool> RegisterProject(Project project)
        {
            await Client.GetProjectsCollection().InsertOneAsync(project.ToBsonDocument());

            return true;
        }
    }
}
