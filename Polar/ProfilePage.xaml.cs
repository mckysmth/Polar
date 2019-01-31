using System;
using System.Collections.Generic;
using Polar.Model;
using Xamarin.Forms;

namespace Polar
{
    public partial class ProfilePage : ContentPage
    {
        User user;

        public ProfilePage()
        {
            InitializeComponent();
            user = Client.GetUser();
            containerStackLayout.BindingContext = user;
            editContainer.BindingContext = user;
        }

        void editButton_Clicked(object sender, System.EventArgs e)
        {
            editContainer.IsVisible = true;
            displayContainer.IsVisible = false;
        }

        void cancelButton_Clicked(object sender, System.EventArgs e)
        {
            editContainer.IsVisible = false;
            displayContainer.IsVisible = true;
        }
    }
}
