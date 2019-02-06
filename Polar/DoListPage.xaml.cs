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
        public DoListPage()
        {
            InitializeComponent();

            doListVm = new DoListVM();
            BindingContext = doListVm;

            DataTemplate customCell = new DataTemplate(typeof(ComponentViewCell));

            customCell.SetBinding(ComponentViewCell.ProjectNameProperty, "ProjectName");

            backLog.ItemTemplate = customCell;
            backLog.ItemsSource = doListVm.User.BuildPieceList();


        }
    }
}
