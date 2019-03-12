using System;
using System.ComponentModel;
using Polar.Model;
using Polar.Services;
using Polar.ViewModel.Commands;

namespace Polar.ViewModel
{
    public class SignUpVM : INotifyPropertyChanged
    {
        public SignUpCommand SignUpCommand { get; set; }

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

        private string confirmationPassword;

        public string ConfirmationPassword
        {
            get { return confirmationPassword; }
            set
            {
                confirmationPassword = value;
                OnPropertyChanged("ConfirmationPassword");
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

        public SignUpVM()
        {
            User = new User();
            SignUpCommand = new SignUpCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }


        public async void NavigateToLading()
        {
            AzureService azure = new AzureService();

            if (User.Password == ConfirmationPassword)
            {
                //if (azure.GetUserByEmail(User) == null)
                //{
                    await azure.InsertNewUser(User);

                    //App.Current.MainPage = new NavPage();
                //}
                //else
                //{
                //    ErrorMessage = "Account already Exists.";
                //}
            }
            else
            {
                ErrorMessage = "Passwords do not match.";
            }



        }

    }
}
