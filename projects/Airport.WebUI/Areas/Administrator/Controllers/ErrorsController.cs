using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Administrator/Errors
        public ActionResult Index()
        {
            return View();
        }
    }
}