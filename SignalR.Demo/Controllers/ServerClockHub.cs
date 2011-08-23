using SignalR.Hubs;
using System;
using System.Timers;

namespace SignalR.Demo.Controllers
{
    public class ServerClockHub : Hub
    {
        Timer _timer;

        public void Send()
        {
            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Interval = 1000;
                _timer.Elapsed += (sender, e) => Send();
                _timer.Start();
            }

            Clients.showTime(DateTime.Now.ToString("T"));
        }
    }
}