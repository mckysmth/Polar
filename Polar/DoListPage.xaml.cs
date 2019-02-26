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

        DataTemplate customCell = new DataTemplate(typeof(ComponentViewCell));
        DataTemplate customCellWithSwitch = new DataTemplate(typeof(ComponentViewCellWithSwitch));
        public DoListPage()
        {
            InitializeComponent();
            doListVm = new DoListVM();

            BindingContext = doListVm;


            backLog.ItemTemplate = customCell;
            backLog.ItemsSource = doListVm.User.GetToaysList();




        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            backLog.ItemTemplate = customCell;

            backLog.ItemsSource = doListVm.User.GetToaysList();

            PlanDaySwitch.IsToggled = false;

        }

        void ViewPieceDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var piece = e.SelectedItem as Piece;

            Navigation.PushAsync(new PieceDetailPage(piece));
        }


        void PlanDaySwitch_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            var planDay = e.Value;
            if (planDay)
            {
                backLog.ItemTemplate = customCellWithSwitch;
                backLog.ItemsSource = doListVm.User.GetBackLog();
                backLog.SelectionMode = ListViewSelectionMode.None;
            }
            else
            {
                backLog.ItemTemplate = customCell;
                backLog.ItemsSource = doListVm.User.GetToaysList();
                backLog.SelectionMode = ListViewSelectionMode.Single;
            }
        }
    }
}
