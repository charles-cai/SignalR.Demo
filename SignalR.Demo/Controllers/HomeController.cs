using System.Web.Mvc;

namespace SignalR.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ConnectionTest()
		{
			return View();
		}

		public ActionResult Chat()
		{
			return View();
		}
    }
}
