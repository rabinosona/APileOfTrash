using System;
using System.Collections.Generic;
using TaskDocWriter.Services;
using TaskDocWriter.Models;
using TaskDocWriter.Constants;
using System.Windows.Controls;
using TaskDocWriter.Views;

namespace TaskDocWriter.Controllers
{
    class TitlePageController
    {
        XMLWorkerService xmlWorker;
        List<UserModel> usersList = new List<UserModel>();
        bool isXML;
        static public TitlePage titlePage;

        public TitlePageController()
        {
            isXML = true;
            xmlWorker = new XMLWorkerService(MainAppConstants.XMLFileName);
        }

        public void AssignPage(TitlePage title)
        {
            titlePage = title;
        }

        public void LoadToListView(ListView view)
        {
            if (isXML)
            {
                xmlWorker.LoadDataFromFile(MainAppConstants.XMLUserAttrName, usersList);

                usersList.ForEach(user => UsersModelSingleton.Users.Add(user));
                view.ItemsSource = UsersModelSingleton.Users;
            }
            else
            {

            }
        }
    }
}
