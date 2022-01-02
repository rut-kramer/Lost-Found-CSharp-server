using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LatLng
    {
        public double Lng { get; set; }
        public double Lat { get; set; }

      public LatLng(double lng, double lat) { Lat = lat; Lng = lng; }
    }
}
