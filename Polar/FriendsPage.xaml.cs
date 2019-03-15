using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Polar.Model;
using Polar.Services;
using Xamarin.Forms;

namespace Polar
{
    public partial class FriendsPage : ContentPage
    {
        ObservableCollection<User> users;
        private Project project;

        public FriendsPage()
        {
            InitializeComponent();
            users = new ObservableCollection<User>();
        }

        public FriendsPage(Project project)
        {
            InitializeComponent();
            this.project = project;
            friendList.ItemSelected += FriendList_ItemSelected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            users = await AzureService.GetFriendsList(App.user);

            friendList.ItemsSource = users;

        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (await AzureService.SendFriendRequest(AddFriend.Text))
            {
                AddFriend.Text = "";
            }
        }

        async void FriendList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User user = (User)e.SelectedItem;

            await AzureService.ShareNewProject(user, project);

            App.Current.MainPage = new NavPage();
        }

    }
}
