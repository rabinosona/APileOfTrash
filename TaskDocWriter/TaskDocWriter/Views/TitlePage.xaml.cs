using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaskDocWriter.Controllers;
using TaskDocWriter.Models;

namespace TaskDocWriter.Views
{
    /// <summary>
    /// Interaction logic for TitlePage.xaml
    /// </summary>
    public partial class TitlePage : Page
    {
        TitlePageController controller = new TitlePageController();

        public TitlePage()
        {
            InitializeComponent();

            controller.AssignPage(this);

            UsersModelSingleton.Users = new ObservableCollection<UserModel>();

            controller.LoadToListView(UserDataList);
        }

        private void AddUserButtonClicked(object e, RoutedEventArgs data)
        {
            InputPrompt input = new InputPrompt();
            input.ShowDialog();
        }

        public void RemoveUserButtonClicked(object e, RoutedEventArgs data)
        {
            if (UsersModelSingleton.Users[UserDataList.SelectedIndex] != null)
            {
                controller.RemoveRecording(UsersModelSingleton.Users[UserDataList.SelectedIndex]);
                UsersModelSingleton.Users.RemoveAt(UserDataList.SelectedIndex);
            }
        }

        public void AddDataToListView(UserModel user)
        {
            UserDataList.Items.Add(user);
        }

        public void SearchButtonClicked(object e, RoutedEventArgs data)
        {
            UserModel searchedUser = new UserModel();
            searchedUser.Email = UserSearchableEmail.Text;
            searchedUser.Phone = UserSearchablePhone.Text;
            searchedUser.Surname = UserSearchableSurname.Text;

            List<int> foundItemsIndexes = new List<int>();



            for (int i = 0; i < UsersModelSingleton.Users.Count; i++)
            {
                UserModel user = UsersModelSingleton.Users[i];

                if (searchedUser.Surname == user.Surname || searchedUser.Phone == user.Phone || searchedUser.Email == user.Email)
                {
                    foundItemsIndexes.Add(i);
                }
            }
        }
    }
}
