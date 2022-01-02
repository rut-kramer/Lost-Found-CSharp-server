using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{ 
    public class Route
    {
        public int Id { get; set; }
        public int BusNumber { get; set; }
        public Agency Agency { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
