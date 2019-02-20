using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Polar.Services;
using Polar.Model;
using Polar.ViewModel.Commands;

namespace Polar.ViewModel
{
    public class LogInVM : INotifyPropertyChanged
    {
        public LogInToSignUpNavCommand LogInToSignUpNavCommand { get; set; }
        public LogInCommand LogInCommand { get; set; }

        private User user;

        public User User 
        {
            get { return user; }
            set 
            { 
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public LogInVM()
        {
            User = new User();
            LogInToSignUpNavCommand = new LogInToSignUpNavCommand(this);
            LogInCommand = new LogInCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public async void NavigateToSignUp()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }

        public async void LogIn()
        {
            MongoService mongo = new MongoService();

            User userDB = await mongo.GetUserByEmail(User.Email);
            if (userDB != null)
            {
                if (userDB.Password == User.Password)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new DoListPage());
                }
                else
                {
                    ErrorMessage = "Incorrect Email/Password.";
                }
            }
            else
            {
                ErrorMessage = "Incorrect Email/Password.";
            }
        }
    }
}
