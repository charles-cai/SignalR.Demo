using SignalR.Hubs;
using System;
using System.Timers;

namespace SignalR.Demo.Hubs
{
    public class ServerClockHub : Hub
    {
        Timer _timer;

        public void GetServerTime()
        {
            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Interval = 1000;
				_timer.Elapsed += (sender, e) => GetServerTime();
                _timer.Start();
            }

            Clients.showTime(DateTime.Now.ToString("T"));
        }
    }
}