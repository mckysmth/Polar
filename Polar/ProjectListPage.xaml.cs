using System;
using System.Collections.Generic;
using Polar.Model;
using Polar.ViewModel;
using Xamarin.Forms;

namespace Polar
{
    public partial class ProjectListPage : ContentPage
    {
        ProjectListVM projectListVM;

        public ProjectListPage()
        {
            InitializeComponent();

            projectListVM = new ProjectListVM(this);

            BindingContext = projectListVM;

            pageTitle.Text = "Projects";

            listView.SetBinding(ListView.ItemsSourceProperty, "User.Projects");
            listView.ItemTemplate = (DataTemplate)Resources["ProjectTemplate"];
        }

        public ProjectListPage(Project project)
        {
            InitializeComponent();

            projectListVM = new ProjectListVM(this);

            BindingContext = projectListVM;
            pageTitle.Text = project.ProjectName;

            listView.BindingContext = project;
            listView.SetBinding(ListView.ItemsSourceProperty, "Pieces");
            listView.ItemTemplate = (DataTemplate)Resources["PieceTemplate"];
        }

        public ProjectListPage(Piece piece)
        {
            InitializeComponent();

            projectListVM = new ProjectListVM(this);

            BindingContext = projectListVM;
            pageTitle.Text = piece.PieceName;

            listView.BindingContext = piece;
            listView.SetBinding(ListView.ItemsSourceProperty, "Tasks");
            listView.ItemTemplate = (DataTemplate)Resources["TaskTemplate"];
        }


        void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (((ListView)sender).SelectedItem is Project project)
            {
                Navigation.PushAsync(new ProjectListPage(project));
            } else if (((ListView)sender).SelectedItem is Piece piece)
            {
                Navigation.PushAsync(new ProjectListPage(piece));
            }

        }

       
    }
}
