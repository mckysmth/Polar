using System;
using System.Collections.Generic;
using Polar.Model;
using Polar.ViewModel;
using Xamarin.Forms;

namespace Polar
{
    public partial class SignUpPage : ContentPage
    {
        SignUpVM signUpVM;

        public SignUpPage()
        {
            InitializeComponent();

            BindingContext = signUpVM;
        }


    }
}
