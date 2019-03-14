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
        int repeater = 0;
        bool[] dayChecker = { false, false, false, false, false, false, false};
        public AddEventPage()
        {
            InitializeComponent();
            User = App.user;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {


            DateTime dateTime = new DateTime(Datepicker.Date.Year, Datepicker.Date.Month, Datepicker.Date.Day, Timepicker.Time.Hours, Timepicker.Time.Minutes, 0);



            Piece piece = new Piece(User.Id, dateTime, repeater)
            {
                PieceName = EventName.Text
            };


            await User.AddEventAsync(piece);
            //SQLService SQL = new SQLService();
            await AzureService.InsertNewPiece(piece);

            App.Current.MainPage = new NavPage();


        }


        void Handle_Clicked_1(object sender, System.EventArgs e)
        {

            var value = (Repeater)Convert.ToByte(((Button)sender).BindingContext.ToString());
            Button btn = (Button)sender;
            switch (value)
            {
                case Repeater.Sunday:
                    SetDayCode(value, 0, btn);
                    break;
                case Repeater.Monday:
                    SetDayCode(value, 1, btn);
                    break;
                case Repeater.Tuesday:
                    SetDayCode(value, 2, btn);
                    break;
                case Repeater.Wednesday:
                    SetDayCode(value, 3, btn);
                    break;
                case Repeater.Thursday:
                    SetDayCode(value, 4, btn);
                    break;
                case Repeater.Friday:
                    SetDayCode(value, 5, btn);
                    break;
                case Repeater.Saturday:
                    SetDayCode(value, 6, btn);
                    break;
                case Repeater.Monthly:
                    SetDayCode(value, 6, btn);
                    break;
                case Repeater.Weekly:
                    SetDayCode(value, 6, btn);
                    break;
            }

        }

        private void SetDayCode(Repeater value, int dayCheckerIndexer, Button button)
        {
            if (!dayChecker[dayCheckerIndexer])
            {
                repeater += (int)value;
                dayChecker[dayCheckerIndexer] = true;
                button.BackgroundColor = Color.LightGray;
            }
            else
            {
                repeater -= (int)value;
                dayChecker[dayCheckerIndexer] = false;
                button.BackgroundColor = Color.Orange;

            }
        }
    }
}
