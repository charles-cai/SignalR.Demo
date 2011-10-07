using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Demo.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Calculator()
		{
			return View();
		}

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ConnectionTest()
		{
			return View();
		}

		public ActionResult Checkin()
		{
			return View();
		}

        public ActionResult Jasmine()
        {
            return View();
        }

        public ActionResult JasmineCalculator()
        {
            return View();
        }
    }
}
