using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCheckin.Domain
{
    public class GeoCheckin
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
    }
}
