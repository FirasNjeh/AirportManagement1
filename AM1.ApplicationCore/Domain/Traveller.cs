using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Domain
{
    public class Traveller :Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }
    }
}
