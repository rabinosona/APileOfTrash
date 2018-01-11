using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CompanyTaskMVC.OtherCode
{
    abstract class JSONWorker
    {
        protected string jsonSerializedString;
    }

    class JSONWorkerMyClass : JSONWorker
    {

        public JSONWorkerMyClass(string passedString, int passedInt)
        {
            CompanyTaskMVC.Models.MyClassModel model = new CompanyTaskMVC.Models.MyClassModel
            {
                MyString = passedString,
                MyInt = passedInt
            };

            jsonSerializedString = JsonConvert.SerializeObject(model, Formatting.Indented);
        }

        public string JsonSerializedString { get { return jsonSerializedString; } }
    }
}

