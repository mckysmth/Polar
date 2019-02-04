using System;
using System.Collections.Generic;
using Polar.ViewModel;
using Xamarin.Forms;

namespace Polar
{
    public partial class NewProjectPage : ContentPage
    {
        NewProjectVM newProjectVM;

        public NewProjectPage()
        {
            InitializeComponent();

            newProjectVM = new NewProjectVM();
            BindingContext = newProjectVM;
        }

        void addCompButton_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
