using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TaskDocWriter.Constants;
using TaskDocWriter.Models;
using TaskDocWriter.Services;
using TaskDocWriter.Views;

namespace TaskDocWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XMLWorkerService xmlWorker;

        public MainWindow()
        {
            InitializeComponent();
            xmlWorker = new XMLWorkerService(MainAppConstants.XMLFileName);

            TitlePage titlePage = new TitlePage();

            _NavigationFrame.Navigate(titlePage);
        }
    }
}
