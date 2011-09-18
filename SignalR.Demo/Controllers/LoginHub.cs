using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace SignalR.Demo.Controllers
{
	public class LoginHub : Hub
	{
		private static List<string> Usernames { get; set; }
		private static object _lock = new object();

		static LoginHub()
		{
			lock (_lock)
			{
				Usernames = new List<string>();
			}
		}

		public void Login(string username)
		{
			if (!Usernames.Contains(username))
			{
				Usernames.Add(username);

				Clients.confirmLogin(new 
				{ 
					success = true, 
					username = username, 
					userList = Usernames.ToArray()
				});
			}
		}
	}
}