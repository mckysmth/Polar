using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Polar.Model;
using Polar.ViewModel;
using Polar.View;
using Xamarin.Forms;

namespace Polar
{
    public partial class DoListPage : ContentPage
    {
        
        DoListVM doListVm;

        DataTemplate customCell = new DataTemplate(typeof(ComponentDetailViewCell));
        DataTemplate customCellWithSwitch = new DataTemplate(typeof(ComponentViewCellWithSwitch));
        public DoListPage()
        {
            InitializeComponent();
            doListVm = new DoListVM(this);

            BindingContext = doListVm;

            backLog.ItemTemplate = customCell;
            backLog.ItemsSource = doListVm.TodaysList;




        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            backLog.ItemTemplate = customCell;

            backLog.ItemsSource = doListVm.TodaysList;

            MenuItem.Text = "Plan Day";
            backLog.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            doListVm.UpdateTodaysList();
            doListVm.UpdateBackLog();

        }

        void ViewPieceDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Piece piece)
            {
                this.Navigation.PushAsync(new PieceDetailPage(piece));
            }
        }


        void PlanDaySwitch_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {

            if (MenuItem.Text == "Plan Day" )
            {
                backLog.ItemTemplate = customCellWithSwitch;
                backLog.ItemsSource = doListVm.Backlog;
                backLog.SelectionMode = ListViewSelectionMode.None;
                MenuItem.Text = "Do It!";
            }
            else
            {
                doListVm.UpdateTodaysList();
                backLog.ItemTemplate = customCell;
                backLog.ItemsSource = doListVm.TodaysList;
                backLog.SelectionMode = ListViewSelectionMode.Single;
                MenuItem.Text = "Plan Day";
            }

        }
    }
}
