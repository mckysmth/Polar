using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Polar.Model;
using Polar.Services;
using Xamarin.Forms;

namespace Polar
{
    public partial class NewPiecePage : ContentPage
    {

        ObservableCollection<Piece> Pieces;
        Project Project;
        public NewPiecePage(Project project)
        {
            InitializeComponent();

            Project = project;

            Pieces = new ObservableCollection<Piece>
            {
                new Piece()
            };

            BindingContext = Pieces;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            StackLayout stackLayoutInner = new StackLayout();
            StackLayout stackLayoutouter = new StackLayout();

            stackLayoutInner.Orientation = StackOrientation.Horizontal;

            stackLayoutInner.Children.Add(NewTaskButton());
            stackLayoutInner.Children.Add(NewCompEntry());
            stackLayoutouter.Children.Add(stackLayoutInner);

            containerStackLayout.Children.Add(stackLayoutouter);
        }

        private Button NewTaskButton()
        {
            Button button = new Button
            {
                Text = "+T",

                Style = (Style)Resources["TaskButton"]
            };

            button.Clicked += AddTaskButton_Clicked;
            return button;

        }

        private Entry NewCompEntry()
        {
            Entry entry = new Entry
            {
                Style = (Style)Resources["ComponentEntry"],
                ClassId = Pieces.Count.ToString()
            };

            entry.SetBinding(Entry.TextProperty, "[" + Pieces.Count + "].PieceName", BindingMode.TwoWay);

            entry.Placeholder = "Component";

            AddPiece();
            entry.CursorPosition = 0;
            return entry;
        }

        private void AddPiece()
        {
            Pieces.Add(new Piece());
        }

        void AddTaskButton_Clicked(object sender, System.EventArgs e)
        {
            StackLayout stackLayout = ((StackLayout)((Button)sender).Parent);
            int compIndexNum = Int32.Parse(stackLayout.Children[1].ClassId);

            Entry entry = NewTaskEntry(compIndexNum);

            ((StackLayout)stackLayout.Parent).Children.Add(entry); ;

        }
        private Entry NewTaskEntry(int compIndexNum)
        {
            Entry entry = new Entry();
            int taskIndexNum = Pieces[compIndexNum].Tasks.Count;
            string bindingSource = "[" + compIndexNum + "].Tasks[" + taskIndexNum + "].TaskName";
            Pieces[compIndexNum].AddTask();

            entry.SetBinding(Entry.TextProperty, bindingSource, BindingMode.TwoWay);

            entry.Placeholder = "Task";

            entry.CursorPosition = 0;
            entry.Style = (Style)Resources["TaskEntry"];



            return entry;
        }

        async void Handle_Clicked_1Async(object sender, System.EventArgs e)
        {
            //SQLService SQL = new SQLService();

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
                piece.ProjectID = Project.Id;
                Project.AddPiece(piece);
            }
            await AzureService.InsertAllPieces(Pieces);

            await Navigation.PopAsync();
        }
    }
}
