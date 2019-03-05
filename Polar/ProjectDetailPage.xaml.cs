using System;
using System.Collections.Generic;
using Polar.Model;
using Polar.View;
using Xamarin.Forms;

namespace Polar
{
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage(Project project)
        {
            InitializeComponent();

            DataTemplate customCell = new DataTemplate(typeof(ComponentDetailViewCell));
            pieceList.ItemTemplate = customCell;
            pieceList.ItemsSource = project.Pieces;

        }
    }
}
