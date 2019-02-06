using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Polar.Model;
using Xamarin.Forms;

namespace Polar.View
{
    public class ComponentViewCell : ViewCell
    {
        public static readonly BindableProperty ProjectNameProperty =
            BindableProperty.Create("ProjectName", typeof(string), typeof(ComponentViewCell), "");


        public string ProjectName
        {
            get { return (string)GetValue(ProjectNameProperty); }
            set { SetValue(ProjectNameProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                StackLayout layout = new StackLayout();

                Label label = new Label();
                label.Text = ProjectName;

                layout.Children.Add(label);
                View = layout;
            }

        }


    }
}
