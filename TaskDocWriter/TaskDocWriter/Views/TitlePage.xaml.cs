using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void AddDataToListView(UserModel user)
        {
            UserDataList.Items.Add(user);
        }
    }
}
