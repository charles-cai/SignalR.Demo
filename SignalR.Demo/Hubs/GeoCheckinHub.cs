using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;

namespace SignalR.Demo.Hubs
{
	public class GeoCheckinHub : Hub
	{
		public void Checkin(CheckinRequest request)
		{
			Clients.showCheckin(request);
		}
	}

	public class CheckinRequest
	{
		public string Username { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}