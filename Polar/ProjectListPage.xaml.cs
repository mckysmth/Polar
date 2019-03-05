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
        }

        void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Project project = (Project)e.Item;
            Navigation.PushAsync(new ProjectDetailPage(project));
        }
    }
}
