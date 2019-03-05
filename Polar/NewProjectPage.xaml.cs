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

            newProjectVM = new NewProjectVM(this);
            BindingContext = newProjectVM;


        }

        void addCompButton_Clicked(object sender, System.EventArgs e)
        {
            StackLayout stackLayoutInner = new StackLayout();
            StackLayout stackLayoutouter = new StackLayout();

            stackLayoutInner.Orientation = StackOrientation.Horizontal;

            stackLayoutInner.Children.Add(NewTaskButton());
            stackLayoutInner.Children.Add(NewCompEntry());
            stackLayoutouter.Children.Add(stackLayoutInner);

            containerStackLayout.Children.Add(stackLayoutouter);
        }

        void addTaskButton_Clicked(object sender, System.EventArgs e)
        {
            StackLayout stackLayout = ((StackLayout)((Button)sender).Parent);
            int compIndexNum = Int32.Parse(stackLayout.Children[1].ClassId);

            Entry entry = NewTaskEntry(compIndexNum);

            ((StackLayout)stackLayout.Parent).Children.Add(entry);;

        }

        private Entry NewTaskEntry(int compIndexNum)
        {
            Entry entry = new Entry();
            int taskIndexNum = newProjectVM.Project.Pieces[compIndexNum].Tasks.Count;
            string bindingSource = "Project.Pieces[" + compIndexNum + "].Tasks[" + taskIndexNum + "].TaskName";
            newProjectVM.Project.Pieces[compIndexNum].AddTask();

            entry.SetBinding(Entry.TextProperty, bindingSource, BindingMode.TwoWay);

            entry.Placeholder = "Task";

            entry.CursorPosition = 0;
            entry.Style = (Style)Resources["TaskEntry"];



            return entry;
        }

        private Button NewTaskButton()
        {
            Button button = new Button();

            button.Text = "+T";

            button.Style = (Style)Resources["TaskButton"];

            button.Clicked += addTaskButton_Clicked;
            return button;

        }

        private Entry NewCompEntry()
        {
            Entry entry = new Entry();
            entry.Style = (Style)Resources["ComponentEntry"];
            entry.ClassId = newProjectVM.Project.Pieces.Count.ToString();

            entry.SetBinding(Entry.TextProperty, "Project.Pieces[" + newProjectVM.Project.Pieces.Count + "].PieceName", BindingMode.TwoWay);

            entry.Placeholder = "Component";

            newProjectVM.Project.AddPiece();
            entry.CursorPosition = 0;
            return entry;
        }

    }
}
