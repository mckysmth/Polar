using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Polar.Model;
using Xamarin.Forms;

namespace Polar.View
{
    public class ComponentViewCell : ViewCell
    {
        public static BindableProperty PieceProperty =
            BindableProperty.Create("Piece", typeof(Piece), typeof(ComponentViewCell), null);

        public Piece Piece
        {
            get { return (Piece)GetValue(PieceProperty); }
            set { SetValue(PieceProperty, value); }
        }

        public static readonly BindableProperty IdProperty =
            BindableProperty.Create("Id", typeof(ObjectId), typeof(ComponentViewCell), null);

        public ObjectId Id
        {
            get { return (ObjectId)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public StackLayout Layout { get; set; }

        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                //var filter = Builders<Project>.Filter.Eq("_id", Id);
                //var filter = Builders<Project>.Filter.And(Builders<Project>.Filter.r.Eq("_id", Id), Builders<Project>.Filter.ElemMatch(x => x.Pieces, p => p.);
                var update = Builders<Project>.Update.Set("Pieces.$", Piece);

                //Client.GetProjectsCollection().UpdateOne(filter, update);


                Label label = new Label
                {
                    Text = Piece.PieceName
                };

                //Layout.Children.Add(label);
                UpdateView();
            }

        }

        private void UpdateView()
        {
            View = Layout;
        }
    }
}
