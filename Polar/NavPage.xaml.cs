using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Polar
{
    public partial class NavPage : MasterDetailPage
    {
        public NavPage()
        {
            InitializeComponent();

            masterPage.listView.ItemSelected += OnItemSelected;

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
