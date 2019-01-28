using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Polar
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        void editButton_Clicked(object sender, System.EventArgs e)
        {
            editContainer.IsVisible = false;
            displayContainer.IsVisible = true;
        }

        void cancelButton_Clicked(object sender, System.EventArgs e)
        {
            editContainer.IsVisible = true;
            displayContainer.IsVisible = false;
        }
    }
}
