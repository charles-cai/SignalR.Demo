using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
using NHQS;

namespace SignalR.Demo.Hubs
{
    public class GeoCheckinHub : Hub
    {
        public void Checkin(CheckinRequest request)
		{
            var session = SessionFactory.For<GeoCheckin.Domain.GeoCheckin>().OpenSession();

            var user = session.Find<GeoCheckin.Domain.GeoCheckin>(x => x.Username == request.Username);

            if (user.Any())
            {
                var u = user.First();
                u.Latitude = request.Latitude;
                u.Longitude = request.Longitude;

                session.Update<GeoCheckin.Domain.GeoCheckin>(u);
            }
            else
            {
                session.Save<GeoCheckin.Domain.GeoCheckin>(new GeoCheckin.Domain.GeoCheckin
                {
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Username = request.Username
                });
            }

            this.GetAllCheckins();
		}

        public void GetAllCheckins()
        {
            var session = SessionFactory.For<GeoCheckin.Domain.GeoCheckin>().OpenSession();
            var lastCheckins = session.Find<GeoCheckin.Domain.GeoCheckin>(x => x.Id > 0).ToList();
            List<CheckinRequest> requests = new List<CheckinRequest>();
            lastCheckins.ForEach(r => requests.Add(new CheckinRequest { Latitude = r.Latitude, Longitude = r.Longitude, Username = r.Username }));
            Clients.showCheckins(requests);
        }
    }

    public class CheckinRequest
    {
        public string Username { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}