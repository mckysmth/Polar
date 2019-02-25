using System;
using Microsoft.WindowsAzure.MobileServices;
using Polar.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Polar
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
<<<<<<< HEAD
        public static User user;
<<<<<<< HEAD
=======
        public static MobileServiceClient MobileServiceClient = 
            new MobileServiceClient("");
>>>>>>> parent of d6477a5... Had to commit
=======
        public static User user = new User();
>>>>>>> parent of ce62694... SQL save and load project

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage());
        }
        public App(String databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
