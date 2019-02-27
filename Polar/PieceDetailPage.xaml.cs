using System;
using System.Collections.Generic;
using Polar.Model;
using Polar.Services;
using Polar.ViewModel;
using Xamarin.Forms;

namespace Polar
{
    public partial class PieceDetailPage : ContentPage
    {

        public PieceDetailPage(Piece piece)
        {
            InitializeComponent();


            foreach (var item in piece.Tasks)
            {
                Label label = new Label();
                label.Text = item.TaskName;
                if (item.IsComplete)
                {
                    label.TextDecorations = TextDecorations.Strikethrough;
                }
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += Tapped_handler;
                label.GestureRecognizers.Add(tapGestureRecognizer);

                label.BindingContext = item;

                stackView.Children.Add(label);
            }

        }

        private void Tapped_handler(object sender, EventArgs e)
        {
            Label label = sender as Label;

            Task task = label.BindingContext as Task;


            if (task.IsComplete)
            {
                task.IsComplete = false;
                label.TextDecorations = TextDecorations.None;


            }
            else
            {
                task.IsComplete = true;
                label.TextDecorations = TextDecorations.Strikethrough;

            }

            SQLService SQL = new SQLService();
            SQL.UpdateTask(task);
            if (App.user.CheckFinishPiecesByTask(task))
            {
                Navigation.PopAsync();
            }



        }


    }
}
