using System;
using System.Collections.Generic;
using Polar.Model;
using Polar.Services;
using Xamarin.Forms;

namespace Polar
{
    public partial class NewTaskPage : ContentPage
    {
        List<Task> Tasks;
        Piece Piece;
        public NewTaskPage(Piece piece)
        {
            InitializeComponent();

            Piece = piece;
            Tasks = new List<Task>
            {
                new Task()
            };
            BindingContext = Tasks;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            mainLayout.Children.Add(NewTaskEntry());

        }

        private Entry NewTaskEntry()
        {
            Entry entry = new Entry();
            int taskIndexNum = Tasks.Count;
            string bindingSource = "[" + taskIndexNum + "].TaskName";
            Tasks.Add(new Task());

            entry.SetBinding(Entry.TextProperty, bindingSource, BindingMode.TwoWay);

            entry.Placeholder = "Task";

            entry.CursorPosition = 0;

            return entry;
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            SQLService SQL = new SQLService();

            foreach (var item in Tasks)
            {
                item.PieceId = Piece.Id;
                Piece.AddTask(item);
                SQL.InsertNewTask(item);
            }
            Navigation.PopAsync();
        }
    }
}
