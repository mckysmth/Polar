using System;
using System.Collections.Generic;
using Polar.Model;
using Polar.Services;
using Xamarin.Forms;

namespace Polar
{
    public partial class AddEventPage : ContentPage
    {
        User User;
        public AddEventPage()
        {
            InitializeComponent();
            User = App.user;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {


            DateTime dateTime = new DateTime(Datepicker.Date.Year, Datepicker.Date.Month, Datepicker.Date.Day, Timepicker.Time.Hours, Timepicker.Time.Minutes, 0);


            Piece piece = new Piece(User.Id, dateTime, IsReoccuring.IsToggled)
            {
                PieceName = EventName.Text
            };


            User.AddEvent(piece);
            SQLService SQL = new SQLService();
            SQL.InsertNewPiece(piece);

            App.Current.MainPage = new NavPage();


        }
    }
}
