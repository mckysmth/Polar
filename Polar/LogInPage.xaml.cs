using System;
using System.Collections.Generic;
using Polar.Model;
using Xamarin.Forms;

namespace Polar
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        public async void logInButton_Clicked(object sender, System.EventArgs e)
        {
            bool canLogIn = await User.Login(Email.Text, Password.Text);

            if (canLogIn)
            {
                Navigation.PushAsync(new ProfilePage());
            }
            else
            {
                errorMessage.Text = "Incorrect Username/Password";
            }

        }

        void signUpButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}
