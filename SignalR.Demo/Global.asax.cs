using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SignalR.Routing;
using SignalR.Demo.Controllers;

namespace SignalR.Demo
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapConnection<ServerTimeConnection>("clock", "clock/{*operation}");
			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}
	}
}