using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompanyTaskMVC.Models;
using CompanyTaskMVC.OtherCode;

namespace CompanyTaskMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MainPage()
        {
            JSONWorkerMyClass jsonWorker = new JSONWorkerMyClass("example string", 1);
            string json = jsonWorker.JsonSerializedString;

            ViewData["json"] = json;

            return View("MainPage");
        }

        [HttpPost]
        [Route("HomeController/AjaxAnswer")]
        public ActionResult AjaxAnswer()
        {
            return Content("");
        }

    }
}
