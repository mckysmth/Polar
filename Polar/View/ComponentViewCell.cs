using System;
using System.Collections.Generic;
using Polar.Model;
using Xamarin.Forms;

namespace Polar.View
{
    public class ComponentViewCell : ViewCell
    {

        public StackLayout MainLayout { get; set; }

        public ComponentViewCell()
        {
            MainLayout = new StackLayout();
        }


        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                Piece piece = (Piece)BindingContext;


                StackLayout subLayout = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                StackLayout horizontalLayout = new StackLayout 
                { 
                    Orientation = StackOrientation.Horizontal,
                };


                StackLayout taskLayout = new StackLayout
                {
                    IsVisible = false,
                };

                subLayout.Children.Add(PieceNameLable(piece));

                subLayout.Children.Add(ProjectNameLable(piece));

                horizontalLayout.Children.Add(subLayout);
                horizontalLayout.Children.Add(DropDownButton());


                foreach (var task in piece.Tasks)
                {
                    taskLayout.Children.Add(TaskNameLabel(task));
                }


                MainLayout.Children.Add(horizontalLayout);

                MainLayout.Children.Add(taskLayout);

                BoxView boxView = new BoxView
                {
                    BackgroundColor = Color.Black,
                    HeightRequest = 1,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                MainLayout.Children.Add(boxView);


                View = MainLayout;


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.ForceUpdateSize();

            Button button = (Button)sender;

            StackLayout stackLayout = (StackLayout)button.Parent.Parent;
            if (stackLayout.Children[stackLayout.Children.Count - 2].IsVisible)
            {
                stackLayout.Children[stackLayout.Children.Count - 2].IsVisible = false;
                button.Text = "V";
            }
            else
            {
                stackLayout.Children[stackLayout.Children.Count - 2].IsVisible = true;
                button.Text = "-";
            }

        }

        private Xamarin.Forms.View PieceNameLable(Piece piece)
        {
            Label pieceName = new Label
            {
                Text = piece.PieceName,
                Margin = new Thickness(5, 5, 0, 0)
            };

            return pieceName;
        }

        private Xamarin.Forms.View ProjectNameLable(Piece piece)
        {
            Label projectName = new Label
            {
                Text = piece.GetProject().ProjectName,
                FontSize = 12,
                TextColor = (Color)App.Current.Resources["Gray"],
                Margin = new Thickness(5, 0, 0, 0)

            };

            return projectName;
        }

        private Xamarin.Forms.View DropDownButton()
        {
            Button button = new Button
            {
                Text = "V",
                BackgroundColor = Color.Default,
                TextColor = Color.Black,
                Padding = new Thickness(0)
            };
            button.Clicked += Button_Clicked;

            return button;
        }


        private Xamarin.Forms.View TaskNameLabel(Task task)
        {
            Label taskName = new Label
            {
                Text = task.TaskName,
                Margin = new Thickness(20, 0, 0, 0),
                FontSize = 15,

            };

            if (task.IsComplete)
            {
                taskName.TextDecorations = TextDecorations.Strikethrough;
            }

            return taskName;
        }

    }
}
