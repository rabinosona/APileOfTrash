using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDocWriter.Models;

namespace TaskDocWriter
{
    static class UsersModelSingleton
    {
        public static ObservableCollection<UserModel> Users { get; set; }
    }
}
