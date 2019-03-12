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

            BindingContext = piece;


            foreach (var item in piece.Tasks)
            {
                Label label = new Label
                {
                    Text = item.TaskName
                };

                if (item.IsComplete)
                {
                    label.TextDecorations = TextDecorations.Strikethrough;
                }

                Frame frame = new Frame
                {
                    Content = label
                };
                frame.BindingContext = item;

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += Tapped_handlerAsync;
                frame.GestureRecognizers.Add(tapGestureRecognizer);

                frame.Style = (Style)Resources["TaskFrame"];

                stackView.Children.Add(frame);
            }

        }

        private async void Tapped_handlerAsync(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;

            Task task = frame.BindingContext as Task;


            if (task.IsComplete)
            {
                task.IsComplete = false;
                ((Label)frame.Content).TextDecorations = TextDecorations.None;


            }
            else
            {
                task.IsComplete = true;
                ((Label)frame.Content).TextDecorations = TextDecorations.Strikethrough;

            }

            //SQLService SQL = new SQLService();
            await AzureService.UpdateTask(task);
            if (await App.user.CheckFinishPiecesByTaskAsync(task))
            {
                PieceName.TextDecorations = TextDecorations.Strikethrough;
                PieceName.TextColor = Color.LightGray;
            }
            else
            {
                PieceName.TextDecorations = TextDecorations.Underline;
                PieceName.TextColor = Color.Default;

            }



        }


    }
}
