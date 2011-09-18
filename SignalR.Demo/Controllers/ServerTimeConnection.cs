using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Demo.Aspects;

namespace SignalR.Demo.Controllers
{
	[LogExecution]
	public class ServerTimeConnection : PersistentConnection
	{
		public ServerTimeConnection()
		{

		}

		protected override IConnection CreateConnection(string clientId, IEnumerable<string> groups, HttpContextBase context)
		{
			return base.CreateConnection(clientId, groups, context);
		}

		protected override void OnConnected(HttpContextBase context, string clientId)
		{
			base.OnConnected(context, clientId);
		}

		protected override System.Threading.Tasks.Task OnConnectedAsync(HttpContextBase context, string clientId)
		{
			return base.OnConnectedAsync(context, clientId);
		}

		protected override void OnDisconnect(string clientId)
		{
			base.OnDisconnect(clientId);
		}

		protected override System.Threading.Tasks.Task OnDisconnectAsync(string clientId)
		{
			return base.OnDisconnectAsync(clientId);
		}

		protected override void OnReceived(string clientId, string data)
		{
			base.OnReceived(clientId, data);
		}

		protected override System.Threading.Tasks.Task OnReceivedAsync(string clientId, string data)
		{
			return base.OnReceivedAsync(clientId, data);
		}

		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);
		}

		public override System.Threading.Tasks.Task ProcessRequestAsync(HttpContext context)
		{
			return base.ProcessRequestAsync(context);
		}
	}
}