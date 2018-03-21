using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            List<UserModel> users = new List<UserModel>();

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
