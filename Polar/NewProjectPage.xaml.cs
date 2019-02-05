using System;
using System.Collections.Generic;
using Polar.ViewModel;
using Xamarin.Forms;

namespace Polar
{
    public partial class NewProjectPage : ContentPage
    {
        NewProjectVM newProjectVM;

        public NewProjectPage()
        {
            InitializeComponent();

            newProjectVM = new NewProjectVM();
            BindingContext = newProjectVM;
        }

        void addCompButton_Clicked(object sender, System.EventArgs e)
        {
            StackLayout stackLayout = new StackLayout();


            stackLayout.Children.Add(NewCompEntry());
            stackLayout.Children.Add(NewTaskButton());

            containerStackLayout.Children.Add(stackLayout);
        }

        void addTaskButton_Clicked(object sender, System.EventArgs e)
        {
            StackLayout stackLayout = ((StackLayout)((Button)sender).Parent);
            int compIndexNum = Int32.Parse(stackLayout.Children[0].ClassId);



            stackLayout.Children.Add(NewTaskEntry(compIndexNum));

        }

        private Entry NewTaskEntry(int compIndexNum)
        {
            Entry entry = new Entry();
            int taskIndexNum = newProjectVM.Project.Pieces[compIndexNum].Tasks.Count;
            string bindingSource = "Project.Pieces[" + compIndexNum + "].Tasks[" + taskIndexNum + "].TaskName";
            newProjectVM.Project.Pieces[compIndexNum].AddTask();

            entry.SetBinding(Entry.TextProperty, bindingSource, BindingMode.TwoWay);

            entry.Placeholder = "Task";


            return entry;
        }

        private Button NewTaskButton()
        {
            Button button = new Button();

            button.Text = "+ Task";

            button.Clicked += addTaskButton_Clicked;
            return button;

        }

        private Entry NewCompEntry()
        {
            Entry entry = new Entry();

            entry.ClassId = newProjectVM.Project.Pieces.Count.ToString();

            entry.SetBinding(Entry.TextProperty, "Project.Pieces[" + newProjectVM.Project.Pieces.Count + "].PieceName", BindingMode.TwoWay);

            entry.Placeholder = "Component";

            newProjectVM.Project.AddPiece();

            return entry;
        }
    }
}
