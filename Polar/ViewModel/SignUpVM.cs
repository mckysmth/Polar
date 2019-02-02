using System;
using System.ComponentModel;
using Polar.Model;
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

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                User = new User()
                {
                    FirstName = this.firstName,
                    LastName = this.lastName,
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                User = new User()
                {
                    FirstName = this.firstName,
                    LastName = this.lastName,
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("LastName");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User()
                {
                    FirstName = this.firstName,
                    LastName = this.lastName,
                    Email = this.Email,
                    Password = this.Password
                };

                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    FirstName = this.firstName,
                    LastName = this.lastName,
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmationPassword;

        public string ConfirmationPassword
        {
            get { return confirmationPassword; }
            set
            {
                confirmationPassword = value;
                User = new User()
                {
                    FirstName = this.firstName,
                    LastName = this.lastName,
                    Email = this.Email,
                    Password = this.Password
                };
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
            //TODO
            if (Password == ConfirmationPassword)
            {
                if (await User.Register(user))
                {
                    //await App.Current.MainPage.Navigation.PushAsync();
                }
                else
                {
                    ErrorMessage = "Account already exists";
                }
            }
            else
            {
                ErrorMessage = "Not matching passwords";
            }
        }
    }
}
