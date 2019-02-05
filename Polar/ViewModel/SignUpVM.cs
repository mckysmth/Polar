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
                UpdateUser();
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
                UpdateUser();
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
                UpdateUser();
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
                UpdateUser();
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
                UpdateUser();
                OnPropertyChanged("ConfirmationPassword");
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                UpdateUser();
                OnPropertyChanged("PhoneNumber");
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
                    await App.Current.MainPage.Navigation.PushAsync(new DoListPage());
                    //ErrorMessage = "Account created";
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

        private void UpdateUser()
        {
            User = new User()
            {
                FirstName = this.firstName,
                LastName = this.lastName,
                Email = this.Email,
                Password = this.Password
            };
        }
    }
}
