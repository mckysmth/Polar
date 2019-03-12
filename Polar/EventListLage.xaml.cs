using System;
using System.Collections.Generic;
using Polar.Model;
using Xamarin.Forms;

namespace Polar
{
    public partial class EventListLage : ContentPage
    {
        User user;
        public EventListLage()
        {
            InitializeComponent();
            user = App.user;
            BindingContext = App.user;

        }
    }
}
