using System;
using System.Collections.Generic;
using Polar.Model;
using Xamarin.Forms;

namespace Polar
{
    public partial class SignUpPage : ContentPage
    {
        User user;

        public SignUpPage()
        {
            InitializeComponent();

            user = new User();
            containerStackLayout.BindingContext = user;

        }

        public async void signUpButton_Clicked(object sender, System.EventArgs e)
        {
            if (password.Text == confirmationPassword.Text)
            {
                if (await User.Register(user))
                {
                    await Navigation.PushAsync(new ProfilePage());
                }
                else
                {
                    errorMessage.Text = "Account already exists";
                }
            }
            else
            {
                errorMessage.Text = "Not matching passwords";
            }
        }
    }
}
