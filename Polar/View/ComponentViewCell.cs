using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Polar.Model;
using Xamarin.Forms;

namespace Polar.View
{
    public class ComponentViewCell : ViewCell
    {
        public static readonly BindableProperty ProjectProperty =
            BindableProperty.Create("Project", typeof(Project), typeof(ComponentViewCell), null);


        public Project Project
        {
            get { return (Project)GetValue(ProjectProperty); }
            set { SetValue(ProjectProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                StackLayout layout = new StackLayout();

                Label label = new Label();
                label.Text = Project.ProjectName;

                layout.Children.Add(label);
                View = layout;
            }

        }


    }
}
