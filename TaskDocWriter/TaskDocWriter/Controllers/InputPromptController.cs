using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDocWriter.Constants;
using TaskDocWriter.Models;
using TaskDocWriter.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TaskDocWriter.Controllers
{
    class InputPromptController
    {
        XMLWorkerService xmlWorker;

        public InputPromptController()
        {
            xmlWorker = new XMLWorkerService(MainAppConstants.XMLFileName);
        }

        public void SaveUserData(string surname, string phone, string email)
        {
            UserModel user = new UserModel();
            user.Surname = surname; user.Phone = phone; user.Email = email;
            xmlWorker.SaveDataToFile(user);
        }
    }
}
