using System;
using System.Collections.Generic;
using Polar.Model;
using Polar.ViewModel;
using Xamarin.Forms;

namespace Polar
{
    public partial class LogInPage : ContentPage
    {
        LogInVM viewModel;

        public LogInPage()
        {
            InitializeComponent();

            viewModel = new LogInVM();

            BindingContext = viewModel;
        }


    }
}
