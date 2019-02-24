using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebErrorLogging.Controllers
{
    public class HomeController : Controller
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            Log.Debug("Hi I am log4net Debug Level");
            Log.Info("Hi I am log4net Info Level");
            Log.Warn("Hi I am log4net Warn Level");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}